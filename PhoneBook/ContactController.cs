using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

public class ContactController
{
    public static void AddContact(Contact contact)
    {
        using var db = new ContactsContext();

        db.Add(contact);

        db.SaveChanges();
    }

    public static void RemoveContact (Contact contact)
    {
        using var db = new ContactsContext();

        db.Remove(contact);

        db.SaveChanges();
    }


    public static List<Contact>? GetContactList()
    {
        using var db = new ContactsContext();

        return db.Contact.ToList();
        
    }

    public static Contact? GetContactByID(int id)
    {
        using var db = new ContactsContext();

        return db.Contact.Where(c => c.contactId == id).FirstOrDefault();
    }

    public static void UpdateContact(Contact contact)
    {
        using var db = new ContactsContext();

        db.Update(contact);

        db.SaveChanges();
    }
}
