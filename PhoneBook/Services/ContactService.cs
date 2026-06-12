using System;
using Spectre.Console;

namespace PhoneBook;

public class ContactService
{
    public static void AddContact()
    {
        Contact contact = new Contact();
        contact.name = AnsiConsole.Ask<string>("Name:");
        contact.email = AnsiConsole.Ask<string>("Email:");
        contact.phoneNumber = AnsiConsole.Ask<string>("PhoneNumber:");

        //insert Contact in database
    }
    public static void DeleteContact()
    {
        
    }
    public static void UpdateContact()
    {
        
    }
    public static void ViewContact()
    {
        
    }
    public static void ViewAllContacts()
    {
        
    }
}
