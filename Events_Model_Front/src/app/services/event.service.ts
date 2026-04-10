import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppEvent } from '../models/event.model';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private apiUrl = 'https://localhost:7029/api/Event';

  constructor(private http: HttpClient){

  }

  getEvents(page: number, size: number): Observable<AppEvent[]>{
    return this.http.get<AppEvent[]>(`${this.apiUrl}?page=${page}&pageSize${size}`);
  }

  getEventById(id: number): Observable<AppEvent>{
    return this.http.get<AppEvent>(`${this.apiUrl}/${id}`);
  }
  
}
