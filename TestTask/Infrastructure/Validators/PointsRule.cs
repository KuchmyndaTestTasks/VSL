using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace TestTask.Ui.Infrastructure.Validators
{
    class PointsRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var source = value.ToString();
            if (string.IsNullOrEmpty(source))
            {
                return new ValidationResult(false, "InvalidInput");
            }
            var splited = source.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (var s in splited)
            {
                var _char = s[0];
                var _digit = s[1];
                if (!char.IsLetter(_char) || !char.IsDigit(_digit))
                {
                    continue;
                }
                var digit = Char.GetNumericValue(_digit);
                if (digit >= 1 && digit <= 8 && _char >= 97 && _char <= 104)
                {
                    continue;
                }
                return new ValidationResult(false, "Characters: a-h; Digits: 1-8");
            }
            if (splited.Length < 2)
            {
                return new ValidationResult(false, "Need 2 points.");
            }
            return new ValidationResult(true, null);
        }
    }
}