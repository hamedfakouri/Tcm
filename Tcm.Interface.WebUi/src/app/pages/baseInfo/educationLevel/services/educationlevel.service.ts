import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { EducationLevel } from '../models/educationlevel';
import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { Subject } from 'rxjs';


@Injectable()
export class EducationLevelService extends HttpService<EducationLevel> {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "educationLevel";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"

  }

  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();
    items.push(new Pair("Id", "شماره"));
    items.push(new Pair("Name", "نام"));


    return items;

  }

}