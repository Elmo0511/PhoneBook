using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook;

public class Contact
{
    [Key]
    public int contactId { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string phoneNumber { get; set; }

    public override string ToString()
    {
        return $"{name} - {email}";
    }

}
