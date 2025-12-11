using Microsoft.AspNetCore.Mvc;
using ZKP.ZKP;

[ApiController]
[Route("api/[controller]")]
public class VerifierController : ControllerBase
{
    private readonly ZKPService _zkpService;

    public VerifierController()
    {
        _zkpService = new ZKPService();
    }

    [HttpPost("verify-proof")]
    public IActionResult VerifyProof([FromBody] ProofVerificationRequest request)
    {
        var proof = new ProofModel
        {
            Hash = request.ProofHash,
            Salt = request.Salt
        };

        bool isValid = _zkpService.VerifyProof(request.SecretData, proof);
        proof.Verified = isValid;

        return Ok(new
        {
            request.SecretData,
            request.ProofHash,
            verified = isValid
        });
    }
}

public class ProofVerificationRequest
{
    public string SecretData { get; set; }
    public string ProofHash { get; set; }
    public string Salt { get; set; }
}