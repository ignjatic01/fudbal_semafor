using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Izmjena
{
    public int IdIzmjena { get; set; }

    public int IgracUlazi { get; set; }

    public int IgracIzlazi { get; set; }

    public int Utakmica { get; set; }

    public int Minut { get; set; }

    public virtual Igrac IgracIzlaziNavigation { get; set; } = null!;

    public virtual Igrac IgracUlaziNavigation { get; set; } = null!;

    public virtual Utakmica UtakmicaNavigation { get; set; } = null!;
}
