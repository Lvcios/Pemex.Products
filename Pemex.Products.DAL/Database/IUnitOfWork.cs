using System;
using System.Collections.Generic;
using System.Text;
using PetaPoco;

namespace Pemex.Products.DAL.Database
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        PetaPoco.Database DB { get; }
    }
}
