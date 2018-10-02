using System.ComponentModel.DataAnnotations;

namespace JosenBug.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}