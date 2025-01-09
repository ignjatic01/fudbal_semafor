using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FudbalSemafor.Util
{
    public class RegexValidationRule : ValidationRule
    {
        public string Pattern { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                string emptyFieldMessage = (string)Application.Current.Resources["FieldCannotBeEmpty"];
                return new ValidationResult(false, emptyFieldMessage);
            }

            string input = value.ToString();
            Regex regex = new Regex(Pattern);

            if (!regex.IsMatch(input))
            {
                string invalidInputMessage = (string)Application.Current.Resources["InvalidInputFormat"];
                return new ValidationResult(false, invalidInputMessage);
            }

            return ValidationResult.ValidResult;
        }

    }
}
