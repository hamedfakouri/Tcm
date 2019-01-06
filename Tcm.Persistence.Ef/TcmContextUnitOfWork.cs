using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Tcm.Persistence.Ef
{
    public class TcmContextUnitOfWork : UnitOfWork<TcmContext>, IUnitOfWork
    {
        public TcmContextUnitOfWork(TcmContext context) : base(context)
        {
        }

       
    }


   
}
