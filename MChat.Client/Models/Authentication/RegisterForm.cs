using System.ComponentModel.DataAnnotations;

namespace MChat.Client.Models.Authentication
{
    public class RegisterForm
    {
        [Required(ErrorMessage = "Une adresse email est requise.")]
        [EmailAddress(ErrorMessage = "L'adresse email est invalide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Un mot de passe est requis.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Une confirmation du mot de passe est requise.")]
        [Compare("Password", ErrorMessage = "Les mot de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Un nom d'utilisateur est requis.")]
        [MinLength(3, ErrorMessage = "Le nom d'utilisateur doit contenir au moins 3 caractères.")]
        public string Username { get; set; } = string.Empty;

    }
}
