using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        var key = new byte[64];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }

        Console.WriteLine("~Hash Method~");
        //MD5 method
        Console.WriteLine("1.HMACMD5 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing1 = Console.ReadLine();

        var forString1 = MD5Hmac(Encoding.UTF8.GetBytes(fromUsing1), key);

        Console.WriteLine($"String: {fromUsing1}");
        Console.WriteLine($"HMAC-MD5: {Convert.ToBase64String(forString1)}");

        //SHA1 method
        Console.WriteLine("2.HMACSHA1 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing2 = Console.ReadLine();

        var forString2 = SHA1Hmac(Encoding.UTF8.GetBytes(fromUsing2), key);

        Console.WriteLine($"String: {fromUsing2}");
        Console.WriteLine($"HMAC-SHA1: {Convert.ToBase64String(forString2)}");

        //SHA256 method
        Console.WriteLine("3.HMACSHA256 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing3 = Console.ReadLine();

        var forString3 = SHA256Hmac(Encoding.UTF8.GetBytes(fromUsing3), key);

        Console.WriteLine($"String: {fromUsing3}");
        Console.WriteLine($"HMAC-SHA256: {Convert.ToBase64String(forString3)}");

        //SHA512 method
        Console.WriteLine("4.HMACSHA512 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing4 = Console.ReadLine();

        var forString4 = SHA256Hmac(Encoding.UTF8.GetBytes(fromUsing4), key);

        Console.WriteLine($"String: {fromUsing4}");
        Console.WriteLine($"HMAC-SHA512: {Convert.ToBase64String(forString4)}");

    }

    public static byte[] MD5Hmac(byte[] data, byte[] key)
    {
        using (var md5 = new HMACMD5(key))
        {
            return md5.ComputeHash(data);
        }
    }

    public static byte[] SHA1Hmac(byte[] data, byte[] key)
    {
        using (var sha1 = new HMACSHA1(key))
        {
            return sha1.ComputeHash(data);
        }
    }

    public static byte[] SHA256Hmac(byte[] data, byte[] key)
    {
        using (var sha256 = new HMACSHA256(key))
        {
            return sha256.ComputeHash(data);
        }
    }

    public static byte[] SHA512(byte[] data, byte[] key)
    {
        using (var sha512 = new HMACSHA512(key))
        {
            return sha512.ComputeHash(data);
        }
    }
}