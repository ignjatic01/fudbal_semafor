using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Utakmica
{
    public int IdUtakmica { get; set; }

    public int Domaci { get; set; }

    public int Gosti { get; set; }

    public int? Stadion { get; set; }

    public int GoloviDomaci { get; set; }

    public int GoloviGosti { get; set; }

    public virtual Klub DomaciNavigation { get; set; } = null!;

    public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();

    public virtual Klub GostiNavigation { get; set; } = null!;

    public virtual ICollection<Izmjena> Izmjenas { get; set; } = new List<Izmjena>();

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();

    public virtual Stadion? StadionNavigation { get; set; }
}
