using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Notification
{
    public int Idnotification { get; set; }

    public int? Idreservation { get; set; }

    public string Typenotification { get; set; } = null!;

    public DateOnly Dateenvoi { get; set; }

    public string Statut { get; set; } = null!;

    public virtual Reservation? IdreservationNavigation { get; set; }
}
