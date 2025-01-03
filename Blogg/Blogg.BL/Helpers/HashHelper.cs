using System.Security.Cryptography;

namespace Blogg.BL.Helpers;

public static class HashHelper
{
    //public static byte[] ComputeSHA256(string value)
    //{
    //    string seed = "Phoenix";
    //    value = value.Reverse() + seed + value;
    //    using (SHA256 hash = SHA256.Create())
    //    {
    //        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
    //        return bytes;
    //    }
    //}

    public static string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer;
        if (password == null) throw new ArgumentNullException("password");
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        {
            salt = bytes.Salt;
            buffer = bytes.GetBytes(0x20);
        }
        byte[] dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }
}
