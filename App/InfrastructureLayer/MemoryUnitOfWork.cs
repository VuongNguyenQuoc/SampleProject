using App.DomainModelLayer.DbContexts;
using App.Helpers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class MemoryUnitOfWork : IUnitOfWork
    {
        private SampleprojectContext _context;

        public MemoryUnitOfWork(SampleprojectContext context)
        {
            _context = context;
        }
        public async Task< bool> Commit()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }
            return returnValue;
        }

        public void Rollback()
        {
            //rollback
        }

        public void Dispose()
        {
            //dispose
        }
    }
}
