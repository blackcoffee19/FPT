using System;
using System.Collections.Generic;

namespace SocialMediaPJ.Models;

public partial class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime PostAt { get; set; }

    public string TextPost { get; set; } = null!;

    public string Options { get; set; } = null!;

    public DateTime? EditedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

    public virtual User User { get; set; } = null!;
}
