using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Repositories
{
    public class FactureRepository : RepositoryBase<Facture>
    {
        //private MyFinanceContext _dbContext = new MyFinanceContext();

        private DatabaseFactory _db = new DatabaseFactory();
        public FactureRepository(DatabaseFactory db)
            : base(db)
        {
            //dbContext =  new MyFinanceContext();
            _db = db;
        }

    }
}
