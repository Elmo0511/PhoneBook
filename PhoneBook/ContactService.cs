using System;
using Spectre.Console;

namespace PhoneBook;

public class ContactService
{
    public static void AddContact()
    {
        Contact contact = new Contact();
        string tmp;
        do
        {
            tmp = AnsiConsole.Ask<string>("Name:");
        }while(!Validator.ValidateName(tmp));
        contact.name = tmp;
        do
        {
            tmp = AnsiConsole.Ask<string>("Email:");
        }while(!Validator.ValidateEmail(tmp));
        contact.email = tmp;
        do
        {
            tmp = AnsiConsole.Ask<string>("Phone Number:");
        }while(!Validator.ValidatePhoneNumber(tmp));
        contact.phoneNumber = tmp;

        AnsiConsole.Markup("[green]Contact Added[/]");
        ContactController.AddContact(contact);
    }
    public static void DeleteContact()
    {
        Contact? contact = GetContactOption();
        if(contact != null)
        {
            AnsiConsole.Markup("[green]Contact Removed[/]");
            ContactController.RemoveContact(contact);
        }
            
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

    private static Contact? GetContactOption()
    {
        var contacts = ContactController.GetContactList();
        if (contacts == null || contacts.Count() == 0)
        {
            AnsiConsole.MarkupLine("[red]No contacts found![/]");
            return null;
        }

        return AnsiConsole.Prompt(
        new SelectionPrompt<Contact>()
            .Title("[Blue]Select Contact:[/] ")
            .AddChoices(contacts));       
    }
}
