namespace MentalHospital.BLL.Models;

public class PatientModel
{
	public Guid Id { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }
	
	public string? LastName2 { get; set; }

	public string? Diagnosis { get; set; }

	public string? Therapy { get; set; }

	public int? ChamberNumber { get; set; }

	public DateTime RegisteredAt { get; set; }

	public DateTime UnregisteredAt { get; set; }

	public Guid? PersonalDoctorId { get; set; }

	public DoctorModel? PersonalDoctor { get; set; }

	public List<SessionModel> Sessions { get; set; } = new();
}
