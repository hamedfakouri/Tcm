import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Major } from '../models/major';
import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';


@Injectable()
export class MajorService extends HttpService<Major> {
  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "Major";
    this.url = this.baseUrl + "/api/" + this.endpoint + "/"

  }
  public GetDictionary(): Array<Pair> {

    let items = new Array<Pair>();
    items.push(new Pair("Id", "شماره"));
    items.push(new Pair("Name", "نام"));

    return items;

  }
}