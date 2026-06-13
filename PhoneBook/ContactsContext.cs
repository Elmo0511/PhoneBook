using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

internal class ContactsContext : DbContext
{
    public DbSet<Contact> Contact { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)=> options.UseSqlite($"Data Source={Path.Combine(AppContext.BaseDirectory, "PhoneBookDB.db")}");
}
//options.UseSqlite($"Data Source={Path.Combine(AppContext.BaseDirectory, "PhoneBookDB.db")}");
//options.UseSqlite($"Data Source = bin\\Debug\\net10.0\\PhoneBookDB.db");