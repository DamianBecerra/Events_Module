import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { AppEvent } from '../../models/event.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-event-list-component',
  imports: [DatePipe],
  templateUrl: './event-list-component.html',
  styleUrl: './event-list-component.css',
})
export class EventListComponent implements OnInit{

  events: AppEvent[] = [];

  constructor(private eventService: EventService, 
    private cdr: ChangeDetectorRef){
    
  }

  ngOnInit(): void{
      this.loadEvents();
    }

  loadEvents(): void{
    this.eventService.getEvents().subscribe({
      next: (response: any) => {
        this.events = response.data;
        this.cdr.detectChanges();
        console.log('Eventos cargados', this.events)
      },
      error: (err) => {
        console.log('Error al conectar con la api', err);
      }
    })
  }

}
