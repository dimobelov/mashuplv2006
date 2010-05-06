﻿using System;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Windows.Media;
using System.Windows.Controls;

namespace MashupDesignTool
{
    public class MyXmlSerializer
    {
        private static string[] skipPropertyList = new string[] 
                                                    {
                                                        "Template", "Resources", "Language", "RenderTransform"
                                                    };

        public static string Serialize(object o)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter xm = XmlWriter.Create(sb);
            xm.WriteStartElement(o.GetType().Name);
            xm.WriteAttributeString("Type", o.GetType().AssemblyQualifiedName);
            Serialize(o, xm);
            xm.WriteEndElement();
            xm.Flush();
            xm.Close();
            return sb.ToString();
        }

        #region serialize list and collection
        private static void SerializeList(object o, XmlWriter xm)
        {
            object lst = o;
            if (lst == null)
                return;
            int count = (int)(lst.GetType().GetProperty("Count").GetValue(lst, null));
            if (count == 0)
                return;
            object[] index = { 0 };
            object myObject = lst.GetType().GetProperty("Item").GetValue(lst, index);
            string elementType = myObject.GetType().AssemblyQualifiedName;

            xm.WriteStartElement("Child", o.GetType().AssemblyQualifiedName);
            xm.WriteAttributeString("Type", elementType);
            for (int i = 0; i < count; i++)
            {
                index[0] = i;
                myObject = lst.GetType().GetProperty("Item").GetValue(lst, index);
                if (myObject.GetType().IsGenericType)
                    SerializeList(myObject, null, xm);
                xm.WriteStartElement("Child");
                xm.WriteAttributeString("Type", elementType);
                Serialize(myObject, xm);
                xm.WriteEndElement();
            }
            xm.WriteEndElement();
        }
        private static void SerializeList(object o, PropertyInfo pi, XmlWriter xm)
        {
            object lst = pi.GetValue(o, null);
            if (lst == null)
                return;
            int count = (int)(lst.GetType().GetProperty("Count").GetValue(lst, null));
            if (count == 0)
                return;
            object[] index = { 0 };
            object myObject = lst.GetType().GetProperty("Item").GetValue(lst, index);
            string elementType = myObject.GetType().AssemblyQualifiedName;

            xm.WriteStartElement(pi.Name);
            xm.WriteAttributeString("Type", pi.PropertyType.AssemblyQualifiedName);
            for (int i = 0; i < count; i++)
            {
                index[0] = i;
                myObject = lst.GetType().GetProperty("Item").GetValue(lst, index);
                if (myObject.GetType().IsGenericType)
                    SerializeList(myObject, xm);
                else
                {
                    xm.WriteStartElement("Child");
                    xm.WriteAttributeString("Type", elementType);
                    Serialize(myObject, xm);
                    xm.WriteEndElement();
                }
            }
            xm.WriteEndElement();
        }
        #endregion

        #region serialize array
        private static void SerializeArray(object o, XmlWriter xm)
        {
            object lst = o;
            if (lst == null)
                return;
            int count = (int)(lst.GetType().GetProperty("Length").GetValue(lst, null));
            Array a = (Array)lst;
            string elementType = a.GetType().GetElementType().AssemblyQualifiedName;

            xm.WriteStartElement("Child");
            xm.WriteAttributeString("Type", o.GetType().AssemblyQualifiedName);
            for (int i = 0; i < count; i++)
            {
                xm.WriteStartElement("Child");
                xm.WriteAttributeString("Type", elementType);
                Serialize(a.GetValue(i), xm);
                xm.WriteEndElement();
            }
            xm.WriteEndElement();
        }
        private static void SerializeArray(object o, PropertyInfo pi, XmlWriter xm)
        {
            object lst = pi.GetValue(o, null);
            if (lst == null)
                return;
            int count = (int)(lst.GetType().GetProperty("Length").GetValue(lst, null));
            Array a = (Array)lst;
            string elementType = a.GetType().GetElementType().AssemblyQualifiedName;

            xm.WriteStartElement("Child");
            xm.WriteAttributeString("Type", pi.PropertyType.AssemblyQualifiedName);
            if (a.GetType().GetElementType().IsArray)
            {
                for (int i = 0; i < count; i++)
                {
                    SerializeArray(a.GetValue(i), xm);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    xm.WriteStartElement("Child");
                    xm.WriteAttributeString("Type", elementType);
                    Serialize(a.GetValue(i), xm);
                    xm.WriteEndElement();
                }
            }
            xm.WriteEndElement();

        }
        #endregion

