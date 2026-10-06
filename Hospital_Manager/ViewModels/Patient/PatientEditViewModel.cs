using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Parent
{
    public class PatientEditViewModel
    {
        public int Id
        {
            get; set;
        }
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
        public string PhoneNumber
        {
            get; set;
        }
<<<<<<< HEAD:Hospital_Manager/ViewModels/Patient/PatientEditViewModel.cs
        public List<int> DoctorIDs { get; set; } = new List<int>();
=======
        public List<int> DoctorIds
        {
            get; set;
        } = new List<int>();
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8:Hospital_Manager/ViewModels/Patient/ParentEditViewModel.cs
    }
}
