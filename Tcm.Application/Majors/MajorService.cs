using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Tcm.Application.Contract.Majors;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.Majors
{
    public class MajorService : IMajorService
    {

        private IMajorRepository _MajorRepository;
        public MajorService(IMajorRepository MajorRepository)
        {
            _MajorRepository = MajorRepository;
        }
        public void Add(Major Major)
        {
            var item = new Major
            {
                Name = Major.Name
            };

            _MajorRepository.Add(item);

        }

        public void Delete(short Id)
        {
            var Major = Get(Id);
            if (Major != null)
                _MajorRepository.Delete(Major);
        }

        public Major Get(short id)
        {
            return _MajorRepository.GetById(id);


        }

        public List<Major> GetAll(UserParams userParams)
        {
            return _MajorRepository.GetAll().Pager(userParams).ToList();

        }

        public List<Major> GetAll(Expression<Func<Major, bool>> expression)
        {
            return _MajorRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, Major model)
        {
            var Major = _MajorRepository.GetById(Id);

            if (Major != null)
            {
                Major.Name = model.Name;

                _MajorRepository.Update(Major);
            }
        }
    }

    public static class MajorMapper
    {
 
    }

}
