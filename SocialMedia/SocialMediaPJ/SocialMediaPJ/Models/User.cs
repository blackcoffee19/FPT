using System;
using System.Collections.Generic;

namespace SocialMediaPJ.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime Dob { get; set; }

    public string? Bio { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
}
