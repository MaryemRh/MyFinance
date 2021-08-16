using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MyFinanceContext dataContext;
        public MyFinanceContext DataContext { get { return dataContext; } }

        // Get the current DataContext
        public MyFinanceContext Get()
        {
            if (DataContext != null) return DataContext;
            return dataContext = new MyFinanceContext();
        }

        // Constructor: create new instance of MyFinanceContext
        public DatabaseFactory()
        {
            dataContext = new MyFinanceContext();
        }

        //Implement DisposeCore to free ressource allocated to DataContext
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
