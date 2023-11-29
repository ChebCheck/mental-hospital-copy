﻿namespace MentalHospital.BLL.Tests.Data.Models
{
    internal static class PatientModelData
    {
        public static PatientModel InitPatientModel()
        {
            var patient = new PatientModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Tom",
                ChamberNumber = 1,
                RegistredAt = DateTime.Now
            };

            return patient;
        }

        public static List<PatientModel> InitPatientCollection() 
        { 
            return new List<PatientModel>() { InitPatientModel() }; 
        }
    }
}