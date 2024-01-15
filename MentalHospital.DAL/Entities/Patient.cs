namespace MentalHospital.DAL.Entities;

public class Patient : Entity
{
	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? Diagnosis { get; set; }

	public string? Therapy { get; set; }

	public int? ChamberNumber { get; set; }

	public DateTime RegisteredAt { get; set; }

	public DateTime UnregisteredAt { get; set; }

	public Guid? PersonalDoctorId { get; set; }

	public Doctor? PersonalDoctor { get; set; }

	public List<Session> Sessions { get; set; } = new();
}