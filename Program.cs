using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Генерація псевдовипадкових чисел!");
        Random random1 = new Random();
        Console.WriteLine("Будь-ласка, введіть кількість чисел, яку ви хочете отримати!!!");
        int count1 = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Набір псевдовипадкових чисел");
        RandomGenerateCrypto(random1, count1);

    }

    static void RandomGenerateCrypto(Random random, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int random1 = random.Next(10, 20);

            Console.WriteLine(random1);
        }
    }




}
