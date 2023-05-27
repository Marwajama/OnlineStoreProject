using System.ComponentModel.DataAnnotations;

namespace OnlineStoreProject.DTO
{
    public class ForgetPasswordDTO
    {
        [Required(ErrorMessage = "UserName Nme Is Requierd For Restore Password")]
        [RegularExpression("[A-Za-z-0-9]{3,}", ErrorMessage = "Password Formate Is Invalide User Name Must Contain Letters And Number Only")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="New Passwod Is Requierd Filde")]
        [RegularExpression("?=.{8,}",ErrorMessage ="Password Formate Is Invalide")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "New Passwod Is Requierd Filde")]
        [RegularExpression("?=.{8,}", ErrorMessage = "Password Formate Is Invalide")]
        public string confirmPassword { get; set; }
    }
}
