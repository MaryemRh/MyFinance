using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class ClientModel
    {
        public int Cin { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public String Email { get; set; }

        public float PrixFactures { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

        public ClientModel(Client client)
        {
            Cin = client.Cin;
            Prenom = client.Prenom;
            Nom = client.Nom;
            Email = client.Email;
            Factures = client.Factures;
        }
    }
}