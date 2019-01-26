using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.Majors
{

    public interface IMajorService:IApplicationService
    {
        void Add(Major Major);

        Major Get(short Id);
 

        List<Major> GetAll(UserParams userParams);

        List<Major> GetAll(Expression<Func<Major, bool>> expression);

        void Delete(short Id);

        void Update(short Id, Major Major);


    }
}
