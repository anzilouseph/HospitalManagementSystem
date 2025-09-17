using HMS.DTO;
using HMS.Utility;

namespace HMS.IRepo
{
    public interface IPatientManagementRepo
    {
        public Task<ApiHelper<bool>> PatientRegistration(PatientForCreationDto patient);
    }
}
