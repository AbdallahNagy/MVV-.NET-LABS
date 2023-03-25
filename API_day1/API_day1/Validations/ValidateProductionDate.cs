using System.ComponentModel.DataAnnotations;

namespace API_day1;

public class ValidateProductionDate: ValidationAttribute
{
    public override bool IsValid(object? value)
        => value is DateTime date && date <= DateTime.Now;
}
