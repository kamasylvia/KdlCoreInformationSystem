using System.Security.Cryptography;
using System.Text;

namespace LarkApiGateway.Utils;

public class AESCipher
{
    const int BlockSize = 16;
    private byte[] _encryptKey;

    public AESCipher(string encryptKey)
    {
        _encryptKey = SHA256Hash(encryptKey);
    }

    public static byte[] SHA256Hash(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        var shaManaged = new SHA256Managed();
        return shaManaged.ComputeHash(bytes);
    }

    public string DecryptString(string ciphertext)
    {
        var ciphertextBytes = Convert.FromBase64String(ciphertext);

        // Aes
        using var aes = Aes.Create();
        aes.Key = _encryptKey;
        aes.IV = ciphertextBytes.Take(BlockSize).ToArray();
        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var msDecrypt = new MemoryStream(ciphertextBytes);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        var plaintext = srDecrypt.ReadToEnd();
        return plaintext;

        // RijndaelManaged
        var rijndaelManaged = new RijndaelManaged();
        rijndaelManaged.Key = this._encryptKey;
        rijndaelManaged.Mode = CipherMode.CBC;
        rijndaelManaged.IV = ciphertextBytes.Take(BlockSize).ToArray();
        var transform = rijndaelManaged.CreateDecryptor();
        var blockBytes = transform.TransformFinalBlock(
            ciphertextBytes,
            BlockSize,
            ciphertextBytes.Length - BlockSize
        );
        return System.Text.Encoding.UTF8.GetString(blockBytes);
    }
}
