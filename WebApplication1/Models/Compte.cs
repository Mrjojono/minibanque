﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace minibanque.Models
{
    public abstract class Compte
    {
        [Key]
        public int NumCompte { get; set; }
        public string Libelle { get; set; }
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; }
        public bool AutorisationDecouvert { get; set; }
        public decimal MontantDecouvert { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }


        public virtual void Credit(decimal montant) => Solde += montant;

        public virtual bool Debit(decimal montant)
        {
            if (Solde - montant >= (AutorisationDecouvert ? -MontantDecouvert : 0))
            {
                Solde -= montant;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}