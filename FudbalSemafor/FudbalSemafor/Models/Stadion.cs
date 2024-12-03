using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Stadion
{
    public int IdStadion { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Grad { get; set; }

    public int Kapacitet { get; set; }

    public string? Podloga { get; set; }

    public virtual ICollection<Utakmica> Utakmicas { get; set; } = new List<Utakmica>();
}
