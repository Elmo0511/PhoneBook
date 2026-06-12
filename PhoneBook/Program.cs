using System;
using PhoneBook;
using Spectre.Console;

partial class Program
{
    enum Options
    {
        AddContact,
        DeleteContact,
        UpdateContact,
        ViewContact,
        ViewAllContacts,
        Quit
    }
    static void Main()
    {

        bool running = true;
        while (running)
        {
            Console.Clear();
            var choice= AnsiConsole.Prompt(
                new SelectionPrompt<Options>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        Options.AddContact,
                        Options.DeleteContact,
                        Options.UpdateContact,
                        Options.ViewContact,
                        Options.ViewAllContacts,
                        Options.Quit));
            
            switch (choice)
            {
                case Options.AddContact:
                    ContactService.AddContact();
                    break;
                case Options.DeleteContact:
                    ContactService.DeleteContact();
                    break;
                case Options.UpdateContact:
                    ContactService.UpdateContact();
                    break;
                case Options.ViewContact:
                    ContactService.ViewContact();
                    break;
                case Options.ViewAllContacts:
                    ContactService.ViewAllContacts();
                    break;
                case Options.Quit:
                    AnsiConsole.Markup("[Blue]Closing application[/]");
                    Console.ReadKey();
                    running = false;
                    break;

            }            
        }
  
    }
}