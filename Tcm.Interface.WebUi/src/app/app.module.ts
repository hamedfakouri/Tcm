import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap';

import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { AuthServiceModule } from './authentication/services/auth-service.module';
import { CorporateServiceModule } from './corporate/services';
import { UserModule } from './user/user.module';
import { UtilityService, AlertifyService } from './shared/services';
import { JwtModule } from '@auth0/angular-jwt';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from './core/core.module';
import { ThemeModule } from './theme/theme.module';
import { routes } from './app-routing.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/Auth/login/login.component';
import { RegisterComponent } from './pages/Auth/register/register.component';
import { RequestPasswordComponent } from './pages/auth/request-password/request-password.component';
import { EducationCourseComponent } from './pages/baseInfo/educationCourse/educationCourse.component';
// import { AlertifyService } from './shared/services/alertify.service';
import { EducationcourseService } from './pages/baseInfo/educationCourse/services/educationcourse.service';
import { CorporateModule } from './corporate/corporate.module';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    RegisterComponent,
    RequestPasswordComponent,
    EducationCourseComponent
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
    EducationcourseService
    //{ provide: APP_INITIALIZER, useFactory: get_settings, deps: [AuthService, UserService], multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }