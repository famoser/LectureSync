﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Famoser.Study.Presentation.Universal.Converters
{
    public class UriToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return new Uri(value as string);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}