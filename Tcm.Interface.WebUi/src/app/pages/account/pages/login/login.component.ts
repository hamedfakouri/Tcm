import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/shared/services';
import { AuthService } from 'src/app/authentication/services';
import { Subscription } from 'rxjs';
import { Login } from '../../models/login';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})

export class LoginComponent implements OnDestroy {

  user: Login = { userName: '', password: '' };
  subscription: Subscription;
  constructor(protected router: Router, private loginService: AccountService,
    private alertify: AlertifyService, private authService: AuthService) {

  }

  login(): void {

    this.subscription = this.loginService.login(this.user).subscribe(res => {
      //const res = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1NDcwNjY1NTgsImV4cCI6MTU3ODYwMjU1OCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.5RdRE874nH0JtqZsEXfCykovED_bPmnuq4lVpAIg5WY"
      this.authService.setAuthorizationHeaderValue(res);
      this.alertify.success('خوش آمدید.');

      this.authService.loginAccures.next(true);

      this.router.navigate(['']);

    }, error => {

      if (error.status == 404) {
        this.alertify.error('اطلاعات معتبر نمی باشد.');
      }

    });
  }

  ngOnDestroy(): void {
    if (this.subscription)
      this.subscription.unsubscribe();
  }
}
