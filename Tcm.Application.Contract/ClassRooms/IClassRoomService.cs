using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.ClassRooms
{

    public interface IClassRoomService : IApplicationService
    {
        void Add(ClassRoomAddDto classRoomDto);

        ClassRoom Get(short Id);

        List<ClassRoomDto> GetAll(UserParams userParams, int schoolId);

        List<ClassRoom> GetAll(Expression<Func<ClassRoom, bool>> expression);

        void Delete(short Id);

        void Update(short Id, ClassRoomDto classRoomLevel);

    }
}
