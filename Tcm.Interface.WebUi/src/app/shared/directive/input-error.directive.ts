
import { Directive, ElementRef  } from '@angular/core';
import { NgControl } from '@angular/forms';
import { dirtyParentQueries } from '@angular/core/src/view/query';


@Directive({
  selector: '[InputError]'
})
export class InputErrorDirective {

  constructor(public formControl: NgControl,el: ElementRef) {
    // el.nativeElement.style.backgroundColor = 'yellow';
  }

  get hasError() {
    return this.formControl.dirty && this.formControl.invalid;
  }

  get errors() {
    if (this.hasError && this.formControl.errors) {
      return this.formControl.errors;
    }
    return '';
  }
  get invalid(){

    return this.formControl.invalid;
  }

  get showError(){
    return this.formControl.dirty && (this.formControl.dirty || this.formControl.touched);
  }


}


