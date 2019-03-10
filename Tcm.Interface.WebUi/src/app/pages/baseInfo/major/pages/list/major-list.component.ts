import { Component, OnInit } from '@angular/core';

import { Major } from '../../models/major';
import { MajorService } from '../../services/major.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-Major',
  templateUrl: 'major-list.component.html'
})

export class MajorComponent extends CrudComponent<Major> implements  OnInit {


  public subject: string = "major";
  constructor( private majorService: MajorService,route: ActivatedRoute,
  router: Router) {
    super(majorService,route,router);
   }

  ngOnInit() {

    this.item = new Major();
    this.items = new Array<Major>();
    this.dictionary = this.majorService.GetDictionary();
    this.getَAll();
    this.getQueryString();
    
  }
}
