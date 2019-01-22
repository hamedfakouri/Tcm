import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { Educationcourse } from '../models/educationcourse';
import { HttpService } from 'src/app/shared/services/http.service';
import { Observable } from 'rxjs';


@Injectable()
export class EducationcourseService extends HttpService<Educationcourse> {

  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/educationcourse/";
  }

}