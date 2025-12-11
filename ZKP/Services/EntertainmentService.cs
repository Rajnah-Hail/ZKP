using System.Linq;
using ZKP.Models;
using ZKP.Services;
using ZKP.TestData;
using ZKP.ZKP;


public class EntertainmentService : IEntertainmentService
{
    private readonly ZKPService _zkpService;

    public EntertainmentService()
    {
        _zkpService = new ZKPService();
    }

    public EntertainmentResponse CheckIfAdult(string phoneNumber)
    {
        var user = TestData.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);

        ProofModel proof;
        bool isAdult = false;

        if (user != null)
        {
            isAdult = user.IsAdult;
            proof = _zkpService.GenerateProof(isAdult.ToString());
            proof.Verified = _zkpService.VerifyProof(isAdult.ToString(), proof);
        }
        else
        {
            proof = new ProofModel
            {
                Hash = null,
                Salt = null,
                Verified = false
            };
        }

        return new EntertainmentResponse
        {
            PhoneNumber = phoneNumber,
            IsAdult = isAdult,
            Proof = proof
        };
    }
}
