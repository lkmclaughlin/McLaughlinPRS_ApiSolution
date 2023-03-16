using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McLaughlinPRS_Api.Models;

[Index("PartNbr", IsUnique = true)]
public class Product
{
    public int Id { get; set; }

    [StringLength(30)]
    public string PartNbr { get; set; } = string.Empty;

    [StringLength(30)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(11,2)")]
    public decimal Price { get; set; } 

    [StringLength(30)]
    public string Unit { get; set; } = string.Empty;

    [StringLength(100)]
    public string? PhotoPath { get; set; } = null;

    public int VendorId { get; set;}

    public virtual Vendor? Vendor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Requestline>? Requestlines { get; set; }

    public Product() { }
}   
