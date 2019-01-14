import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbLayoutDirection, NbThemeService, NbLayoutDirectionService } from '@nebular/theme';
import { MENU_ITEMS } from './pages/pages-menu';

@Component({

  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  directions = NbLayoutDirection;
  menu = MENU_ITEMS;

  constructor(private router :Router,private themeService: NbThemeService,
        private directionService: NbLayoutDirectionService) {
          
    this.themeService.changeTheme('corporate');
    this.directionService.setDirection(this.directions.RTL);

  }
  
}
