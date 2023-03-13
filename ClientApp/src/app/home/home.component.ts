import { Component, OnInit } from '@angular/core';
import { Event } from '../events/components/events/event';
import { EventsService } from '../events/services/events.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  events: Event[] = [];

  constructor(private eventsService: EventsService) { }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents(): void {
    this.eventsService.getEvents()
    .subscribe((events: Event[]) => 
      {
        this.events = events
      });
  }
}
