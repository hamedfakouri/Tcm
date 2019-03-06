import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { HttpService } from 'src/app/shared/services/http.service';
import { SchoolEducationSubCourse } from '../models/SchoolEducationSubCourse';
import { Observable } from 'rxjs';

@Injectable()
export class SchoolEducationSubCourseService extends HttpService<SchoolEducationSubCourse> {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "SchoolEducationSubCourse";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/";
  }

  
  getBySchoolId(schoolId: number): Observable<Array<SchoolEducationSubCourse>> {

    return this.httpClient.get<Array<SchoolEducationSubCourse>>(this.url + "?schoolId=" + schoolId);
  }


}