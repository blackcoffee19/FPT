using System;
using System.Collections.Generic;

namespace SocialMediaPJ.Models;

public partial class Reaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public int TypeReaction { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
