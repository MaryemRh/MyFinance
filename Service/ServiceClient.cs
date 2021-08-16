using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data;
using Data.Infrastructure;
using Data.Repositories;

namespace Service
{
    public class ServiceClient : EntityService<Client>
    {
        public ServiceClient(): base()
        {

        }

        // Somme des prix des medicament par consultation 
        public float GetTotalFacturePrice(int clientid)
        {
            var client = unitofwork.GetRepository<Client>().GetAll().Where(m => m.Cin  == clientid).FirstOrDefault();
            var listfactures = client.Factures.ToList();

            float sommeprix = 0;

            foreach (var fact in listfactures)
            {
                sommeprix += fact.Prix;
            }

            return sommeprix;
        }

    }
}
