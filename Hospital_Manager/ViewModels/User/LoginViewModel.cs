using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name is reqired")]
        public string UserName
        {
            get; set;
        } = string.Empty;
        [Required(ErrorMessage = "Password is reqired")]
        public string Password
        {
            get; set;
        } = string.Empty;
        public bool RememberMe
        {
            get; set;
        } = false;
    }
}
