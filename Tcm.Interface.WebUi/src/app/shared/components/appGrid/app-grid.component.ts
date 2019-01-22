import { Component, OnInit, Input, Output, EventEmitter, OnChanges, DoCheck, AfterContentInit, AfterContentChecked, AfterViewInit, AfterViewChecked } from '@angular/core';
import { Pagination } from 'src/app/core/models/pagination';
import { Pair, TaskType, SubjectType } from 'src/app/core/models';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/authentication/services';

import { PairType } from 'src/app/core/models/pair-type.enum';
import { PermissionService } from 'src/app/authentication/services/permission.service';




@Component({
  selector: 'app-grid',
  templateUrl: './app-grid.component.html'
})
export class AppGridComponent implements  OnInit , OnChanges ,DoCheck ,AfterContentInit ,AfterContentChecked ,AfterViewInit ,AfterViewChecked {
 
  @Input()  items :any[];
  @Input()  dictionary:Array<Pair>;
  @Input()  subject:string;
  @Input()  pagination:Pagination;
  @Input()  editable: boolean =false;
  @Input()  removable: boolean =false;

  @Output() onSort = new EventEmitter();
  @Output() onPageChanged = new EventEmitter();
  @Output() onEdit = new EventEmitter();
  @Output() onRemove = new EventEmitter();
   
  showGrid:boolean =false;

     
  constructor(private router:Router,private permissionService:PermissionService) { 

   console.log("constructor");






  }

 


  ngOnChanges(){

console.log("ngOnChanges");

  }

  ngOnInit() {
  
    
this.showGrid =true;
let _subject = SubjectType[this.subject];
if(this.permissionService.HasPermission(_subject, TaskType.edit) && this.editable){

 this.editable = true;

}else{
  this.editable =false;
}

if(this.permissionService.HasPermission(_subject,TaskType.delete) && this.editable){

this.removable=true;


}else{
  this.removable =false;
}
    console.log("ngOnInit");

  }

ngDoCheck(){
  console.log("ngDoCheck");

}

ngAfterContentInit(){
  console.log("ngAfterContentInit");

}

ngAfterContentChecked(){
  console.log("ngAfterContentChecked"); //show grid header

}

ngAfterViewInit(){
  console.log("ngAfterViewInit");

}

ngAfterViewChecked(){
  
  console.log("ngAfterViewChecked");

}

  pageChanged(event:any):void{
    this.onPageChanged.emit(event); 
  }

  getIndex(value:number):number{
    return ((this.pagination.currentPage -1 ) * this.pagination.itemsPerPage) + value + 1 ;
  }

  edit(value:any){
    this.onEdit.emit(value);

  }
  remove(value:any){
    this.onRemove.emit(value);

  }

  sort(value:any){
  

     if(this.pagination.orderBy==value){

      if(this.pagination.orderByType=="DESC"){
        this.pagination.orderByType="ASC";
      } else{
        this.pagination.orderByType="DESC"
      }
     }
     else{
      this.pagination.orderBy = value;
      this.pagination.orderByType = "ASC";
     }
    this.onSort.emit(this.pagination);
    
  }  
}
