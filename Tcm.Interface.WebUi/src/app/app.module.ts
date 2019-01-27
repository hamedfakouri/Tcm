import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { routes } from './app-routing.module';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ThemeModule } from './theme/theme.module';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { AuthServiceModule } from './authentication/services/auth-service.module';
import { UtilityService, AlertifyService } from './shared/services';
import { JwtModule } from '@auth0/angular-jwt';
import { CoreModule } from './core/core.module';
import { EducationLevelService } from './pages/baseInfo/educationLevel/services/educationlevel.service';
import { EducationCourseService } from './pages/baseInfo/educationCourse/services/educationcourse.service';
import { MajorService } from './pages/baseInfo/major/services/major.service';
import { AuthService } from './authentication/services';
import { EducationSubCourseService } from './pages/baseInfo/educationSubCourse/services/educationsubcourse.service';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
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
    AuthService,
    UtilityService,
    AlertifyService,
    EducationLevelService,
    EducationCourseService,
    MajorService,
    EducationSubCourseService
    //{ provide: APP_INITIALIZER, useFactory: get_settings, deps: [AuthService, UserService], multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }