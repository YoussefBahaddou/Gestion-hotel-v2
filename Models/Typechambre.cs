using System;
using System.Collections.Generic;

namespace Management_Hotel.Models;

public partial class Typechambre
{
    public int Idtype { get; set; }

    public string Libelle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Capacite { get; set; }

    public decimal Prixnuit { get; set; }

    public override string ToString()
    {
        return Libelle;
    }

}