        private static void Serialize(object o, XmlWriter xm)
        {
            if (o == null)
                return;

            Type t = o.GetType();

            //write element value, stop recursive
            if (t.IsPrimitive)
                xm.WriteValue(o.ToString());

            foreach (PropertyInfo pi in t.GetProperties())
            {
                bool b = false;
                foreach (string skip in skipPropertyList)
                {
                    if (skip == pi.Name)
                    {
                        b = true;
                        break;
                    }
                }
                if (b == true)
                    continue;

                if (pi.PropertyType.IsArray)
                {
                    SerializeArray(o, pi, xm);

                    continue;
                }

                if (pi.PropertyType.IsGenericType == true || (typeof(IList).IsAssignableFrom(pi.PropertyType)) == true)
                {
                    SerializeList(o, pi, xm);

                    continue;
                }

                //skip dictionary type
                if (pi.GetIndexParameters().Length > 0)
                    continue;

                if (pi.CanWrite == false || pi.GetSetMethod() == null)
                    continue;

                object value = pi.GetValue(o, null);

                if (value == null)
                    continue;
                xm.WriteStartElement(pi.Name);
                xm.WriteAttributeString("Type", value.GetType().AssemblyQualifiedName);
                Serialize(value, xm);
                xm.WriteEndElement();
            }
        }

        #region load
        public static object Load(string xml)
        {
            object obj = null;
            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;

                Type type = Type.GetType(root.Attribute("Type").Value);
                obj = Activator.CreateInstance(type);

                object value;
                string propertyName;
                foreach (XElement element in root.Nodes())
                {
                    if (type == typeof(ControlTemplate))
                        continue; 
                    propertyName = element.Name.ToString();
                    value = Load(obj, element);
                    if (!typeof(IList).IsAssignableFrom(value.GetType()))
                        type.GetProperty(propertyName).SetValue(obj, value, null);
                }
            }
            catch { }
            return obj;
        }

        private static object Load(object obj, XElement element)
        {
            Type type = Type.GetType(element.Attribute("Type").Value);
            if (type.IsPrimitive)
            {
                return LoadPrimitive(element);
            }
            else if (type.IsArray)
            {
                return LoadArray(obj, element);
            }
            else if (typeof(IList).IsAssignableFrom(type))
            {
                return LoadList(obj, element);
            }
            else
            {
                return LoadNotPrimitive(obj, element);
            }
        }

        private static object LoadPrimitive(XElement element)
        {
            Type type = Type.GetType(element.Attribute("Type").Value);
            return Convert.ChangeType(element.Value, type, null);
        }

        private static object LoadArray(object obj, XElement element)
        {
            Type type = Type.GetType(element.Attribute("Type").Value);

            int count = 0;
            foreach (XElement child in element.Elements("Child"))
                count++;
            Array array = Array.CreateInstance(type, count);

            count = 0;
            foreach (XElement child in element.Elements("Child"))
            {
                object temp = Load(array, child);
                array.SetValue(temp, count);
                count++;
            }
            return array;
        }

        private static object LoadList(object obj, XElement element)
        {
            Type type = Type.GetType(element.Attribute("Type").Value);
            //IList list = (IList)Activator.CreateInstance(type);
            IList list = (IList)obj.GetType().GetProperty(element.Name.ToString()).GetValue(obj, null);

            foreach (XElement child in element.Elements("Child"))
            {
                object temp = Load(list, child);
                list.Add(temp);
            }
            return list;
        }

        private static object LoadNotPrimitive(object obj, XElement element)
        {
            Type type = Type.GetType(element.Attribute("Type").Value);
            if (type == typeof(System.String))
                return element.Value;

            if (type == typeof(FontFamily))
            {
                string font = "Portable User Interface";
                if (element.Value != "")
                    font = element.Value;
                return new FontFamily(font);
            }

            //if (type == typeof(ControlTemplate))
            //{
            //    return obj.GetType().GetProperty(element.Name.ToString()).GetValue(obj, null);
            //}

            //if (type.FullName == "System.RuntimeType")
            //{
            //    return obj.GetType().GetProperty(element.Name.ToString()).GetValue(obj, null);
            //}

            object obj1 = Activator.CreateInstance(type);

            if (element.Name.ToString() == "Matrix")
            {
                int bac = 3;
            }

            string propertyName;
            object value;
            foreach (XElement child in element.Elements())
            {
                if (type == typeof(ControlTemplate))
                    continue;
                propertyName = child.Name.ToString();
                value = Load(obj1, child);
                type.GetProperty(propertyName).SetValue(obj1, value, null);
            }

            return obj1;
        }
        #endregion load
    }
}
