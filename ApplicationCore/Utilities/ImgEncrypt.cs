using System.Security.Cryptography;
using System.Text;
using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AGL.Api.ApplicationCore.Utilities
{
    public class ImgEncrypt : IImgEncrypt
    {
        private readonly string _Sha256_Key;
        private readonly string _ImgUrlPath;

        public ImgEncrypt(IConfiguration configuration)
        {
            var ShaEnc = configuration.GetSection("Encryption");
            _Sha256_Key = ShaEnc.GetValue<string>("Sha256_Key") ?? "";
            _ImgUrlPath = ShaEnc.GetValue<string>("ImgUrl") ?? "";
        }

        public async Task<string> GetEncryptUrl(string ImgUrl)
        {
            //LoadKeyFromConfiguration();
            if (string.IsNullOrEmpty(ImgUrl)) return "";

            var plaintext = ImgUrl.Replace(@"\", "/").Replace("Uploads/Documents", "");

            var rst = string.Empty;

            try
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] keyBytes = Encoding.UTF8.GetBytes(_Sha256_Key);
                    byte[] iv = new byte[16];
                    byte[] hashBytes = sha256.ComputeHash(keyBytes);

                    StringBuilder hash = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        hash.Append(hashBytes[i].ToString("x2"));
                    }

                    iv = Encoding.UTF8.GetBytes(hash.ToString().Substring(0, 16));


                    // AES 암호화 설정
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = Encoding.UTF8.GetBytes(_Sha256_Key.PadRight(16).Substring(0, 16)); // 16바이트로 키 길이 조정
                        aesAlg.IV = iv;
                        aesAlg.Mode = CipherMode.CBC;
                        aesAlg.Padding = PaddingMode.PKCS7;

                        // 암호화 수행
                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(plaintext);
                                }
                            }

                            byte[] encrypted = msEncrypt.ToArray();

                            if (!string.IsNullOrEmpty(Convert.ToBase64String(encrypted)))
                                rst = $"{_ImgUrlPath}{Convert.ToBase64String(encrypted)}";
                        }
                    }
                }
            }
            catch { }

            await Task.CompletedTask;

            return rst;
        }
    }
}

