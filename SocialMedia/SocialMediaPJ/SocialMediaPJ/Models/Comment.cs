using System;
using System.Collections.Generic;

namespace SocialMediaPJ.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public DateTime PostCmt { get; set; }

    public string Comment1 { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
