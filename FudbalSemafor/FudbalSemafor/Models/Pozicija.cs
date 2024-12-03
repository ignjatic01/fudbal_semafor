using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Pozicija
{
    public string OznakaPozicije { get; set; } = null!;

    public string NazivPozicije { get; set; } = null!;

    public virtual ICollection<Igrac> Igracs { get; set; } = new List<Igrac>();
}
