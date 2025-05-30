using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Web;

namespace minibanque.Models
{
    
    public class Livret : Compte
    {
        public double TauxRemuneration { get; set; }

        public void AjoutInteret()
        {
            var interet = Solde * (decimal)(TauxRemuneration / 100);
            Credit(interet);
        }

        public override bool Debit(decimal montant) => false;


    }
}