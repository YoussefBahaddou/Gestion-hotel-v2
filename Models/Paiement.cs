using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Paiement
{
    public int Idpaiement { get; set; }

    public int? Idreservation { get; set; }

    public DateTime Datepaiement { get; set; }

    public decimal Montant { get; set; }

    public string Modepaiement { get; set; } = null!;

    public virtual Reservation? IdreservationNavigation { get; set; }
}
