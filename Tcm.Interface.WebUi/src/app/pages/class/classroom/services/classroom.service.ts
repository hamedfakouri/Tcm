import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { ClassRoom } from '../models/classroom';
import { CustomTask } from 'src/app/core/models/custom-task';
import { Router } from '@angular/router';


@Injectable()
export class ClassRoomService extends HttpService<ClassRoom> {

  constructor(private httpClient: HttpClient, private route: Router) {
    super(httpClient);
    this.endpoint = "ClassRoom";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"
  }

  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();

    items.push(new Pair("Name", "عنوان کلاس"));
    items.push(new Pair("EducationYear", "سال تحصیلی"));
    items.push(new Pair("EducationCourseName", "دوره آموزشی"));
    items.push(new Pair("EducationSubCourseName", "پایه تحصیلی"));

    return items;

  }
   
  public GetAllBySchoolId(schoolId: number){

    return this.httpClient.get<Array<ClassRoom>>(this.url + "?schoolId=" + schoolId );

  }

  public GetGridCustomTask(): Array<CustomTask> {

    let items = new Array<CustomTask>();
    items.push(new CustomTask(null, "AddNewManager", "افزودن مدیر"));
    return items;
  }

  public AddNewManager(task: CustomTask) {

    this.route.navigate(['account/register/1'])
  }



}