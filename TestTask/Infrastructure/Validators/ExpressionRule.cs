using System.Globalization;
using System.Windows.Controls;

namespace TestTask.Ui.Infrastructure.Validators
{
    class ExpressionRule : ValidationRule
    {
        public int MaxLength { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var source = value.ToString();
            if (string.IsNullOrEmpty(source))
            {
                return new ValidationResult(false, "Need to fill field");
            }
            if (source.Length >= MaxLength)
            {
                return new ValidationResult(false, "Too long expression");
            }
            return new ValidationResult(true, null);
        }
    }
}