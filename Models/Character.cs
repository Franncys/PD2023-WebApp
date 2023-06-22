using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class Character
{
    public int Id { get; set; }

    public string? CharName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Debut { get; set; }

    public string? PersonalDetail { get; set; }
}
