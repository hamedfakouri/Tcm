import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap';

import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { AuthServiceModule } from './authentication/services/auth-service.module';
import { UtilityService, AlertifyService } from './shared/services';
import { JwtModule } from '@auth0/angular-jwt';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from './core/core.module';
import { ThemeModule } from './theme/theme.module';
import { routes } from './app-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { EducationLevelService } from './pages/baseInfo/educationLevel/services/educationlevel.service';


export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
   
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    RouterModule,
    CoreModule,
    SharedModule,
    AuthServiceModule,
    NgbModule.forRoot(),
    ThemeModule.forRoot(),
    PaginationModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['example.com'],
        blacklistedRoutes: ['example.com/examplebadroute/']
      }
    })
  ],
  providers: [
    AuthServiceModule,
    UtilityService,
    AlertifyService,
    EducationLevelService
    //{ provide: APP_INITIALIZER, useFactory: get_settings, deps: [AuthService, UserService], multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }