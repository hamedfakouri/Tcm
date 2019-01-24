import { Component, OnDestroy } from '@angular/core';
import { delay, withLatestFrom, takeWhile } from 'rxjs/operators';
import {
  NbMediaBreakpoint,
  NbMediaBreakpointsService,
  NbMenuItem,
  NbMenuService,
  NbSidebarService,
  NbThemeService,
} from '@nebular/theme';
import { AuthService } from 'src/app/authentication/services';

// TODO: move layouts into the framework
@Component({
  selector: 'ngx-sample-layout',
  styleUrls: ['./sample.layout.scss'],
  templateUrl:  './sample.layout.html'
})
export class SampleLayoutComponent implements OnDestroy {

  isLoggedIn: boolean = false;
  layout: any = {};
  sidebar: any = {};

  private alive = true;

  currentTheme: string;

  constructor(protected menuService: NbMenuService,protected themeService: NbThemeService,
    protected bpService: NbMediaBreakpointsService,protected sidebarService: NbSidebarService,
    private authService: AuthService) {

    this.isLoggedIn = this.authService.isLoggedIn();

    this.authService.loginAccures.subscribe((isLoggedIn: boolean) => {
      this.isLoggedIn = isLoggedIn;
    })
      
    const isBp = this.bpService.getByName('is');
    this.menuService.onItemSelect()
      .pipe(
        takeWhile(() => this.alive),
        withLatestFrom(this.themeService.onMediaQueryChange()),
        delay(20),
      )
      .subscribe(([item, [bpFrom, bpTo]]: [any, [NbMediaBreakpoint, NbMediaBreakpoint]]) => {

        if (bpTo.width <= isBp.width) {
          this.sidebarService.collapse('menu-sidebar');
        }
      });

    this.themeService.getJsTheme()
      .pipe(takeWhile(() => this.alive))
      .subscribe(theme => {
        this.currentTheme = theme.name;
      });
  }


  ngOnDestroy() {
    this.alive = false;
  }
}
