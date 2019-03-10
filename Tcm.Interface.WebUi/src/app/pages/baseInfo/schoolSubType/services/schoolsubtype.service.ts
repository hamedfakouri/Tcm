import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { SchoolSubType } from '../models/schoolsubtype';
import { Observable } from 'rxjs';


@Injectable()
export class SchoolSubTypeService extends HttpService<SchoolSubType> {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "SchoolSubType";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"

  }
  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();

    items.push(new Pair("Name", "عنوان"));
    items.push(new Pair("SchoolTypeName", "نوع مدرسه"));


    return items;
  }

  getBySchoolType(Id: number): Observable<SchoolSubType[]> {
    return this.httpClient.get<SchoolSubType[]>(this.url + "schoolType/" + Id);

  }

}