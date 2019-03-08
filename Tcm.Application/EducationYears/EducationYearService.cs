using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Tcm.Application.Contract.EducationYears;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.EducationYearServices
{
    public class EducationYearServiceService : IEducationYearService
    {

        private IEducationYearRepository _educationYearRepository;
        public EducationYearServiceService(IEducationYearRepository EducationYearServiceRepository)
        {
            _educationYearRepository = EducationYearServiceRepository;
        }
        public void Add(EducationYearDto EducationYearDto)
        {
            var EducationYearService = new EducationYear() {
                EndDate = EducationYearDto.EndDate,
                StartDate = EducationYearDto.StartDate,
            };

            _educationYearRepository.Add(EducationYearService);
           
        }

        public void Delete(short Id)
        {
            var EducationYear= Get(Id);
            if(EducationYear !=null)
            _educationYearRepository.Delete(EducationYear.Mapper());
        }

        public EducationYearDto Get(short id)
        {
           return  _educationYearRepository.GetById(id).Mapper();

           
        }

        public List<EducationYearDto> GetAll(UserParams userParams)
        {
            return _educationYearRepository.GetAll().Pager(userParams).ToList().Mapper();

        }

        public List<EducationYear> GetAll(Expression<Func<EducationYear, bool>> expression)
        {
            return _educationYearRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, EducationYearDto model)
        {
            var EducationYear = _educationYearRepository.GetById(Id);
           
            if (EducationYear != null)
            {
                EducationYear.StartDate = model.StartDate;
                EducationYear.EndDate = model.EndDate;

                _educationYearRepository.Update(EducationYear);
            }
        }
    }

    public static class EducationYearServiceMapper
    {
        public static List<EducationYearDto> Mapper(this List<EducationYear> EducationYearServices)
        {
            var items = new List<EducationYearDto>();
            EducationYearServices.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationYearDto Mapper(this EducationYear EducationYear)
        {


            var dto = new EducationYearDto();

            if (EducationYear != null)
            {
                dto.Id = EducationYear.Id;
                dto.StartDate = EducationYear.StartDate;
                dto.EndDate = EducationYear.EndDate;
            }          

            return dto;
        }
        public static List<EducationYear> Mapper(this List<EducationYearDto> EducationYear)
        {
            var items = new List<EducationYear>();
            EducationYear.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationYear Mapper(this EducationYearDto EducationYear)
        {


            var dto = new EducationYear();

            if (EducationYear != null)
            {
                dto.Id = EducationYear.Id;
                dto.EndDate = EducationYear.EndDate;
                dto.StartDate = EducationYear.StartDate;
            }

            return dto;
        }
    }
    
}
