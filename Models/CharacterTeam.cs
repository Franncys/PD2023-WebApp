using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class CharacterTeam
{
    public int IdCharacter { get; set; }

    public int IdTeam { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;

    public virtual Team IdTeamNavigation { get; set; } = null!;
}
