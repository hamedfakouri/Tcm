import { Component, OnInit } from '@angular/core';
import { HttpService, AlertifyService } from '../../services';
import { Message } from 'src/app/core/models/message.enum';
import { Pagination } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-crud',
  template: `
    <p>
      crud works!
    </p>
  `
})
export class CrudComponent<T> {

  public items: T[] = [];
  public item :T ;
  public pagination = new Pagination(1, 10);
  public dictionary: Array<Pair>;
  public Id:number;
  public alertify: AlertifyService;
    
  constructor(  
    public httpService : HttpService<T>,
    public route: ActivatedRoute,
    public router: Router
  )
  { 
    
 this.alertify = new AlertifyService();

  }




  getَAll(){
    this.httpService.GetAllForGrid(this.pagination).subscribe(res=> {
      this.items =res.result;
      this.pagination =res.pagination;
    })
  }
 
  get(id:number){
    this.httpService.get(id).subscribe(res=> {
    this.item =res;
    })
  }


  ngOnDestroy(): void {
  
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event;
    this.getَAll();
  }


  edit(id: number,item:T) {
    this.httpService.update(id,item).subscribe(
      (item: T) => {
        this.alertify.success(Message.editSuccess);
        this.getَAll();
       
      }
    );
  }


  goToEdit(id:number){
    this.router.navigate([ this.httpService.endpoint+'/edit/'+id]);
  }

  remove(id: number) {

    this.httpService.delete(id).subscribe(
      () => {
        this.getَAll(); 
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
        this.getَAll();

      }
    );
  }

  sort(event: Pagination) {
    let sort = event;
    this.getَAll();
  }

  add(item:T){

    if(this.Id > 0){
      this.edit(this.Id,item);
    }
    else{
      this.httpService.add(this.item).subscribe(src=>{
        this.alertify.success(Message.saveSuccess);
        this.getَAll();

       
      })
    }
   
  }


  getQueryString(){
    this.route.params.subscribe(params => {
      if(params){
        this.Id = +params['id'];
        if(this.Id>0){
          this.get(this.Id);

        }
      }});
  }
  


}
