using System;
using System.Security.Cryptography;
using System.Text;

namespace ZKP.ZKP
{
    public class ZKPService
    {
        // توليد Salt عشوائي
        public string GenerateSalt(int size = 16)
        {
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        // توليد Proof مع Salt
        public ProofModel GenerateProof(string secretData, string salt = null)
        {
            if (salt == null)
                salt = GenerateSalt();

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(secretData + salt);
            var hash = sha256.ComputeHash(bytes);
            var hashString = BitConverter.ToString(hash).Replace("-", "");

            return new ProofModel
            {
                Hash = hashString,
                Salt = salt,
                Verified = false
            };
        }

        // التحقق من Proof
        public bool VerifyProof(string secretData, ProofModel proof)
        {
            if(proof==null||string.IsNullOrEmpty(proof.Hash)||string.IsNullOrEmpty(proof.Salt))
                return false;   

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(secretData + proof.Salt);
            var hash = sha256.ComputeHash(bytes);
            var hashString = BitConverter.ToString(hash).Replace("-", "");

            return proof.Hash == hashString;
        }
    }

}