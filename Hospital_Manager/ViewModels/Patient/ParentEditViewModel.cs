using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.Parent
{
    public class ParentEditViewModel
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
        public List<int> DoctorIds
        {
            get; set;
        } = new List<int>();
    }
}
