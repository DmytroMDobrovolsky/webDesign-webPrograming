using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordRecovery
{
    public static void Main()
    {
        string hash = "po1MVkAE7IjUUwu61XxgNg==";
        byte[] HASH = Convert.FromBase64String(hash);
        string password;

        for (int i = 0; i <= 99999999; i++)
        {
            password = Convert.ToString(i);

            if (Enumerable.SequenceEqual(MD5Hash(Encoding.Unicode.GetBytes(password)), HASH))
            {
                Console.WriteLine($"Password is: {password}");
                break;
            }
        }
    }

    public static byte[] MD5Hash(byte[] data)
    {
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(data);
        }
    }
}