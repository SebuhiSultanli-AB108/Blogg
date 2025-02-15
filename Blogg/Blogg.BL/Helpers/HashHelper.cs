﻿using System.Security.Cryptography;

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
    private static bool ByteArraysEqual(byte[] b1, byte[] b2)
    {
        if (b1 == b2) return true;
        if (b1 == null || b2 == null) return false;
        if (b1.Length != b2.Length) return false;
        for (int i = 0; i < b1.Length; i++)
        {
            if (b1[i] != b2[i]) return false;
        }
        return true;
    }
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
    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
        byte[] buffer;
        if (hashedPassword == null) return false;
        if (password == null) throw new ArgumentNullException("password");
        byte[] src = Convert.FromBase64String(hashedPassword);
        if ((src.Length != 0x31) || (src[0] != 0)) return false;
        byte[] dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        byte[] newBuffer = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, newBuffer, 0, 0x20);
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
        {
            buffer = bytes.GetBytes(0x20);
        }
        return ByteArraysEqual(newBuffer, buffer);
    }
}