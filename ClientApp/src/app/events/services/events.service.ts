import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { EventsComponent } from '../components/events/events.component';
import {Event, EventDetails} from '../components/events/event';


@Injectable({ providedIn: 'root' })
export class EventsService {
  
  private baseUrl =  "localhost:7183";
  private eventsUrl =`https://${this.baseUrl}/api/events`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) {

  }
   
  /** GET heroes from the server */
  getEvents(): Observable<Event[]> {
    return this.http.get<any>(this.eventsUrl)
      .pipe(
        tap(ev => console.log('fetched events' + ev)),
        catchError(this.handleError<Event[]>('getEvents', []))
      );
  }

//   http.get<any>(this.baseUrl).subscribe(result => {
//     console.log(result);
//     this.eventsResult = result;
//   }, error => console.error(error));

  /** GET hero by id. Will 404 if id not found */
  getEvent(id: number): Observable<Event> {
    const url = `${this.eventsUrl}/${id}`;
    return this.http.get<Event>(url).pipe(
      tap(_ => this.log(`fetched event id=${id}`)),
      catchError(this.handleError<Event>(`getEvent id=${id}`))
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
