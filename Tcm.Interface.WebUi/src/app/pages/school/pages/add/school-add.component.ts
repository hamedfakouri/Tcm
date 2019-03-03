import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination } from 'src/app/core/models/pagination';
import { School } from '../../models/school';
import { SchoolType } from 'src/app/pages/baseInfo/schoolType/models/schooltype';
import { SchoolService } from '../../services/school.service';
import { SchoolTypeService } from 'src/app/pages/baseInfo/schoolType/services/schooltype.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SchoolSubType } from 'src/app/pages/baseInfo/schoolSubType/models/schoolsubtype';
import { SchoolSubTypeService } from 'src/app/pages/baseInfo/schoolSubType/services/schoolsubtype.service';
import { EducationCourse } from 'src/app/pages/baseInfo/educationCourse/models/educationcourse';
import { EducationLevel } from 'src/app/pages/baseInfo/educationLevel/models';
import { EducationLevelService } from 'src/app/pages/baseInfo/educationLevel/services/educationlevel.service';
import { EducationCourseService } from 'src/app/pages/baseInfo/educationCourse/services/educationcourse.service';
import { EducationSubCourseService } from 'src/app/pages/baseInfo/educationSubCourse/services/educationsubcourse.service';
import { ProvinceService } from 'src/app/core/services/province.service';
import { Province } from 'src/app/core/models/province';
import { Region } from 'src/app/core/models/region';
import { City } from 'src/app/core/models/city';
import { SelectItems } from 'src/app/core/models/selectItems';
import { SchoolEducationSubCourse } from '../../models/SchoolEducationSubCourse';
import { EducationLevelCourseSubcourseComponent } from '../../components/education-level-course-subcourse/education-level-course-subcourse.component';

@Component({
  selector: 'app-school-add',
  templateUrl: 'school-add.component.html',
  styleUrls: ['school-add.component.css']
})

export class SchoolAddComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];
  title = "CodeSandbox";
  disabled = false;
  ShowFilter = false;
  limitSelection = false;
  cities: Array<any> = []


  schoolItem: School = new School();

  public items: School[] = [];
  public schoolTypeItems: Observable<SchoolType[]>;
  public schoolSubTypeItems: Observable<SchoolSubType[]>;
  public provinceItems: Observable<Province[]>;
  public cityItems: Observable<City[]>;
  public regionItems: Observable<Region[]>;

  @ViewChild('f') form: any;
  @ViewChild('educationLevelCourseSubcourse') educationLevelCourseSubcourse : EducationLevelCourseSubcourseComponent;

  public pagination = new Pagination(1, 10);
  public subject: string = "schooladd";
  userParams: any = {};
  

  constructor(private alertify: AlertifyService, private schoolService: SchoolService,
    private schoolTypeService: SchoolTypeService, private schoolSubTypeService: SchoolSubTypeService,
    private educationLevelService: EducationLevelService, private educationCourseService: EducationCourseService,
    private educationSubCourseService: EducationSubCourseService, private provinceService: ProvinceService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    //read school id from route params
    this.schoolItem.Id = this.route.snapshot.params['id'];

    this.getschoolTypeItems();

    this.educationLevelCourseSubcourse.getEducationLeveltems();

    this.getProvinceItems();

    this.getItem();

  }

  getProvinceItems() {
    this.provinceItems = this.provinceService.getAll();
  }

  getschoolTypeItems() {
    this.schoolTypeItems = this.schoolTypeService.getAll();
  }

  getCity(ProvinceId: number) {
    this.cityItems = this.provinceService.getCitiesByProvince(ProvinceId);
  }

  getRegion(CityId: number) {
    if (CityId != 329) return;

    this.regionItems = this.provinceService.getRegionsByCity(CityId);
  }

  getSchoolSubType(typeId: number) {

    this.schoolSubTypeItems = this.schoolSubTypeService.getBySchoolType(typeId);
  }



  getItem() {

    //insert new school
    if (this.schoolItem.Id == 0)
      return;

    this.schoolService.get(this.schoolItem.Id).subscribe(
      (res: School) => {

        this.schoolItem = res;

        if (this.schoolItem.ProvinceId != 0) {
          this.getCity(this.schoolItem.ProvinceId);

          if (this.schoolItem.CityId == 329) {
            this.getRegion(this.schoolItem.CityId);
          }
        }

        if (this.schoolItem.SchoolTypeId != 0) {
          this.getSchoolSubType(this.schoolItem.SchoolTypeId);
        }

        if (this.schoolItem.EducationLevelId != 0) {
          this.educationLevelCourseSubcourse.getEducationCourse(this.schoolItem.EducationLevelId);

          if (this.schoolItem.EducationCourseId != 0) {
            this.educationLevelCourseSubcourse.getEducationSubCourse(this.schoolItem.EducationCourseId);
          }
        }

      }
    );
  }

  submitForm(): void {

    if (this.schoolItem.EducationLevelId == 0) {
      this.alertify.error("انتخاب مقطع آموزشی الزامیست.");
      return;
    }

    if (this.form.valid) {
     console.log(this.schoolItem);
      this.schoolItem.SchoolEducationSubCourses = this.educationLevelCourseSubcourse.getSelectedSubCourse();

      if (this.schoolItem.Id == 0) {
        this.schoolService.add(this.schoolItem).subscribe(
          () => {
            this.navigateToSchoolList();
          }
        );

      }
      else {
        this.schoolService.update(this.schoolItem.Id, this.schoolItem).subscribe(
          () => {
            this.navigateToSchoolList();
          }
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
