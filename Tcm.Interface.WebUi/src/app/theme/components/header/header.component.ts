import { Component, Input, OnInit } from '@angular/core';

import { NbMenuService, NbSidebarService } from '@nebular/theme';
import { AuthService } from 'src/app/authentication/services';
import { AlertifyService } from 'src/app/shared/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {

  @Input() position = 'normal';
  fullName: string = '';
  decodedToken;
  user: any;

  userMenu = [{ title: 'Profile' }, { title: 'Log out' }];

  constructor(private sidebarService: NbSidebarService, private menuService: NbMenuService,
    private authService: AuthService, private alertifyService: AlertifyService, private router: Router) {
  }

  ngOnInit() {

    
    if(typeof(this.authService.decodedToken) == 'function'){
      this.decodedToken = this.authService.decodedToken();
    }
    else{
      this.decodedToken = this.authService.decodedToken;
    }

    this.fullName = this.decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] + " " +
          this.decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"];
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');

    return false;
  }

  toggleSettings(): boolean {
    this.sidebarService.toggle(false, 'settings-sidebar');

    return false;
  }

  goToHome() {
    this.menuService.navigateHome();
  }

  startSearch() {
  }

  signOut(): void {

    this.authService.signOut();
    this.authService.loginAccures.next(false);

    this.alertifyService.message('به امید دیدار مجدد.');
    this.router.navigate(['Account/login']);

  }
}
