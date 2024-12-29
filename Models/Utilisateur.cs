using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Utilisateur
{
    public int Idutilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Motdepasse { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
