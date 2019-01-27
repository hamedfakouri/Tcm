import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { EducationSubCourse } from '../models/educationsubcourse';


@Injectable()
export class EducationSubCourseService extends HttpService<EducationSubCourse> {

  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/educationsubcourse/";
  }

  public GetDictionary():Array<Pair>{

    let items = new Array<Pair>();
    
    items.push(new Pair("Name","عنوان"));
    items.push(new Pair("EducationLevelName","مقطع تحصیلی"));
    items.push(new Pair("EducationCourseName","دوره تحصیلی"));
  

   return items;

  }

}