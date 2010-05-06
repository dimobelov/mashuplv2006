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

namespace MashupDesignTool
{
    public partial class ProxyControl : UserControl
    {
        private UserControl realControl;

        public ProxyControl()
        {
            InitializeComponent();
        }

        public ProxyControl(UserControl uc, double x, double y, double width, double height)
        {
            InitializeComponent();
            realControl = uc;
            MoveControl(x, y);
            ResizeControl(width, height);

            uc.SizeChanged += new SizeChangedEventHandler(uc_SizeChanged);
        }

        public ProxyControl(UserControl uc)
        {
            InitializeComponent();
            realControl = uc;
            uc.SizeChanged += new SizeChangedEventHandler(uc_SizeChanged);
        }

        public ProxyControl(UserControl uc, double x, double y)
        {
            InitializeComponent();
            realControl = uc;
            MoveControl(x, y);
            uc.SizeChanged += new SizeChangedEventHandler(uc_SizeChanged);
        }

        void uc_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;
            double x = Canvas.GetLeft(realControl);
            double y = Canvas.GetTop(realControl);

            realControl.Width = width;
            realControl.Height = height;

            this.SetValue(Canvas.LeftProperty, x - 7);
            this.SetValue(Canvas.TopProperty, y - 7);
            this.Width = width + 14;
            this.Height = height + 14;
        }

        public UserControl RealControl
        {
            get { return realControl; }
            set { realControl = value; }
        }

        public void ResizeControl(double width, double height)
        {
            realControl.Width = width;
            realControl.Height = height;

            this.Width = width + 14;
            this.Height = height + 14;
        }

        public void MoveControl(double x, double y)
        {
            realControl.SetValue(Canvas.LeftProperty, x);
            realControl.SetValue(Canvas.TopProperty, y);

            this.SetValue(Canvas.LeftProperty, x - 7);
            this.SetValue(Canvas.TopProperty, y - 7);
        }

        public void UpdateVisibility(Visibility vis)
        {
            controlBound.Visibility = vis;
            controlBoundBottomLeft.Visibility = vis;
            controlBoundBottomRight.Visibility = vis;
            controlBoundTopLeft.Visibility = vis;
            controlBoundTopRight.Visibility = vis;
        }
    }
}