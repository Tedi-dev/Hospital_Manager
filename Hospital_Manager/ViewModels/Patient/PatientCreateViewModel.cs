using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Parent
{
    public class PatientCreateViewModel
    {
        [Required, MaxLength(30)]
        public string FirstName
        {
            get; set;
        }
        [Required, MaxLength(30)]
        public string LastName
        {
            get; set;
        }
        [Required, EmailAddress]
        public string Email
        {
            get; set;
        }
        [Required, Phone]
        public string PhoneNumber
        {
            get; set;
        }
<<<<<<< HEAD
        public List<int> DoctorIDs { get; set; } = new List<int>();
=======
        public List<int> DoctorIds
        {
            get; set;
        } = new List<int>();
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
    }
}
