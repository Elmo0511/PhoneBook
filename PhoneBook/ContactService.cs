using System;
using Microsoft.EntityFrameworkCore.Update;
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
        Console.ReadKey();
        Console.Clear();
        ContactController.AddContact(contact);
    }
    public static void DeleteContact()
    {
        Contact? contact = GetContactOption();
        if(contact != null)
        {
            AnsiConsole.Markup("[green]Contact Removed[/]");
            Console.ReadKey();
            Console.Clear();
            ContactController.RemoveContact(contact);
        }
            
    }
    public static void UpdateContact()
    {
        Contact? contact = GetContactOption();
        if(contact != null)
        {
            string tmp;
            if (AnsiConsole.Confirm("Update name?"))
            {
                do
                {
                    tmp = AnsiConsole.Ask<string>("New Contact Name:");
                }while(!Validator.ValidateName(tmp));
                contact.name = tmp;
            }
            if (AnsiConsole.Confirm("Update email?"))
            {
                do
                {
                    tmp = AnsiConsole.Ask<string>("New Contact Email:");
                }while(!Validator.ValidateEmail(tmp));
                contact.email = tmp;
            }
            if (AnsiConsole.Confirm("Update phone number?"))
            {
                do
                {
                    tmp = AnsiConsole.Ask<string>("New Contact Phone Number:");
                }while(!Validator.ValidatePhoneNumber(tmp));
                contact.phoneNumber = tmp;
            }
            AnsiConsole.Markup("[green]Contact Updated[/]");
            Console.ReadKey();
            Console.Clear();
            ContactController.UpdateContact(contact);
        }
    }
    public static void ViewContact()
    {
        int id = AnsiConsole.Ask<int>("[blue]Insert Contact ID: [/]");
        Contact? contact = ContactController.GetContactByID(id);
        if(contact == null)
        {
            AnsiConsole.MarkupLine("[red]No contacts found![/]");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        var panel = new Panel($@"
        Id: {contact.contactId}
        Name: {contact.name}
        Email: {contact.email}
        Phone Number: {contact.phoneNumber}");
        panel.Header = new PanelHeader("[green]Contact Info[/]");
        AnsiConsole.Write(panel);
        Console.ReadKey();
        Console.Clear();
    }
    public static void ViewAllContacts()
    {
        List<Contact>? contacts = ContactController.GetContactList();
        if (contacts == null || contacts.Count() == 0)
        {
            AnsiConsole.MarkupLine("[red]No contacts found![/]");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        var table = new Table();

        table.AddColumn("[blue]ID[/]");
        table.AddColumn("[blue]Name[/]");
        table.AddColumn("[blue]Email[/]");
        table.AddColumn("[blue]Phone Number[/]");

        foreach(var c in contacts)
        {
            table.AddRow(c.contactId.ToString(),c.name,c.email,c.phoneNumber);
        }
        AnsiConsole.Write(table);
        Console.ReadKey();
        Console.Clear();
    }

    private static Contact? GetContactOption()
    {
        var contacts = ContactController.GetContactList();
        if (contacts == null || contacts.Count() == 0)
        {
            AnsiConsole.MarkupLine("[red]No contacts found![/]");
            Console.ReadKey();
            return null;
        }

        return AnsiConsole.Prompt(
        new SelectionPrompt<Contact>()
            .Title("[Blue]Select Contact:[/] ")
            .AddChoices(contacts));   
            
    }
}
