using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.SchoolTypes
{
    public class SchoolDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public string Region { get; set; }



        public short SchoolTypeId { get; set; }
        public string SchoolTypeName { get; set; }

        public short SchoolSubTypeId { get; set; }
        public string SchoolSubTypeName { get; set; }


        /// <summary>
        /// 0:Men , 1:Women
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 0:Sobhi , 1:Asri ,2:joftesh
        /// </summary>
        /// 


        public short ShiftType { get; set; }

        public string ShiftTypeName => ShiftType==1 ? "عصری" : ShiftType== 0? "صبحی":"صبحی -عصری";

        public int TotalStudentCount { get; set; }
        public int RegisterStudentCount { get; set; }
        public string CreationDate { get; set; }
        public string SchoolNumber { get; set; }
        public string FounderName { get; set; }
        public string ManagerName { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string WebUrl { get; set; }

        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }

        public string ProvinceName { get; set; }
        public string SexName => Sex ? "خانم" : "آقا";

        public string EducationLevelName { get; set; }

        public EducationSubCourse EducationSubCourse { get; set; }

        public string EducationSubCourseName
        {
            get
            {
                if (EducationSubCourse != null)
                    return EducationSubCourse.Name;

                return "-";
            }
        }

        public string EducationCourseName
        {
            get
            {
                return EducationSubCourse?.EducationCourse?.Name;

            }
        }



    }

}
