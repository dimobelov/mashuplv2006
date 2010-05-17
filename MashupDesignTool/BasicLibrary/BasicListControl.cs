﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;
using System.Xml;

namespace BasicLibrary
{
    public class BasicListControl : BasicControl
    {
        protected List<string> parameterNameList = new List<string>();
        #region IBasic Members
        public override string GetParameterNames()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter xw = XmlWriter.Create(sb);
            xw.WriteStartDocument();
            xw.WriteStartElement("ParameterNames");

            foreach (string name in parameterNameList)
            {
                xw.WriteStartElement("ParameterName");
                xw.WriteValue(name);
                xw.WriteEndElement();
            }

            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Flush();
            xw.Close();
            return sb.ToString();
        }

        public override Type GetParameterType(string parameterName)
        {
            if (parameterNameList.Contains(parameterName))
                return this.GetType().GetProperty(parameterName).PropertyType;
            return null;
        }

        public override object GetParameterValue(string parameterName)
        {
            if (parameterNameList.Contains(parameterName))
                return this.GetType().GetProperty(parameterName).GetValue(this, null);
            return null;
        }

        public override bool SetParameterValue(string parameterName, object value)
        {
            if (parameterNameList.Contains(parameterName))
            {
                this.GetType().GetProperty(parameterName).SetValue(this, Convert.ChangeType(value, GetParameterType(parameterName), null), null);
                return true;
            }
            return false;
        }
        #endregion

        public delegate void ListChangeHandler(string action, int index1, EffectableControl control, int index2);
        public event ListChangeHandler OnListChange;

        private List<EffectableControl> _items = new List<EffectableControl>();
        public virtual ReadOnlyCollection<EffectableControl> Items
        {
            get { return new ReadOnlyCollection<EffectableControl>(_items); }
        }
        public virtual int ItemCount
        {
            get { return _items.Count; }
        }
        public virtual void AddItem(EffectableControl control)
        {
            if (OnListChange != null)
                OnListChange("ADD", -1, control, -1);
            _items.Add(control);
        }
        public virtual void InsertItem(int index, EffectableControl control)
        {
            if (OnListChange != null)
                OnListChange("INSERT", index, control, -1);
            _items.Insert(index, control);
        }
        public virtual void GetItemAt(int index)
        {
        }
        public virtual void SwapItem(int index1, int index2)
        {
            if (OnListChange != null)
                OnListChange("SWAP", index1, null, index2);
            EffectableControl temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;
        }
        public virtual void RemoveItemAt(int index)
        {
            if (OnListChange != null)
                OnListChange("REMOVEAT", index, null, -1);
            _items.RemoveAt(index);
        }
        public virtual void RemoveItem(EffectableControl control)
        {
            if (OnListChange != null)
                OnListChange("REMOVE", -1, control, -1);
            _items.Remove(control);
        }
        public virtual void RemoveAllItem()
        {
            if (OnListChange != null)
                OnListChange("REMOVEALL", -1, null, -1);
            _items.Clear();
        }
    }
}