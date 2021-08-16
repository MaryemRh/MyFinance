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
    public class ServiceProduct : EntityService<Product>
    {
       // static IUnitOfWork Uok = new UnitOfWork();

        public ServiceProduct(): base()
        {

        }

        public IEnumerable<Product> GetProductByName(string Name)
        {
            return unitofwork.GetRepository<Product>().GetAll().Where(m => m.Name.ToString().ToLower().Contains(Name));
        }

        public int GetClientNbre(int productid)
        {
            var product = unitofwork.GetRepository<Product>().GetAll().Where(m => m.ProductId == productid).FirstOrDefault();
            var listfactures = product.Factures.ToList();

            int nbreclient = 0;

            foreach (var fact in listfactures)
            {
                if(fact.Productid == product.ProductId)
                    nbreclient++;
            }

            return nbreclient;
        }

    }
}
