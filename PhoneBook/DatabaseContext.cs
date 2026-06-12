using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

internal class ContactsContext : DbContext
{
    public DbSet<Contact> Contact { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)=> options.UseSqlite($"Data Source = PhoneBook.db");
}
