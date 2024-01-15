namespace MentalHospital.BLL.Services;

public class PatientService : GenericService<PatientModel, Patient>, IPatientService
{
	public PatientService(IPatientRepository repository, IMapper mapper) : base (repository, mapper)
	{
	}
}