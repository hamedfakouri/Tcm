import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { HttpService } from 'src/app/shared/services/http.service';
import { Pair } from 'src/app/core/models';
import { School } from '../models/school';
import { CustomTask } from 'src/app/core/models/custom-task';
import { Router } from '@angular/router';


@Injectable()
export class SchoolService extends HttpService<School> {


  }
  constructor(private httpClient :HttpClient,private route:Router){
    super(httpClient);
    this.endpoint = "school";
    this.url = this.baseUrl + "/api/" + this.endpoint+"/"}

  public GetDictionary():Array<Pair>{

    let items = new Array<Pair>();
    
    items.push(new Pair("Name","نام مرکز"));
    items.push(new Pair("ProvinceName","استان"));
    items.push(new Pair("CityName","شهر"));
    items.push(new Pair("SchoolTypeName","نوع مدرسه"));
    items.push(new Pair("RegisterStudentCount","دانش آموزان ثبت نامی"));
    items.push(new Pair("TotalStudentCount","مجموع دانش آموزان"));

   return items;

  }

  public GetGridCustomTask():Array<CustomTask>{

    let items = new Array<CustomTask>();
    items.push(new CustomTask(null,"AddNewManager","افزودن مدیر"));
    return items;
  }

  public AddNewManager(task:CustomTask){
   
     this.route.navigate(['School/Add/1'])
  }



}