using System.Text;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Надайте довжину паролю:");
        int passwordLength = Convert.ToInt32(Console.ReadLine());

        string password = GenerateRandomPassword(passwordLength);
        Console.WriteLine("Згенерований пароль: " + password);
    }
    static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
        Random random = new Random();
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            password.Append(chars[index]);
        }

        return password.ToString();
    }
}
