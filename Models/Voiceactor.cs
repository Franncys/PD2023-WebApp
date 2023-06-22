using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class Voiceactor
{
    public int Id { get; set; }

    public string? ActorName { get; set; }

    public string? LanguageVersion { get; set; }
}
