using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class CharacterClan
{
    public int IdCharacter { get; set; }

    public int IdClan { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;

    public virtual Clan IdClanNavigation { get; set; } = null!;
}
