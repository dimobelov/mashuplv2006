﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using BasicLibrary;
using System.Xml;
using System.IO;

namespace SilverlightTextBlock
{
    public partial class TextBlock : BasicControl
    {
        public TextBlock()
        {
            InitializeComponent();

            parameterNameList.Add("Text");
            parameterNameList.Add("TextColor");
            parameterNameList.Add("FontStyle");
            parameterNameList.Add("FontSize");
            parameterNameList.Add("FontWeight");
            parameterNameList.Add("TextTrimming");
            parameterNameList.Add("TextWrapping");
            parameterNameList.Add("TextFontFamily");
            parameterNameList.Add("Background");

            AddOperationNameToList("ChangeText");
        }

        public string Text
        {
            get { return textBlock1.Text; }
            set { textBlock1.Text = value; }
        }

        public Brush TextColor
        {
            get { return textBlock1.Foreground; }
            set { textBlock1.Foreground = value; }
        }

        public FontStyle FontStyle
        {
            get { return textBlock1.FontStyle; }
            set { textBlock1.FontStyle = value; }
        }

        public double FontSize
        {
            get { return textBlock1.FontSize; }
            set { textBlock1.FontSize = Math.Max(0, value); }
        }

        public FontWeight FontWeight
        {
            get { return textBlock1.FontWeight; }
            set { textBlock1.FontWeight = value; }
        }

        public TextWrapping TextWrapping
        {
            get { return textBlock1.TextWrapping; }
            set { textBlock1.TextWrapping = value; }
        }

        public TextTrimming TextTrimming
        {
            get { return textBlock1.TextTrimming; }
            set { textBlock1.TextTrimming = value; }
        }

        public FontFamily TextFontFamily
        {
            get { return textBlock1.FontFamily; }
            set { textBlock1.FontFamily = value; }
        }

        public void ChangeText(string xml)
        {
            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                while (reader.Read())
                {
                    if (reader.Name == "Text")
                    {
                        textBlock1.Text = reader.ReadInnerXml();
                    }
                }
            }
            catch { }
        }
    }
}
