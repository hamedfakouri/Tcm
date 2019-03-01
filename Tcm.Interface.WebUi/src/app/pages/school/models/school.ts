import { SchoolEducationSubCourse } from "./SchoolEducationSubCourse";

export class School {
    Id: number;
    Name: string;
    EducationLevelId: number;
    EducationLevelName: string;
    EducationCourseId: number;
    EducationCourseName: string;
    EducationSubCourseName: string;
    ProvinceId: number;
    ProvinceName: string;
    CityId: number;
    CityName: string;
    RegionId: number;
    RegionName: string;
    SchoolTypeId: number;
    SchoolTypeName: string;
    SchoolSubTypeId: number;
    SchoolSubTypeName: string;
    Sex: boolean;
    ShiftType: number;
    TotalStudentCount: string;
    RegisterStudentCount: string;
    SchoolNumber: string;
    FounderName: string;
    ManagerName: string;
    PostalAddress: string;
    PostalCode: string;
    WebUrl: string;
    PhoneNumber1: string;
    PhoneNumber2: string;
    CreationDate: string;
    SchoolEducationSubCourses: SchoolEducationSubCourse[];

    constructor() {
        this.Id = 0; this.Name= ''; this.EducationLevelId= 0; this.EducationLevelName= ''; this.EducationCourseId= 0; this.EducationCourseName= '',
        this.EducationSubCourseName= ''; this.ProvinceId= 0; this.ProvinceName= ''; this.CityId= 0; this.CityName= '',
        this.RegionId= 0; this.RegionName= ''; this.SchoolTypeId= 0; this.SchoolTypeName= ''; this.SchoolSubTypeId= 0; this.CreationDate= '',
        this.SchoolSubTypeName= ''; this.Sex= false; this.ShiftType= 0; this.TotalStudentCount= ''; this.RegisterStudentCount= ''; this.SchoolNumber= '',
        this.FounderName= ''; this.ManagerName= ''; this.PostalAddress= ''; this.PostalCode= ''; this.WebUrl= ''; this.PhoneNumber1= ''; this.PhoneNumber2= ''; 
        this.SchoolEducationSubCourses = null
        
    }
}
