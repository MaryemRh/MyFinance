using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Runtime.Remoting.Contexts;

namespace Data.Infrastructure
{
   public interface IDatabaseFactory : IDisposable
    {
        // instancié l'objet Context
        MyFinanceContext DataContext { get; }
        MyFinanceContext Get();

    }

    //1er principe
    //Séparation des Conceptes (SoC)

    // 2eme principe
    // Principe de responsabilité unique (SRP)
    //- chaque objet doit avoir une responsabilité unique,
    //et que tous ses services doit être étroitement aligné avec cette responsabilité.
}
