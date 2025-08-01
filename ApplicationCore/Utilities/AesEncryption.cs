using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AGL.Api.ApplicationCore.Utilities
{
    public interface IAesEncryption
    {
        Task<byte[]> Encrypt(string text);
        Task<string> Decrypt(byte[] cipherText);
        
        public byte[] EncryptNotAsync(string text);
        public string DecryptNotAsync(byte[] cipherText);
    }

    public class AesEncryption : IAesEncryption
    {
        // 설정에서 키 값을 로드
        private static byte[] _Aes_Key;

        public AesEncryption(IConfiguration configuration)
        {
            var ShaEnc = configuration.GetSection("Encryption");
            string Aes_Key = ShaEnc.GetValue<string>("Aes_Key");
            _Aes_Key = Encoding.UTF8.GetBytes(Aes_Key);
        }

        //// 설정 파일에서 키 값을 읽는 메소드
        //private static byte[] LoadKeyFromConfiguration()
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory()) // 현재 디렉토리 설정
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // 설정 파일 로드
        //        .Build();

        //    return Encoding.UTF8.GetBytes(configuration["Encryption:Aes_Key"]); // "Key"는 appsettings.json에서의 설정 키
        //}

        public async Task<byte[]> Encrypt(string text)
        {

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = _Aes_Key;
                aesAlg.IV = _Aes_Key;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        await Task.CompletedTask;
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        // AES 복호화
        public async Task<string> Decrypt(byte[] cipherText)
        {

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Mode = CipherMode.ECB;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.Key = _Aes_Key;
                    aesAlg.IV = _Aes_Key;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                await Task.CompletedTask;
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch { return cipherText == null ? "" : Encoding.Default.GetString(cipherText); }
        }
        
        public byte[] EncryptNotAsync(string text)
        {

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = _Aes_Key;
                aesAlg.IV = _Aes_Key;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        // AES 복호화
        public string DecryptNotAsync(byte[] cipherText)
        {

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Mode = CipherMode.ECB;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.Key = _Aes_Key;
                    aesAlg.IV = _Aes_Key;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch { return cipherText == null ? "" : Encoding.Default.GetString(cipherText); }
        }
        
        
    }
}
