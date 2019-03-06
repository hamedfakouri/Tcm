export class SchoolEducationSubCourse {
    Id: Number;
    SchoolId: Number;
    EducationSubCourseId: Number;
    MajorId: number;
    EducationSubCourseName?: string;

    constructor(educationSubCourseId, schoolId,majorId){
        this.EducationSubCourseId = educationSubCourseId;
        this.SchoolId = schoolId;
        this.MajorId = majorId;
    }
}
