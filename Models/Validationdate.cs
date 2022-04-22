using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace weddingPlanner.Models
{
    public class ValidateWeddingDateAttribute: ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.UtcNow;
        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return val > _minValue;
        }
        public override string FormatErrorMessage(string dateError)
        {
            return string.Format(ErrorMessage);
        }
    }
}