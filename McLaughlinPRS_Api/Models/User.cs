using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace McLaughlinPRS_Api.Models;

[Index("Username", IsUnique = true)]
public class User
{
    public int Id { get; set; }

    [StringLength(20)]
    public string Username { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [StringLength(30)]
    public string Password { get; set; } = string.Empty;

    [StringLength(30)] 
    public string FirstName { get; set; } = string.Empty;

    [StringLength(30)] 
    public string LastName { get; set; } = string.Empty;

    [StringLength(12)]
    public string? Phone { get; set; } = null;

    [StringLength(100)]
    public string? Email { get; set; } = null;

    public bool IsReviewer { get; set; }

    public bool IsAdmin { get; set; }

    public User() { }
} 
