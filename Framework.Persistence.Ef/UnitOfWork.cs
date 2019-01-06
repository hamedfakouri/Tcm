using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence.Ef
{
    public class UnitOfWork<TContext>: IUnitOfWork where TContext :DbContext
        
        
    {
        private TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public void Begin()
        {
            var transaction = _context.Database.BeginTransaction();
            _context.ChangeTracker.QueryTrackingBehavior =QueryTrackingBehavior.TrackAll;

        }

        public void Commit()
        {

            _context.SaveChanges();
            _context.Database.CommitTransaction();
            


        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
