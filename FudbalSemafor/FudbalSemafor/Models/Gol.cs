using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Gol
{
    public int IdGol { get; set; }

    public int Utakmica { get; set; }

    public int Klub { get; set; }

    public int Igrac { get; set; }

    public int Minut { get; set; }

    public virtual Igrac IgracNavigation { get; set; } = null!;

    public virtual Klub KlubNavigation { get; set; } = null!;

    public virtual Utakmica UtakmicaNavigation { get; set; } = null!;
}
