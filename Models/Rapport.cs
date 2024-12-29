using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Rapport
{
    public int Idrapport { get; set; }

    public int? Idreservation { get; set; }

    public string Typerapport { get; set; } = null!;

    public string Cheminfichier { get; set; } = null!;

    public virtual Reservation? IdreservationNavigation { get; set; }
}
