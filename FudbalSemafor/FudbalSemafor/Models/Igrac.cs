using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Igrac
{
    public int IdIgrac { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public int BrojDresa { get; set; }

    public int Klub { get; set; }

    public string Pozicija { get; set; } = null!;

    public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();

    public virtual ICollection<Izmjena> IzmjenaIgracIzlaziNavigations { get; set; } = new List<Izmjena>();

    public virtual ICollection<Izmjena> IzmjenaIgracUlaziNavigations { get; set; } = new List<Izmjena>();

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();

    public virtual Klub KlubNavigation { get; set; } = null!;

    public virtual Pozicija PozicijaNavigation { get; set; } = null!;
}
