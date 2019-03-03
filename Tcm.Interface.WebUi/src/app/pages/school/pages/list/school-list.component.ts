import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { School } from '../../models/school';
import { SchoolService } from '../../services/school.service';
import { Message } from 'src/app/core/models/message.enum';
import { Router } from '@angular/router';
import { CustomTask } from 'src/app/core/models/custom-task';


@Component({
  selector: 'app-school-list',
  templateUrl: 'school-list.component.html',
  styleUrls: ['school-list.component.css']
})

export class SchoolListComponent implements OnInit, OnDestroy {

 

  public items: School[] = [];
  public pagination = new Pagination(1, 10);
  public subject: string = "schoollist";
  public dictionary: Array<Pair>;
  public customTasks: Array<CustomTask> = new Array<CustomTask>();
  

  constructor(private alertify: AlertifyService, private schoolService: SchoolService, private router: Router) { }

  ngOnInit() {

    


    this.customTasks= this.schoolService.GetGridCustomTask();
    this.dictionary = this.schoolService.GetDictionary();
    this.get();

  }


  customTask(task:CustomTask){

    if(task.taskName=="AddNewManager"){
      this.schoolService.AddNewManager(task);
    }

  }
  get() {

    this.schoolService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<School>) => {

        if (res.result) {
          this.items = res.result
        }
        else {
          this.items = [];
        }
        this.pagination = res.pagination;
      }, err => {
        console.log(err);
      });
  }

  edit(id: number) {
    
    this.router.navigate(['School/Add' , id ]);
  }

  remove(id: number) {

    this.schoolService.delete(id).subscribe(
      () => {
        this.get();
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    );
  }

  pageChanged(event: any): void {

    this.pagination.currentPage = event;

    this.get();
  }

  sort(event: Pagination) {
    let sort = event;
    this.get();
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
