﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BasicLibrary;

namespace EffectLibrary
{
    public class MenuMac : BasicListEffect
    {
        List<Storyboard> lstStoryEnter = new List<Storyboard>();
        List<Storyboard> lstStoryLeave = new List<Storyboard>();
        List<SplineDoubleKeyFrame> lstSDKFWidth = new List<SplineDoubleKeyFrame>();
        List<SplineDoubleKeyFrame> lstSDKFHeight = new List<SplineDoubleKeyFrame>();
        double size = 40;

        #region implement abstact method
        public override void Start()
        {
        }
        public override void Stop()
        {
        }
        public override void DetachEffect()
        {
        }
        public override void Next()
        {
        }
        public override void Prev()
        {
        }

        protected override void SetSelfHandle()
        {
        }
        #endregion

        #region method for list change event

        public void AddItem(FrameworkElement element)
        {
            InsertItem(LayoutRoot.Children.Count, element);
        }

        public void InsertItem(int index, FrameworkElement element)
        {
            LayoutRoot.Children.Insert(index, element);

            Storyboard sb;
            DoubleAnimationUsingKeyFrames dakf;
            SplineDoubleKeyFrame sdkf;

            sb = new Storyboard();
            dakf = new DoubleAnimationUsingKeyFrames();
            dakf.BeginTime = TimeSpan.FromSeconds(0);
            sdkf = new SplineDoubleKeyFrame();
            sdkf.KeyTime = TimeSpan.FromSeconds(0.08);
            sdkf.Value = size;
            dakf.KeyFrames.Add(sdkf);
            Storyboard.SetTarget(dakf, element);
            Storyboard.SetTargetProperty(dakf, new PropertyPath("(FrameworkElement.Width)"));
            sb.Children.Add(dakf);

            dakf = new DoubleAnimationUsingKeyFrames();
            dakf.BeginTime = TimeSpan.FromSeconds(0);
            sdkf = new SplineDoubleKeyFrame();
            sdkf.KeyTime = TimeSpan.FromSeconds(0.08);
            sdkf.Value = size;
            dakf.KeyFrames.Add(sdkf);
            Storyboard.SetTarget(dakf, element);
            Storyboard.SetTargetProperty(dakf, new PropertyPath("(FrameworkElement.Height)"));
            sb.Children.Add(dakf);

            lstStoryLeave.Insert(index, sb);

            sb = new Storyboard();
            dakf = new DoubleAnimationUsingKeyFrames();
            dakf.BeginTime = TimeSpan.FromSeconds(0);
            sdkf = new SplineDoubleKeyFrame();
            sdkf.KeyTime = TimeSpan.FromSeconds(0.08);
            sdkf.Value = size;
            dakf.KeyFrames.Add(sdkf);
            lstSDKFWidth.Add(sdkf);
            Storyboard.SetTarget(dakf, element);
            Storyboard.SetTargetProperty(dakf, new PropertyPath("(FrameworkElement.Width)"));
            sb.Children.Add(dakf);

            dakf = new DoubleAnimationUsingKeyFrames();
            dakf.BeginTime = TimeSpan.FromSeconds(0);
            sdkf = new SplineDoubleKeyFrame();
            sdkf.KeyTime = TimeSpan.FromSeconds(0.08);
            sdkf.Value = size;
            dakf.KeyFrames.Add(sdkf);
            lstSDKFHeight.Add(sdkf);
            Storyboard.SetTarget(dakf, element);
            Storyboard.SetTargetProperty(dakf, new PropertyPath("(FrameworkElement.Height)"));
            sb.Children.Add(dakf);

            lstStoryEnter.Insert(index, sb);
        }

        public void Swap(int index1, int index2)
        {
        }

        public void RemoveItemAt(int index)
        {
            LayoutRoot.Children.RemoveAt(index);

        }
        public void RemoveItem(FrameworkElement ui)
        {
            LayoutRoot.Children.Remove(ui);            
                
        }
        public void RemoveAllItem()
        {
            LayoutRoot.Children.Clear();
            lstSDKFHeight.Clear();
            lstSDKFWidth.Clear();
            lstStoryEnter.Clear();
            lstStoryLeave.Clear();
        }
        #endregion

        StackPanel LayoutRoot;
        public MenuMac(BasicListControl control):base(control)
        {
            control.MouseEnter += new MouseEventHandler(MenuMacOS_MouseEnter);
            control.MouseMove += new MouseEventHandler(MenuMacOS_MouseEnter);
            control.MouseLeave += new MouseEventHandler(MenuMacOS_MouseLeave);
            control.OnListChange += new BasicListControl.ListChangeHandler(control_OnListChange);
            LayoutRoot = new StackPanel();
            control.Content = LayoutRoot;

            LayoutRoot.Background = new SolidColorBrush(Colors.Red);
            LayoutRoot.Orientation = Orientation.Horizontal;
            LayoutRoot.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            //Button bt;
            //bt = new Button();
            //bt.Content = "text";
            //bt.Width = bt.Height = 40;

            //BasicLibrary.EffectableControl ec = new BasicLibrary.EffectableControl(bt);
            //ec.Width = ec.Height = 40;
            //AddItem(ec);
           
            //bt = new Button();
            //bt.Content = "text";
            //bt.Width = bt.Height = 40;

            ////AddItem(new BasicLibrary.EffectableControl(bt));
            //AddItem(bt);
        }

        void control_OnListChange(string action, int index1, EffectableControl control, int index2)
        {
            switch (action)
            {
                case "ADD":
                    AddItem(control);
                    break;
                case "INSERT":
                    InsertItem(index1, control);
                    break;
                case "SWAP":
                    Swap(index1, index2);
                    break;
                case "REMOVEAT":
                    RemoveItemAt(index1);
                    break;
                case "REMOVE":
                    RemoveItem(control);
                    break;
                case "REMOVEALL":
                    RemoveAllItem();
                    break;
            }
        }

        private void MenuMacOS_MouseEnter(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition((FrameworkElement)sender);
            double rangeMin = mousePosition.X - 250;
            double rangeMax = mousePosition.X + 250;

            FrameworkElement thisElement = sender as FrameworkElement;

            for (int i = 0; i < LayoutRoot.Children.Count; i++)
            {
                GeneralTransform gt = LayoutRoot.Children[i].TransformToVisual(thisElement);
                Point offset = gt.Transform(new Point(0, 0));

                offset.X = offset.X + 20.0;
                offset.Y = offset.Y + 20.0;

                if (offset.X > rangeMin && offset.X < rangeMax)
                {
                    lstSDKFWidth[i].Value = lstSDKFHeight[i].Value = size + 88 * (Math.Sin(Math.PI * ((offset.X - rangeMin) / 500)));
                    lstStoryEnter[i].Begin();
                    //MarginAnimation.Begin();
                }
                else
                {
                    lstSDKFWidth[i].Value = lstSDKFHeight[i].Value = size;
                    lstStoryEnter[i].Begin();
                }
            }
        }

        private void MenuMacOS_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (Storyboard sb in lstStoryLeave)
                sb.Begin();
        }
    }
}
