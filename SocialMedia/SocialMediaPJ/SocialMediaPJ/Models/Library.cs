using System;
using System.Collections.Generic;

namespace SocialMediaPJ.Models;

public partial class Library
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? PostId { get; set; }

    public string? Image { get; set; }

    public DateTime Date { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User User { get; set; } = null!;
}
