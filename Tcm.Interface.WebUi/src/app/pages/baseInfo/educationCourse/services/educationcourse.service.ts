import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { EducationCourse } from '../models/educationcoure';


@Injectable()
export class EducationCourseService extends HttpService<EducationCourse> {

  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/educationcourse/";
  }

  public GetDictionary():Array<Pair>{

    let items = new Array<Pair>();
    
    items.push(new Pair("Name","عنوان"));
    items.push(new Pair("EducationLevelName","مقطع تحصیلی"));
  

   return items;

  }

}