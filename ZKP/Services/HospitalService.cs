using System.Linq;
using ZKP.Services;
using ZKP.TestData;
using ZKP.ZKP;
using ZKP.Models;

public class HospitalService : IHospitalService
{
    private readonly ZKPService _zkpService;

    public HospitalService()
    {
        _zkpService = new ZKPService();
    }

    public HospitalResponse GetPatientInfo(string phoneNumber)
    {
        // البحث عن المستخدم التجريبي
        var user = TestData.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);


        ProofModel proof;
        if (user != null)
        {
            proof = _zkpService.GenerateProof(user.AgeGroup);
            proof.Verified = _zkpService.VerifyProof(user.AgeGroup, proof);
            
        }
        else
        {
            // أي رقم غير موجود → لا نولد Proof صالح
            proof = new ProofModel
            {
                Hash = null,
                Salt = null,
                Verified = false
            };
        }

      

        return new HospitalResponse
        {
            PhoneNumber = phoneNumber,
            FirstName = user?.firstName ?? "Unknown",
            LastName = user?.LastName ?? "Unknown",
            AgeGroup = user?.AgeGroup ?? "Unknown",
            Proof = proof
        };
    }
}
