using MentalHospital.BLL.Interfaces;

namespace MentalHospital.BLL.Tests;

public class PatientServiceTest
{
	private readonly GenericService<PatientModel, Patient> patientService;
	private readonly Mock<IPatientRepository> mockPatientRepository;

	public PatientServiceTest()
	{
		var mockMapper = new Mock<IMapper>();
		mockPatientRepository = new Mock<IPatientRepository>();

		mockMapper.Setup(mp => mp.Map<PatientModel>(It.IsAny<Patient>())).Returns(PatientModelData.InitPatientModel());
		mockMapper.Setup(mp => mp.Map<IEnumerable<PatientModel>>(It.IsAny<IEnumerable<Patient>>())).Returns(PatientModelData.InitPatientCollection());
		mockMapper.Setup(mp => mp.Map<Patient>(It.IsAny<PatientModel>())).Returns(PatientEntityData.InitPatientEntity());

		patientService = new GenericService<PatientModel, Patient>(mockPatientRepository.Object, mockMapper.Object);
	}

	[Fact]
	public async Task Creaate_InputPatientModel_ReturnExpectedModel()
	{
		var patientModel = PatientModelData.InitPatientModel();
		mockPatientRepository.Setup(rep => rep.Create(It.IsAny<Patient>()))
			.ReturnsAsync(PatientEntityData.InitPatientEntity());

		var result = await patientService.Create(patientModel);

		mockPatientRepository.Verify(rep => rep.Create(It.IsAny<Patient>()));
		result.FirstName.ShouldBeEquivalentTo(patientModel.FirstName);
	}

	[Fact]
	public async Task Delete_InputPatientModel_ReturnExpectedModel()
	{
		mockPatientRepository.Setup(rep => rep.Delete(It.IsAny<Guid>()))
			.ReturnsAsync(PatientEntityData.InitPatientEntity());

		var result = await patientService.Delete(Guid.NewGuid());

		mockPatientRepository.Verify(rep => rep.Delete(It.IsAny<Guid>()));
		result.FirstName.ShouldBeEquivalentTo(PatientModelData.InitPatientModel().FirstName);
	}

	[Fact]
	public async Task Get_InputSomeString_ReturnExpectedModel()
	{
		mockPatientRepository.Setup(rep => rep.Get(It.IsAny<Guid>()))
			.ReturnsAsync(PatientEntityData.InitPatientEntity());

		var result = await patientService.Get(Guid.NewGuid());

		mockPatientRepository.Verify(rep => rep.Get(It.IsAny<Guid>()));
		result.FirstName.ShouldBeEquivalentTo(PatientModelData.InitPatientModel().FirstName);
	}

	[Fact]
	public async Task GetAll_CommonInvoking_NotEmptyList()
	{
		var patientModel = PatientModelData.InitPatientModel();
		mockPatientRepository.Setup(rep => rep.GetAll())
			.ReturnsAsync(PatientEntityData.InitPatientCollection());

		var result = await patientService.GetAll();

		mockPatientRepository.Verify(rep => rep.GetAll());
		result.FirstOrDefault(p => p.FirstName == patientModel.FirstName).ShouldNotBeNull();
	}

	[Fact]
	public async Task Update_InputPatientModel_ReturnExpectedModel()
	{
		var patientModel = PatientModelData.InitPatientModel();
		mockPatientRepository.Setup(rep => rep.Update(It.IsAny<Patient>()))
			.ReturnsAsync(PatientEntityData.InitPatientEntity());

		var result = await patientService.Update(patientModel);

		mockPatientRepository.Verify(rep => rep.Update(It.IsAny<Patient>()));
		result.FirstName.ShouldBeEquivalentTo(patientModel.FirstName);
	}
}