import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { AppEvent } from '../../models/event.model';
import { CommonModule, DatePipe, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';

declare var bootstrap: any;

@Component({
  selector: 'app-event-list-component',
  imports: [CommonModule, 
            FormsModule, 
            DatePipe,
          ],
  templateUrl: './event-list-component.html',
  styleUrl: './event-list-component.css',
})
export class EventListComponent implements OnInit{

  events: AppEvent[] = [];
  startDate: string = '';
  endDate: string = '';
  allEvents: any[] = [];

  selectedEvent: any = null;

  currentPage: number = 1;
  totalPages: number = 10;
  totalEvents: number = 0;


  constructor(private eventService: EventService, 
    private cdr: ChangeDetectorRef,
    private route: ActivatedRoute,
    private router: Router
  ){
    
  }

  ngOnInit(): void{
      this.loadEvents();

    }

  loadEvents(): void{
    this.eventService.getEvents(this.currentPage, this.totalPages).subscribe({
      next: (response: any) => {
        this.allEvents = response.data;
        this.events = response.data;
        this.currentPage = response.currentPage;
        this.totalPages = response.totalPages;
        this.totalEvents = response.totalEvents;
        this.cdr.detectChanges();
        //console.log('Eventos cargados', this.events)
      },
      error: (err) => {
        console.log('Error al conectar con la api', err);
      }
    })
  }

  changePage(newPage: number){
    this.currentPage = newPage;
    this.loadEvents();
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

  openEventModal(id: number): void {
    this.eventService.getEventById(id).subscribe({
      next: (response: any) => {
        this.selectedEvent = response;
        this.cdr.detectChanges();

        const modalElement = document.getElementById('eventModal');
        if (modalElement) {
          const modal = new bootstrap.Modal(modalElement);
          modal.show();
        }
      },
      error: (err) => console.error('Error al cargar detalle', err)
    });
  }

  closeModal(): void {
  this.router.navigate(['/eventos']);
  }

}
