import { Component, OnInit } from '@angular/core';
import { ClassRoom } from '../../models/classroom';
import { SchoolService } from 'src/app/pages/school/services/school.service';
import { AuthService } from 'src/app/authentication/services';
import { School } from 'src/app/pages/school/models/school';
import { SchoolEducationSubCourse } from 'src/app/pages/school/models/SchoolEducationSubCourse';
import { SchoolEducationSubCourseService } from 'src/app/pages/school/services/schooleducationsubcourse.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassRoomService } from '../../services/classroom.service';
import { EducationYear } from 'src/app/pages/baseInfo/educationYear/models';
import { EducationYearService } from 'src/app/pages/baseInfo/educationYear/services/educationYear.service';

@Component({
  selector: 'app-classroom-add',
  templateUrl: './classroom-add.component.html',
  styleUrls: ['./classroom-add.component.css']
})
export class ClassRoomAddComponent extends CrudComponent<ClassRoom> implements OnInit {

  schoolId: number;
  schoolEducationSubCourseList: SchoolEducationSubCourse[] = [];
  educationYearList: EducationYear[] = [];
  
  constructor(private classRoomService: ClassRoomService, 
    private schoolEducationSubCourseService: SchoolEducationSubCourseService,
    private educationYearService: EducationYearService,
    private authService: AuthService, route: ActivatedRoute, router: Router) {

    super(classRoomService, route, router);
    this.Id = this.route.snapshot.params['id'];
    
  }

  ngOnInit() {
    this.item = new ClassRoom();
    this.schoolId = this.authService.decodedToken().SchoolId;
    this.getSchoolEducationSubCourses();
    this.getEducationYears();

    if(this.Id){
      this.get(this.Id);
    }
  }

  getSchoolEducationSubCourses() {

    this.schoolEducationSubCourseService.getBySchoolId(this.schoolId).subscribe((res: SchoolEducationSubCourse[]) => {
      
      this.schoolEducationSubCourseList = res;
    });
  }

  
  getEducationYears() {

    this.educationYearService.getAll().subscribe((res: EducationYear[]) => {
      
      this.educationYearList = res;
    });
  }

}
