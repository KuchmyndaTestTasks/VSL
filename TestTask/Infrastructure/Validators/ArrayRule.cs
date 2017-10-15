using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace TestTask.Ui.Infrastructure.Validators
{
    class ArrayRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var source = value.ToString();
            try
            {
                if (string.IsNullOrEmpty(source))
                {
                    throw new Exception("Invalid Format");
                }

                Debug.Assert(source.Split(' ').Where(x => !string.IsNullOrEmpty(x))
                                 .Select(s => Convert.ToInt32(s.Replace(" ", "").Trim())) != null, "Array is null");
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return new ValidationResult(true, null);
        }
    }
}