import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { Subject } from 'rxjs';
import { EducationYear } from '../models';


@Injectable()
export class EducationYearService extends HttpService<EducationYear> {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "educationYear";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"

  }

  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();
    items.push(new Pair("Id", "شماره"));
    items.push(new Pair("StartDate", "سال شروع"));
    items.push(new Pair("EndDate", "سال پایان"));


    return items;

  }

}