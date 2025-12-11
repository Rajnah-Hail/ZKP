using ZKP.Models;
using ZKP.ZKP;
namespace ZKP.Models
{
    public class HospitalResponse
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeGroup { get; set; }
        public ProofModel Proof { get; set; }

    }
}