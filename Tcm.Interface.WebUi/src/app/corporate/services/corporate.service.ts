import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Corporate } from '../models/corporate';
import { HttpService } from 'src/app/shared/services';
import { Pair } from 'src/app/core/models';



@Injectable()
export class CorporateService extends HttpService<Corporate> {
  
  constructor(private httpClient :HttpClient){
       super(httpClient);
       this.endpoint = "/api/schoolType/";
  } 


  public GetDictionary():Array<Pair>{

    let items = new Array<Pair>();
    items.push(new Pair("Id","شماره"));
    items.push(new Pair("Name","نام"));
  

   return items;

  }
  


 




}