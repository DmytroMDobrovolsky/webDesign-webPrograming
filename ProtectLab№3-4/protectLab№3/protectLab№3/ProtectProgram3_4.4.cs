using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

class HashingForUsers
{
    static Dictionary<string, byte[]> BaseOfData = new Dictionary<string, byte[]>();

    static void Main()
    {
        int choose;

        do
        {
            Console.WriteLine("~~MENU~~");
            Console.WriteLine("1. Sign in!!!");
            Console.WriteLine("2. Log in!!!");
            Console.WriteLine("3. Removal!!!");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option---> ");

            if (!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            switch (choose)
            {
                case 1:
                    RegisterUser();
                    break;

                case 2:
                    AuthenticateUser();
                    break;

                case 3:
                    RemoveUser();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        } while (choose != 0);
    }

    static void RegisterUser()
    {
        Console.WriteLine("~~REGISTRATION~~~");
        Console.Write("Please, Enter login: ");
        string login = Console.ReadLine();

        if (BaseOfData.ContainsKey(login))
        {
            Console.WriteLine("Sorry!!! This login is already in use. Please choose a different one.");
            return;
        }

        Console.Write("Please, Enter password: ");
        string password = Console.ReadLine();
        byte[] passwordInByte = Encoding.UTF8.GetBytes(password);
        BaseOfData.Add(login, MD5Hmac(passwordInByte, Encoding.UTF8.GetBytes(login)));
        Console.WriteLine("You have been successfully registered!!!");
    }

    static void AuthenticateUser()
    {
        Console.WriteLine("~~AUTHORIZATION~~");
        Console.Write("Please, Enter login: ");
        string login = Console.ReadLine();

        if (!BaseOfData.ContainsKey(login))
        {
            Console.WriteLine("Sorry!!! This login was not found. Please register or check your login.");
            return;
        }

        Console.Write("Please, Enter password: ");
        string password = Console.ReadLine();
        byte[] passwordInByte = Encoding.UTF8.GetBytes(password);

        if (BaseOfData[login].SequenceEqual(MD5Hmac(passwordInByte, Encoding.UTF8.GetBytes(login))))
        {
            Console.WriteLine($"{login} - successfully authenticated!!!");
        }
        else
        {
            Console.WriteLine("Sorry!!! Your password is incorrect.");
        }
    }

    static void RemoveUser()
    {
        Console.WriteLine("~~REMOVAL USER~~~");
        Console.Write("Please, Enter login: ");
        string login = Console.ReadLine();

        if (BaseOfData.ContainsKey(login))
        {
            Console.Write("Please, Enter password: ");
            string password = Console.ReadLine();
            byte[] passwordInByte = Encoding.UTF8.GetBytes(password);

            if (BaseOfData[login].SequenceEqual(MD5Hmac(passwordInByte, Encoding.UTF8.GetBytes(login))))
            {
                Console.Write("Are you sure you want to remove your login and password? (y/n): ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    BaseOfData.Remove(login);
                    Console.WriteLine("Account was successfully removed!!!");
                }
                else
                {
                    Console.WriteLine("Account was not removed.");
                }
            }
            else
            {
                Console.WriteLine("Sorry!!! Your password is incorrect.");
            }
        }
        else
        {
            Console.WriteLine("Sorry!!! This login was not found.");
        }
    }

    public static byte[] MD5Hmac(byte[] data, byte[] key)
    {
        using (var md5 = new HMACMD5(key))
        {
            return md5.ComputeHash(data);
        }
    }
}