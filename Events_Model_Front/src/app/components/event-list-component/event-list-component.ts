import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { AppEvent } from '../../models/event.model';
import { CommonModule, DatePipe, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-event-list-component',
  imports: [CommonModule, 
            FormsModule, 
            DatePipe, 
            DecimalPipe

          ],
  templateUrl: './event-list-component.html',
  styleUrl: './event-list-component.css',
})
export class EventListComponent implements OnInit{

  events: AppEvent[] = [];
  startDate: string = '';
  endDate: string = '';
  allEvents: any[] = [];

  constructor(private eventService: EventService, 
    private cdr: ChangeDetectorRef){
    
  }

  ngOnInit(): void{
      this.loadEvents();
    }

  loadEvents(): void{
    this.eventService.getEvents().subscribe({
      next: (response: any) => {
        this.allEvents = response.data;
        this.events = response.data;
        this.cdr.detectChanges();
        //console.log('Eventos cargados', this.events)
      },
      error: (err) => {
        console.log('Error al conectar con la api', err);
      }
    })
  }

  filterByDate(): void {
    if(!this.startDate || !this.endDate){
      this.events = [...this.allEvents];
      return;
    }

    const start = new Date(this.startDate + 'T00:00:00');
    const end = new Date(this.endDate + 'T23:59:59');

    this.events = this.allEvents.filter(event =>{
      const eventDate = new Date(event.date);
      return eventDate >= start && eventDate <= end;
    });
    //console.log(this.allEvents);
  }

  clearFilters(): void{
    this.startDate = '';
    this.endDate = '';
    this.loadEvents();
  }

}
