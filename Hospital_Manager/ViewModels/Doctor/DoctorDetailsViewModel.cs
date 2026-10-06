namespace Hospital_Manager.ViewModels.Doctor
{
    public class DoctorDetailsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialty { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

<<<<<<< HEAD
        public List<string> Patients
        {
            get; set;
        } = new List<string>();
=======
        public string HospitalName { get; set; }
        public List<string> Patients { get; set; } = new List<string>();
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
    }
}
