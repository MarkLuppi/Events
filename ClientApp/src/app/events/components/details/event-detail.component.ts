import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Event } from '../events/event';
import { EventsService } from '../../services/events.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: [ './event-detail.component.css' ]
})
export class EventDetailComponent implements OnInit {
  event: Event | undefined;

  constructor(
    private route: ActivatedRoute,
    private heroService: EventsService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getHero();
  }

  getHero(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.heroService.getEvent(id)
      .subscribe(event => this.event= event);
  }

  goBack(): void {
    this.location.back();
  }

}
