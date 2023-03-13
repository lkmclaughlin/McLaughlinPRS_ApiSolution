using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;

namespace McLaughlinPRS_Api.Models;

public class Request
{
    public int Id { get; set; }

    [StringLength(80)]
    public string Description { get; set; } = string.Empty;

    [StringLength(80)]
    public string Justification { get; set; } = string.Empty;

    [StringLength(80)]
    public string? RejectionReason { get; set; } = null;

    [StringLength(20)]
    public string DeliveryMode { get; set; } = "Pickup";

    [StringLength(10)]
    private string Status { get; set; } = "NEW";

    [Column(TypeName = "decimal(11,2)")]
    private decimal Total { get; set; } = 0;

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public virtual ICollection<Requestline>? Requestlines { get; set; }
}
