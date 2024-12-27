using System.Security.Cryptography;
using System.Text;

namespace Blogg.BL.Helpers;

public static class HashHelper
{
    public static byte[] ComputeSHA256(string value)
    {
        string seed = "Phoenix";
        value = value.Reverse() + seed + value;
        using (SHA256 hash = SHA256.Create())
        {
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            return bytes;
        }
    }
}
