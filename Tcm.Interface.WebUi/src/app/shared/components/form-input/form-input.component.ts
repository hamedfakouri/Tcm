import { Component, OnInit, Input, ContentChild } from '@angular/core';
import { InputErrorDirective } from 'src/app/shared/directive';

@Component({
  selector: 'form-input',
  templateUrl: './form-input.component.html',
})
export class FormInputComponent implements OnInit {
  @Input() label: string;
  @Input() validations: { [index: string]: string };
  @Input() info: string;
  @ContentChild(InputErrorDirective) input: InputErrorDirective;
 
  get hasError() {

    return this.input.hasError;
  }

  get errors(){
    return  this.input.errors;
  }

 
  get value(){
    return this.input.formControl.value;
  }

  get errorMessages() {
    const errors = this.input.errors;
    const messages = [];
    const keys = Object.keys(this.validations);

    keys.forEach(key => {
      if (errors[key]) {
        messages.push(this.validations[key]);
      }
    });
    return messages;
  }
  ngOnInit() { }

  constructor() {


   }
}
