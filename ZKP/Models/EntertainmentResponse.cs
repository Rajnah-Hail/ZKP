using ZKP.Models;
using ZKP.ZKP;

namespace ZKP.Models
{
    public class EntertainmentResponse
    {
        public string PhoneNumber { get; set; }
        public bool IsAdult { get; set; }
        public ProofModel Proof { get; set; }

    }
}