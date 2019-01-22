import { Injectable } from '@angular/core';
import { Menu } from '../models';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  public AdminMenuList:Array<Menu>;
  public menuItem:Menu= new Menu();
  constructor() {

    for (let index = 0; index < 10; index++) {
    this.menuItem.title="";
      
    }


   }








}
