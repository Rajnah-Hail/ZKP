using ZKP.Models;

namespace ZKP.Services
{
    public interface IHospitalService
    {
        HospitalResponse GetPatientInfo(string phoneNumber);
        
    }
}