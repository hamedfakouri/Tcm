import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/shared/services';
import { AuthService } from 'src/app/authentication/services';
import { Subscription } from 'rxjs';
import { User } from '../../models/login';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})

export class LoginComponent implements OnDestroy {

  user: User = new User();
  subscription: Subscription;
  constructor(protected router: Router, private loginService: AccountService,
    private alertify: AlertifyService, private authService: AuthService) {

  }

  login(): void {

    this.subscription = this.loginService.login(this.user).subscribe(res => {

      if(res){
        this.authService.setAuthorizationHeaderValue(res);
        this.alertify.success('خوش آمدید.');
        this.authService.loginAccures.next(true);
        this.router.navigate(['']);
      }
    

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
