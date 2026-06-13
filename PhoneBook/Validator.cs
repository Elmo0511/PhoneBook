using System;
using Spectre.Console;
using System.Net.Mail;

namespace PhoneBook;

public class Validator
{
    
    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        return false;

        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            AnsiConsole.Markup("[Red] Invalid Email[/] Format: <youremailname@provider.domain>");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }

    public static bool ValidateName(string tmp)
    {
        if (tmp.All(Char.IsLetter))
            return true;
        else
        {
            AnsiConsole.Markup("[Red] Invalid Name[/] Press a key to try again");
            Console.ReadKey();
            Console.Clear();
            return false;
        }

    }

    public static bool ValidatePhoneNumber(string tmp)
    {
        if (tmp.Length==10 && tmp.All(Char.IsDigit))
            return true;
        else
        {
            AnsiConsole.Markup("[Red] Invalid Phone Number[/] Press a key to try again");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }


}
