import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FieldValidator } from '@app/helpers/FieldValidator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }
  
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: FieldValidator.FieldsMustMatch('password', 'confirmPassword')
    };

    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(15)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, formOptions
    );
  }  
}
