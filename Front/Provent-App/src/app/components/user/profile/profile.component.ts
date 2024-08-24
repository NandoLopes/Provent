import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FieldValidator } from '@app/helpers/FieldValidator';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  public title: string = 'Profile';
  
  form!: FormGroup;
  
  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: FieldValidator.FieldsMustMatch('password', 'confirmPassword')
    };

    this.form = this.fb.group({
      title: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      role: ['', Validators.required],
      description: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(250)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, formOptions
    );
  }

  onSubmit(): void {
    if (this.form.invalid)
      return;
  }

  resetForm(event: any): void {
    event.preventDefault();
    this.form.reset;
  }
}
