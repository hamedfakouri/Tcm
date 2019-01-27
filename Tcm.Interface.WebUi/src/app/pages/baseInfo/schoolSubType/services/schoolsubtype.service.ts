import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { SchoolSubType } from '../models/schoolsubtype';


@Injectable()
export class SchoolSubTypeService extends HttpService<SchoolSubType> {

  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/schoolsubtype/";
  }

  public GetDictionary():Array<Pair>{

    let items = new Array<Pair>();
    
    items.push(new Pair("Name","عنوان"));
    items.push(new Pair("SchoolTypeName","نوع مدرسه"));
  

   return items;

  }

}