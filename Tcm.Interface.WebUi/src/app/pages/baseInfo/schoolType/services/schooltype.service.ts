import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { SchoolType } from '../models/schooltype';


@Injectable()
export class SchoolTypeService extends HttpService<SchoolType> {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "SchoolType";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"

  }

  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();
    items.push(new Pair("Name", "نام"));

    return items;

  }

}