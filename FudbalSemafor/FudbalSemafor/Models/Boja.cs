using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Boja
{
    public int IdBoja { get; set; }

    public string PrimarnaBoja { get; set; } = null!;

    public string? SekundarnaBoja { get; set; }

    public virtual ICollection<Klub> Klubs { get; set; } = new List<Klub>();
}
