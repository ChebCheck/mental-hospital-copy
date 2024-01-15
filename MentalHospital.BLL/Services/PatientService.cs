namespace MentalHospital.BLL.Services;

public class PatientService : GenericService<PatientModel, Patient>, IPatientService
{
    private readonly IGenericRepository<Patient> _repository;
    private readonly IMapper _mapper;
    public PatientService(IPatientRepository repository, IMapper mapper) : base (repository, mapper)
	{
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<PatientModel> Create(PatientModel model)
    {
        Patient entity = null;

        if (model.FirstName != "tom")
            entity = await _repository.Create(_mapper.Map<Patient>(model));
        return _mapper.Map<PatientModel>(entity);
    }
}