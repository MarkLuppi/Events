import { Injectable } from '@angular/core';
import { DatePipe} from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {Event, EventDetails} from '../components/events/event';



@Injectable({ providedIn: 'root' })
export class EventsService {
  //Note: lots of problems with this file.  Fix it some other time, at least it's able to pull the data

  //yes, this is a temporary HACK to get the launch settings url.  Not working
  // and no time to fix it.  I hope it's ok for the time being.
  private baseUrl =  "https://localhost:7183";
  
  private eventsUrl =`${this.baseUrl}/api/events`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  datepipe: DatePipe = new DatePipe('en-US');
  constructor(
    private http: HttpClient) {

  }
   
  /** GET events from the server */
  getEvents(): Observable<Event[]> {
    return this.http.get<any>(this.eventsUrl)
      .pipe(
        tap(ev => console.log('fetched events' + ev)),
        catchError(this.handleError<Event[]>('getEvents', []))
      );
  }


  /** GET hero by id. Will 404 if id not found */
  getEvent(id: number): Observable<EventDetails> {
    const url = `${this.eventsUrl}/${id}`;
    return this.http.get<EventDetails>(url).pipe(
      tap(ev => console.log(`fetched event id=${ev}`)),
      catchError(this.handleError<EventDetails>(`getEvent id=${id}`))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a EventService message with the MessageService */
  private log(message: string) {
    console.log(`EventService: ${message}`);
  }
}
