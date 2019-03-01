export class SchoolEducationSubCourse {
    Id: Number;
    SchoolId: Number;
    EducationSubCourseId: Number;
    MajorId: number;

    constructor(educationSubCourseId, schoolId,majorId){
        this.EducationSubCourseId = educationSubCourseId;
        this.SchoolId = schoolId;
        this.MajorId = majorId;
    }
}
