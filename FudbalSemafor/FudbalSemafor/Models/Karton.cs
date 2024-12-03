using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Karton
{
    public int IdKarton { get; set; }

    public int KartonTip { get; set; }

    public int Igrac { get; set; }

    public int Utakmica { get; set; }

    public int Minut { get; set; }

    public virtual Igrac IgracNavigation { get; set; } = null!;

    public virtual KartonTip KartonTipNavigation { get; set; } = null!;

    public virtual Utakmica UtakmicaNavigation { get; set; } = null!;
}
