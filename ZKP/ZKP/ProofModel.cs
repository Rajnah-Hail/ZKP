namespace ZKP.ZKP
{
    public class ProofModel
    {
        public string Hash { get; set; }
        public string Salt { get; set; }    // مهم للتحقق
        public bool Verified { get; set; }
    }
}