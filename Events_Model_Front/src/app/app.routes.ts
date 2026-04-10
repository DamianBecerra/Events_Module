import { Routes } from '@angular/router';
import { EventListComponent } from './components/event-list-component/event-list-component';

export const routes: Routes = [

    {
        path: '',
        component: EventListComponent
    },
    {
        path: 'eventos/:id', 
        component: EventListComponent
    }
];
