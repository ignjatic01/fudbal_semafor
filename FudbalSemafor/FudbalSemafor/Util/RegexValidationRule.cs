using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
                return new ValidationResult(false, "Field cannot be empty.");
            }

            string input = value.ToString();
            Regex regex = new Regex(Pattern);

            if (!regex.IsMatch(input))
            {
                return new ValidationResult(false, "Invalid input format.");
            }

            return ValidationResult.ValidResult;
        }

    }
}
