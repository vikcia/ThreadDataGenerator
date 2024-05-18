using System.Globalization;
using System.Windows.Controls;

namespace ThreadDataGenerator.ValidationRules;

public class StringToIntValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        int i;
        if (!int.TryParse(value.ToString(), out i))
        {
            return new ValidationResult(false, "Please enter a valid integer value.");

        }
        if (i < 2 || i > 15)
        {
            return new ValidationResult(false, "Value mut be from 2 to 15");
        }
        return ValidationResult.ValidResult;
    }
}