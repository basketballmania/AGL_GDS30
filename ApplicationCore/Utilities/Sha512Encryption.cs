using System.Security.Cryptography;
using System.Text;
using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AGL.Api.ApplicationCore.Utilities
{
    public class Sha512Hashing : ISha512Hashing
    {
        private readonly string _Sha512_Key;

        public Sha512Hashing(IConfiguration configuration)
        {
            var ShaEnc = configuration.GetSection("Encryption");
            _Sha512_Key = ShaEnc.GetValue<string>("Sha512_Key") ?? "";
        }

        // SHA512 해시 함수
        public async Task<string> ComputeSha512Hash(string text)
        {
            // 입력 문자열과 키를 결합
            string dataToHash = text + _Sha512_Key;

            using (SHA512 sha512Hash = SHA512.Create())
            {
                // 결합된 문자열을 바이트 배열로 인코딩
                byte[] sourceBytes = Encoding.UTF8.GetBytes(dataToHash);

                // 해시 계산
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);

                // 바이트 배열을 HEX 문자열로 변환
                StringBuilder hash = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hash.Append(hashBytes[i].ToString("x2"));
                }

                await Task.CompletedTask;

                return hash.ToString();
            }
        }
    }
}
