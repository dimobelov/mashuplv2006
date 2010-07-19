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
using BasicLibrary;
using System.Xml;
using System.IO;

namespace BlacklightTextBlock
{
    public partial class DropShadowTextBlock : BasicControl
    {
        public DropShadowTextBlock()
        {
            InitializeComponent();
            parameterNameList.Add("Text");
            parameterNameList.Add("TextColor");
            parameterNameList.Add("FontStyle");
            parameterNameList.Add("FontSize");
            parameterNameList.Add("FontWeight");
            parameterNameList.Add("TextWrapping");
            parameterNameList.Add("TextBackground");
            parameterNameList.Add("TextFontFamily");
            parameterNameList.Add("DropShadowColor");
            parameterNameList.Add("DropShadowOpacity");
            parameterNameList.Add("DropShadowDistance");
            parameterNameList.Add("DropShadowAngle");

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

        public Brush TextBackground
        {
            get { return LayoutRoot.Background; }
            set { LayoutRoot.Background = value; }
        }

        public FontStyle FontStyle
        {
            get { return textBlock1.FontStyle; }
            set { textBlock1.FontStyle = value; }
        }

        public double FontSize
        {
            get { return textBlock1.FontSize; }
            set { textBlock1.FontSize = Math.Max(0, Math.Min(100, value)); }
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

        public FontFamily TextFontFamily
        {
            get { return textBlock1.FontFamily; }
            set { textBlock1.FontFamily = value; }
        }

        public double DropShadowOpacity
        {
            get { return textBlock1.DropShadowOpacity; }
            set { textBlock1.DropShadowOpacity = Math.Min(0, Math.Max(1, value)); }
        }

        public double DropShadowAngle
        {
            get { return textBlock1.DropShadowAngle; }
            set { textBlock1.DropShadowAngle = Math.Min(0, Math.Max(360, value)); }
        }

        public double DropShadowDistance
        {
            get { return textBlock1.DropShadowDistance; }
            set { textBlock1.DropShadowDistance = Math.Min(0, Math.Max(50, value)); }
        }

        public Color DropShadowColor
        {
            get { return textBlock1.DropShadowColor; }
            set { textBlock1.DropShadowColor = value; }
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
