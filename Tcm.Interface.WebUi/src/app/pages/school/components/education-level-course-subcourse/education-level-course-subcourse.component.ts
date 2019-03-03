import { Component, OnInit, Input } from '@angular/core';
import { SelectItems } from 'src/app/core/models/selectItems';
import { Observable } from 'rxjs';
import { EducationCourse } from 'src/app/pages/baseInfo/educationCourse/models/educationcourse';
import { EducationSubCourseService } from 'src/app/pages/baseInfo/educationSubCourse/services/educationsubcourse.service';
import { EducationCourseService } from 'src/app/pages/baseInfo/educationCourse/services/educationcourse.service';
import { EducationLevel } from 'src/app/pages/baseInfo/educationLevel/models';
import { EducationLevelService } from 'src/app/pages/baseInfo/educationLevel/services/educationlevel.service';
import { School } from '../../models/school';
import { SchoolEducationSubCourse } from '../../models/SchoolEducationSubCourse';

@Component({
  selector: 'app-education-level-course-subcourse',
  templateUrl: './education-level-course-subcourse.component.html',
  styleUrls: ['./education-level-course-subcourse.component.css']
})
export class EducationLevelCourseSubcourseComponent implements OnInit {

  subCourseList: SelectItems[] = [];

  selectedSchoolEducationSubCourse: SelectItems[] = [];
  settings = {};
  public educationCourseItems: Observable<EducationCourse[]>;
  public educationLevelItems: Observable<EducationLevel[]>;
  
  @Input() schoolItem: School = new School();

  constructor(private educationLevelService: EducationLevelService, private educationSubCourseService: EducationSubCourseService, private educationCourseService: EducationCourseService) { }

  ngOnInit() {

    this.settings = {
      singleSelection: false,
      text: " ",
      selectAllText: 'انتخاب همه',
      unSelectAllText: 'حذف انتخاب',
      //enableSearchFilter: true,
      badgeShowLimit: 2
    };
  }


  getEducationLeveltems() {
    this.educationLevelItems = this.educationLevelService.getAll();
  }

  getEducationCourse(educationLevelId: number) {

    this.educationCourseItems = this.educationCourseService.getByEducationLevel(educationLevelId);
  }


  getEducationSubCourse(educationCourseId: number) {

    this.educationSubCourseService.getByEducationCourse(educationCourseId)
      .subscribe((items) => {

        items.forEach(item => {
          this.subCourseList.push(new SelectItems(item.Id, item.Name));
        });


        if (this.schoolItem.SchoolEducationSubCourses) {

          this.schoolItem.SchoolEducationSubCourses.forEach(item => {
            this.selectedSchoolEducationSubCourse.push(
              new SelectItems(item.EducationSubCourseId, this.subCourseList.find(x => x.id == item.EducationSubCourseId).itemName)
            );
          });
        }
      });
  }

  getSelectedSubCourse() {
    let selectedItems = [];

    if (this.selectedSchoolEducationSubCourse.length > 0) {

      this.selectedSchoolEducationSubCourse.forEach(item => {
        selectedItems.push(new SchoolEducationSubCourse(item.id, this.schoolItem.Id, 1));
      })
    }

    return selectedItems;

  }

}
