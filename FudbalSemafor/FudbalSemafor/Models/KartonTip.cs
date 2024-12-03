using System;
using System.Collections.Generic;

namespace FudbalSemafor.Models;

public partial class KartonTip
{
    public int IdKartonTip { get; set; }

    public string Tip { get; set; } = null!;

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();
}
