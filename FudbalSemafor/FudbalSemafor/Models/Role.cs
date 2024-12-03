using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string NazivRole { get; set; } = null!;

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
