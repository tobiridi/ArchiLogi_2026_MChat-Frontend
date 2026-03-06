using System.ComponentModel.DataAnnotations;

namespace MChat.Client.Models.Authentication
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Une adresse email est requise.")]
        [EmailAddress(ErrorMessage = "L'adresse email est invalide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Un mot de passe est requis.")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
