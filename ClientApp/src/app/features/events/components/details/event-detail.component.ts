import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location, DatePipe } from '@angular/common';

import { Event, EventDetails } from '../events/event';
import { EventsService } from '../../services/events.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: [ './event-detail.component.css' ]
})
export class EventDetailComponent implements OnInit {
  event: EventDetails | undefined;
  datepipe: DatePipe = new DatePipe('en-US');
  constructor(
    private route: ActivatedRoute,
    private heroService: EventsService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getEvent();
  }

  getEvent(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.heroService.getEvent(id)
      .subscribe(event => {
        this.event= event;
        this.event.date = this.datepipe.transform(this.event.date, 'dd-MMM-YYYY')??"";
      });
  }

  goBack(): void {
    this.location.back();
  }

}
