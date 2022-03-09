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

        using var aes = Aes.Create();
        aes.Key = _encryptKey;
        aes.IV = ciphertextBytes.Take(BlockSize).ToArray();
        aes.Mode = CipherMode.CBC;

        var decryptor = aes.CreateDecryptor();
        var blockBytes = decryptor.TransformFinalBlock(
            ciphertextBytes,
            BlockSize,
            ciphertextBytes.Length - BlockSize
        );

        return System.Text.Encoding.UTF8.GetString(blockBytes);
    }
}
