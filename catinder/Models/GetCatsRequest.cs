using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using catinder.StaticData;

namespace catinder.Models
{
    public class GetCatsRequest: IValidatableObject
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string StateCode { get; set; }
        public int Page { get; set; } = 1;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var isInvalidStateCode = StateArray.States.Count(s => s.Abbreviations == StateCode) == 0;
            if (isInvalidStateCode)
            {
                results.Add(new ValidationResult("Must be a valid state code. Example: TX"));
            }
            return results;
        }
    }      
}