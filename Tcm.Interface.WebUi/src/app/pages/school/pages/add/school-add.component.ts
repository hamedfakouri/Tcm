import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { School } from '../../models/school';
import { SchoolType } from 'src/app/pages/baseInfo/schoolType/models/schooltype';
import { SchoolService } from '../../services/school.service';
import { SchoolTypeService } from 'src/app/pages/baseInfo/schoolType/services/schooltype.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SchoolSubType } from 'src/app/pages/baseInfo/schoolSubType/models/schoolsubtype';
import { SchoolSubTypeService } from 'src/app/pages/baseInfo/schoolSubType/services/schoolsubtype.service';
import { map } from 'rxjs/operators';
import { EducationSubCourse } from 'src/app/pages/baseInfo/educationSubCourse/models/educationsubcourse';
import { EducationCourse } from 'src/app/pages/baseInfo/educationCourse/models/educationcourse';
import { EducationLevel } from 'src/app/pages/baseInfo/educationLevel/models';
import { EducationLevelService } from 'src/app/pages/baseInfo/educationLevel/services/educationlevel.service';
import { EducationCourseService } from 'src/app/pages/baseInfo/educationCourse/services/educationcourse.service';
import { EducationSubCourseService } from 'src/app/pages/baseInfo/educationSubCourse/services/educationsubcourse.service';

@Component({
  selector: 'app-school-add',
  templateUrl: 'school-add.component.html',
  styleUrls: ['school-add.component.css']
})

export class SchoolAddComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  schoolItem: School = {
    Id: 0, Name: '', EducationLevelId: 0, EducationLevelName: '', EducationCourseId: 0, EducationCourseName: '',
    EducationSubCourseId: 0, EducationSubCourseName: '', ProvinceId: 0, ProvinceName: '', CityId: 0, CityName: '',
    RegionId: 0, RegionName: '', SchoolTypeId: 0, SchoolTypeName: '', SchoolSubTypeId: 0,
    SchoolSubTypeName: '', Sex: false, ShiftType: 0, TotalStudentCount: '', RegisterStudentCount: '', SchoolNumber: '',
    FounderName: '', ManagerName: '', PostalAddress: '', PostalCode: '', WebUrl: '', PhoneNumber1: '', PhoneNumber2: '', CreationDate: ''
  };

  public items: School[] = [];
  public schoolTypeItems: Observable<SchoolType[]>;
  public schoolSubTypeItems: Observable<SchoolSubType[]>;
  public educationLevelItems: Observable<EducationLevel[]>;
  public educationCourseItems: Observable<EducationCourse[]>;
  public educationSubCourseItems: Observable<EducationSubCourse[]>;

  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public subject: string = "schooladd";
  userParams: any = {};

  constructor(private alertify: AlertifyService, private schoolService: SchoolService,
    private schoolTypeService: SchoolTypeService, private schoolSubTypeService: SchoolSubTypeService,
    private educationLevelService: EducationLevelService, private educationCourseService: EducationCourseService,
    private educationSubCourseService: EducationSubCourseService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    this.getschoolTypeItems();
    this.getEducationLeveltems();

    this.getItem();

  }

  getschoolTypeItems() {
    this.schoolTypeItems = this.schoolTypeService.GetAllForGrid(this.pagination).pipe(
      map((res: PaginationResult<SchoolType>) => {
        return res.result;
      })
    );
  }

  getEducationLeveltems() {
    this.educationLevelItems = this.educationLevelService.GetAllForGrid(this.pagination).pipe(
      map((res: PaginationResult<SchoolType>) => {
        return res.result;
      })
    );
  }

  getSchoolSubType(typeId: number) {

    this.schoolSubTypeItems = this.schoolSubTypeService.getBySchoolType(typeId);
  }


  getEducationCourse(educationLevelId: number) {

    this.educationCourseItems = this.educationCourseService.getByEducationLevel(educationLevelId);
  }


  getEducationSubCourse(educationCourseId: number) {

    this.educationSubCourseItems = this.educationSubCourseService.getByEducationCourse(educationCourseId);
  }

  getItem() {
    //read school id from route params
    this.schoolItem.Id = this.route.snapshot.params['id'];

    //insert new school
    if (this.schoolItem.Id == 0)
      return;

    this.schoolService.get(this.schoolItem.Id).subscribe(
      (res: School) => {
        this.schoolItem = res;
      }
    );
  }

  submitForm(): void {

    if (this.schoolItem.EducationLevelId == 0) {
      this.alertify.error("انتخاب مقطع آموزشی الزامیست.");
      return;
    }

    if (this.form.valid) {
      this.schoolItem.CityId = 1;
      if (this.schoolItem.Id == 0) {
        this.schoolService.add(this.schoolItem).subscribe(
          () => { this.navigateToSchoolList(); }
        );

      }
      else {
        this.schoolService.update(this.schoolItem.Id, this.schoolItem).subscribe(
          () => { this.navigateToSchoolList(); }
        );
      }
    }
  }

  navigateToSchoolList() {
    this.router.navigate(['School']);
    this.alertify.success(Message.saveSuccess);
  }

  clearForm() {
    this.schoolItem.Id = 0;
    this.schoolItem.Name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
