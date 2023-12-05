﻿namespace MentalHospital.DAL.Entities
{
    public class Patient
    {
        public Guid Id {  get; set; }
        public string? Name { get; set; }
        public string? Diagnosis { get; set; }
        public string? Therapy { get; set; }
        public int ChamberNumber { get; set; }
        public DateTime RegistredAt { get; set; }
        public DateTime DeregistredAt { get; set; }

        public string? PersonalDoctor { get; set; }  //doctor entity is not created yet
        public int? PersonalDoctorId { get; set; }

        public List<DoctorPatient> DoctorPatients { get; set; } = new();

        public List<Doctor> Doctors { get; set; } = new();
    }
}
