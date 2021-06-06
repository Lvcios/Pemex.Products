using PetaPoco;
using PetaPoco.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pemex.Products.DAL.Database
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly Transaction transaction;

        private readonly PetaPoco.Database db;

        public UnitOfWork()
        {
            var provider = new PostgreSQLDatabaseProvider();
            //en código duro para ahorrar tiempo, se puede obtener de la configuración mediante una inyección de dependencias
            db = new PetaPoco.Database("Server=saea98.com;Port=5433; Database=ca_11 ;User Id=ca_11;Password=4i5r25u8ca11", provider);
            transaction = new Transaction(db);
        }

        public PetaPoco.Database DB
        {
            get
            {
                return db;
            }
        }

        public void Commit()
        {
            transaction.Complete();
        }

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}
