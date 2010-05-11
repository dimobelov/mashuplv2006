﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BasicLibrary
{
    public interface IBasic
    {
        string GetParameterNames();
        Type GetParameterType(string parameterName);
        object GetParameterValue(string parameterName);
        void SetParameterValue(string parameterName, object value);
    }
}