using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppTreu2.Models
{
    public class FirstResponsiveWebAppModel
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")] //utilized https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.regularexpressionattribute?view=net-10.0
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a birth year.")]
        [Range(1900, 2026, ErrorMessage = "Birth year must be between 1900 and 2026.")]
        public int? BirthYear { get; set; }

        public int? AgeThisYear()
        {
            const int CurrentYear = 2026;
            if (BirthYear == null)
                return null;

            return CurrentYear - BirthYear;
        }

    }

}
