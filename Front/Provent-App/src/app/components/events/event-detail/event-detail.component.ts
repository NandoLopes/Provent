import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {

  form: FormGroup = new FormGroup({});

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  validation(): void {
    this.form = this.fb.group({
      theme: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      place: ['', Validators.required],
      eventDate: ['', Validators.required],
      capacity: ['', [Validators.required, Validators.max(150000)]],
      imageURL: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });
  }

  resetForm(): void{
    this.form.reset();
  }

  cssValidator(form: FormControl): any {
    return {'is-invalid': form!.errors && form!.touched};
  }
}
