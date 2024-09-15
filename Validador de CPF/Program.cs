using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter a CPF in the format (xxx.xxx.xxx-xx): ");
        string? cpfInput = Console.ReadLine();

        if (IsCpfValid(cpfInput))
            Console.WriteLine("CPF is valid.");
        else
            Console.WriteLine("CPF is invalid.");
    }

    static bool IsCpfValid(string? cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            Console.WriteLine("Invalid CPF!");
            return false;
        }

        StringBuilder formattedCpf = new();
        foreach (var character in cpf)
        {
            if (char.IsDigit(character))
                formattedCpf.Append(character);
        }

        if (formattedCpf.Length != 11)
            return false;

        char[] cpfArray = formattedCpf.ToString().ToCharArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (cpfArray[i] - '0') * (10 - i);
        }
        int firstDigit = sum % 11 < 2 ? 0 : 11 - sum % 11;

        if (firstDigit != cpfArray[9] - '0')
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += (cpfArray[i] - '0') * (11 - i);
        }
        int secondDigit = sum % 11 < 2 ? 0 : 11 - sum % 11;

        if (secondDigit != cpfArray[10] - '0')
            return false;

        return true;
    }
}