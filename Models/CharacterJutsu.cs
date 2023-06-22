using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class CharacterJutsu
{
    public int IdCharacter { get; set; }

    public int IdJutsu { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;

    public virtual Jutsu IdJutsuNavigation { get; set; } = null!;
}
