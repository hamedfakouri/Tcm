
namespace Tcm.Application.Contract.EducationSubCourses
{
    public class EducationSubCourseListDto
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short EducationCourseId { get; set; }
        public string EducationCourseName { get; set; }
        public string EducationLevelName { get; set; }
    }

}
