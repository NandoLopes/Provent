import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { EventService } from '../../../services/event.service';
import { Event } from '../../../models/Event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {

  modalRef: BsModalRef = new BsModalRef;
  public events: Event[] = [];
  public filteredEvents: Event[] = [];

  imgWidth: number = 80;
  imgMargin: number = 2;

  isCollapsed: boolean = false;

  private _listFilter: string = '';

  public get listFilter(): string{
    return this._listFilter;
  }

  public set listFilter(value: string){
    this._listFilter = value;
    this.filteredEvents = this.listFilter ? this.filterEvents(this.listFilter) : this.events;
  }

  filterEvents(filterBy: string): Event[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: any) => event.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
                       event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

    ngOnInit() {
      this.spinner.show();
      this.getEvents();
    }

    public getEvents(): void{
      this.eventService.getEvents().subscribe({
        next: (events: Event[]) => {
          this.events = events;
          this.filteredEvents = this.events;
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Error loading events.', 'Error!');
        },
        complete: () => this.spinner.hide()
    });
    }

    openModal(template: TemplateRef<any>): void {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    confirm(): void {
      this.toastr.success("Worked ;)", "Success!");
      this.modalRef.hide();
    }

    decline(): void {
      this.modalRef.hide();
    }

    eventDetail(eventId: number): void {
      this.router.navigate([`events/detail/${eventId}`])
    }
  }
