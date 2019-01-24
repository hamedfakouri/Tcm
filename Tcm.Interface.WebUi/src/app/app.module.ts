import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap';

import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { AuthServiceModule } from './authentication/services/auth-service.module';
import { CorporateServiceModule } from './pages/corporate/services';
import { UserModule } from './user/user.module';
import { UtilityService, AlertifyService } from './shared/services';
import { JwtModule } from '@auth0/angular-jwt';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from './core/core.module';
import { ThemeModule } from './theme/theme.module';
import { routes } from './app-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { EducationCourseComponent } from './pages/baseInfo/educationCourse/educationCourse.component';
import { EducationcourseService } from './pages/baseInfo/educationCourse/services/educationcourse.service';
import { CorporateModule } from './pages/corporate/corporate.module';
import { EducationLevelComponent } from './pages/baseInfo/educationLevel/educationlevel.component';
import { EducationLevelService } from './pages/baseInfo/educationLevel/services/educationlevel.service';
import { LoginComponent } from './pages/Auth/login/login.component';


export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    EducationCourseComponent,
    EducationLevelComponent,
    LoginComponent
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
    CorporateServiceModule,
    UserModule,
    CorporateModule,
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
    EducationcourseService,
    EducationLevelService
    //{ provide: APP_INITIALIZER, useFactory: get_settings, deps: [AuthService, UserService], multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }