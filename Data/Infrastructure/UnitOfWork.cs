using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private MyFinanceContext _dataContext;
       // private IRepository<T> repositoryProvider;
        IDatabaseFactory databaseFactory;

        public UnitOfWork()
        {
            //this._dataContext = new MyFinanceContext();
            this.databaseFactory = new DatabaseFactory();
        }

        public MyFinanceContext DataContext
        {
            get { return _dataContext = databaseFactory.DataContext; }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            IRepository<T> repo = new RepositoryBase<T>(databaseFactory);
            return repo;

        }



    }
}
