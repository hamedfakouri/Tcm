import { Component, OnInit } from '@angular/core';
import { CorporateService } from 'src/app/corporate/services';
import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Corporate } from 'src/app/corporate/models';
import { Pair, Sort } from 'src/app/core/models';
import { Router } from '@angular/router';



@Component({
  selector: 'page-corporate-list',
  templateUrl: './corporate-list.component.html'
})



export class CorporateListComponent implements OnInit {

 public pagination= new Pagination(1,10);
 public items :Array<Corporate> = new Array<Corporate>();
 public subject :string ="corporate";
 public dictionary : Array<Pair>;
 userParams: any = {};
 
 constructor(private corporateService:CorporateService,private router:Router) { 
  
  }

  ngOnInit() {
  
    this.dictionary = this.corporateService.GetDictionary();
    this.get();
  }


  get() {
    this.corporateService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<Corporate>) => {
        if(res.result){
          this.items = res.result
        }
        else{
          this.items = Array<Corporate>();
        }
        this.pagination = res.pagination;
      }, err => {
        console.log(err);
      }
    );
  }


  pageChanged(event:any):void{
    this.pagination.currentPage = event;
    console.log(this.pagination.currentPage);
    this.get();
  }


  remove(event:Corporate){
    this.corporateService.delete(event.Id).subscribe(res=> 
      {this.get()})  
  }

  edit(event:Corporate){
    this.router.navigate(["corporate/update/"+event.Id]);
    
  }

  sort(event:Pagination){
    let sort = event;
    this.get();
  }
}
