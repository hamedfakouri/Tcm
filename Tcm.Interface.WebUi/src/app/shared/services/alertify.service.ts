import { Injectable } from '@angular/core';
import { EducationLevelService } from 'src/app/pages/baseInfo/educationLevel/services/educationlevel.service';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() {
    alertify.defaults.glossary.ok = 'بلی';
    alertify.defaults.glossary.cancel = 'بستن';
    alertify.defaults.glossary.title = 'علوم راهبردی ایده';
    alertify.defaults.theme.ok = 'btn btn-primary';
    alertify.defaults.theme.cancel = 'btn btn-warning';

    alertify.defaults.notifier.position = 'bottom-left';
    alertify.defaults.notifier.delay = 15;
    //alertify.defaults.notifier.closeButton = true;
   }

  //this.alertify.prompt('با موفقیت ذخیره شد.','aaa' , ()=> {} , () => {});
  prompt(title, value, successCallBack, errorCallBack) {
    alertify.prompt(title, value,
      function (evt, value) {
        successCallBack();
      },
      function () {
        errorCallBack();
      })
      ;
  }

  deleteConfirm(message: string, callBack: (item?: any) => any,params?: any, cancelCallBack?: () => any) {

    alertify.confirm(message, function (e,item) {

      if (e) {
        callBack(params);
      }
      else{
        cancelCallBack();
      }

    });

  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  message(message: string) {
    alertify.warning(message);
  }

}
