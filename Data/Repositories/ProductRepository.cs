using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        //private MyFinanceContext _dbContext = new MyFinanceContext();

        private DatabaseFactory _db = new DatabaseFactory();
        public ProductRepository(DatabaseFactory db)
            : base(db)
        {
            //dbContext =  new MyFinanceContext();
            _db = db;
        }
    }
}
