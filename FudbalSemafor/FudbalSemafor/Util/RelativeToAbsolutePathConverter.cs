﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FudbalSemafor.Util
{
    public class RelativeToAbsolutePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string relativePath = value.ToString();

            // Dobijanje apsolutne putanje u root folderu projekta
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string absolutePath = Path.Combine(projectDirectory, relativePath);

            // Proverite da li fajl postoji na toj putanji
            if (File.Exists(absolutePath))
            {
                return absolutePath;
            }

            return null; // Ako fajl ne postoji, vraćamo null
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

