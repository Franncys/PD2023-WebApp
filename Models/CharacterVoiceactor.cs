using System;
using System.Collections.Generic;

namespace WebAppNarutoDB.Models;

public partial class CharacterVoiceactor
{
    public int IdCharacter { get; set; }

    public int IdActor { get; set; }

    public virtual Voiceactor IdActorNavigation { get; set; } = null!;

    public virtual Character IdCharacterNavigation { get; set; } = null!;
}
