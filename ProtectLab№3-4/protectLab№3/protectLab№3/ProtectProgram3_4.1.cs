using System;
using System.Security.Cryptography;
using System.Text;

class hAshing
{
    static void Main()
    {
        Console.WriteLine("~Hash Method~");
        //MD5 method
        Console.WriteLine("1.MD5 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing1 = Console.ReadLine();

        var forString1 = HashMd5(Encoding.UTF8.GetBytes(fromUsing1));
        Guid guid1 = new Guid(forString1);

        Console.WriteLine($"String: {fromUsing1}");
        Console.WriteLine($"MD5: {Convert.ToBase64String(forString1)}");
        Console.WriteLine($"GUID: {guid1}");

        //SHA1 method
        Console.WriteLine("2.SHA1 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing2 = Console.ReadLine();

        var forString2 = HashSha1(Encoding.UTF8.GetBytes(fromUsing2));

        Console.WriteLine($"String: {fromUsing2}");
        Console.WriteLine($"SHA1: {Convert.ToBase64String(forString2)}");

        //SHA256 method
        Console.WriteLine("4.SHA256 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing4 = Console.ReadLine();

        var forString4 = HashSha256(Encoding.UTF8.GetBytes(fromUsing4));

        Console.WriteLine($"String: {fromUsing4}");
        Console.WriteLine($"SHA256: {Convert.ToBase64String(forString4)}");

        //SHA384 method
        Console.WriteLine("4.SHA384 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing3 = Console.ReadLine();

        var forString3 = HashSha384(Encoding.UTF8.GetBytes(fromUsing3));

        Console.WriteLine($"String: {fromUsing3}");
        Console.WriteLine($"SHA384: {Convert.ToBase64String(forString3)}");

        //SHA512 method
        Console.WriteLine("5.SHA512 method!!!");

        Console.WriteLine("Enter a string: ");
        string fromUsing5 = Console.ReadLine();

        var forString5 = HashSha512(Encoding.UTF8.GetBytes(fromUsing5));

        Console.WriteLine($"String: {fromUsing5}");
        Console.WriteLine($"SHA512: {Convert.ToBase64String(forString5)}");
    }

    public static byte[] HashMd5(byte[] data)
    {
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(data);
        }
    }
    public static byte[] HashSha1(byte[] data)
    {
        using (var sha1 = SHA1.Create())
        {
            return sha1.ComputeHash(data);
        }
    }

    public static byte[] HashSha256(byte[] data)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(data);
        }
    }

    public static byte[] HashSha384(byte[] data)
    {
        using (var sha384 = SHA384.Create())
        {
            return sha384.ComputeHash(data);
        }
    }

    public static byte[] HashSha512(byte[] data)
    {
        using (var sha512 = SHA512.Create())
        {
            return sha512.ComputeHash(data);
        }
    }

}
