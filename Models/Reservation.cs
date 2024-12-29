using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Reservation
{
    public int Idreservation { get; set; }

    public int? Idutilisateur { get; set; }

    public int? Idclient { get; set; }

    public DateOnly Datereservation { get; set; }

    public DateOnly Datearrivee { get; set; }

    public DateOnly Datedepart { get; set; }

    public string Statut { get; set; } = null!;

    public virtual Client? IdclientNavigation { get; set; }

    public virtual Utilisateur? IdutilisateurNavigation { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();

    public virtual ICollection<Rapport> Rapports { get; set; } = new List<Rapport>();
}
