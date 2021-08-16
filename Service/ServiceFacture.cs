using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using System.Data.Entity;
using Data;
using Data.Infrastructure;
using Data.Repositories;


namespace Service
{
    public class ServiceFacture : EntityService<Facture>
    {
   
        public ServiceFacture(): base()
        {

        }

        public override IEnumerable<Facture> GetAll()
        {
            return this.unitofwork.DataContext.Factures.Include(f => f.Client).Include(f => f.Product).ToList();

        }

        public Facture GetFactureById(int Productid, int ClientId, DateTime Dateachat)
        {
            return this.unitofwork.GetRepository<Facture>().GetAll().Where(a => a.Productid == Productid && a.ClientId == ClientId && a.DateAchat == Dateachat).FirstOrDefault();
        }

        public IEnumerable<Facture> GetFactureByPrice(string prix)
        {
            return unitofwork.GetRepository<Facture>().GetAll().Where(m => m.Prix >= float.Parse(prix));
        }
    }
}
