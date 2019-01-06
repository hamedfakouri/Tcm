using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Persistence.Ef
{
    public interface IUnitOfWork
    {
      

        void Begin();
        void Commit();

        void RollBack();
    }
}
