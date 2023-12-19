﻿using System;
using System.IO;
using System.Security.Cryptography;

internal static class TripleDesEncryption
{
    // Генерація випадкового масиву байтів заданої довжини за допомогою RNGCryptoServiceProvider
    private static byte[] GenerateRandom(int length)
    {
        using (var randomNumberGenerator = new RNGCryptoServiceProvider())
        {
            var randomBytes = new byte[length];
            randomNumberGenerator.GetBytes(randomBytes);
            return randomBytes;
        }
    }

    private static byte[] key;
    private static byte[] desiv;

    // Ініціалізація ключа та IV TripleDES за допомогою ключового та IV повідомлення
    public static void Init(byte[] keymsg, byte[] ivmsg)
    {
        key = RfcHashing(keymsg, 24);
        desiv = RfcHashing(ivmsg, 8);
    }

    // Виконання ключової функції похідного RFC2898 для генерації хешованого ключа
    private static byte[] RfcHashing(byte[] key, int length)
    {
        using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, GenerateRandom(32), 190000))
        {
            return rfc.GetBytes(length);
        }
    }

    // Розшифрування повідомлення за допомогою шифрування TripleDES
    public static byte[] Decrypt(byte[] message)
    {
        using (var des = TripleDES.Create())
        {
            des.IV = desiv;
            des.Key = key;
            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(message);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }
    }

    // Шифрування повідомлення за допомогою шифрування TripleDES
    public static byte[] Encrypt(byte[] message)
    {
        using (var des = TripleDES.Create())
        {
            des.IV = desiv;
            des.Key = key;
            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(message);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }
    }
}