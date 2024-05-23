import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  @Input() title!: string;
  @Input() titleIcon: string = 'fa fa-user';
  @Input() subTitle: string = 'Your event manager';
  @Input() listButton: boolean = false;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  listItems(): void {
    this.router.navigate([`/${this.title.toLocaleLowerCase()}/list`]);
  }
}
