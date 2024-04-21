import { Component } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';


@Component({
  selector: 'app-caleandar',
  templateUrl: './caleandar.component.html',
  styleUrls: ['./caleandar.component.css']
})
export class CaleandarComponent {
  view: string = 'month';
  viewDate: Date = new Date();
  events: CalendarEvent[] = [
    {
      start: new Date(),
      title: 'An event',
      color: { primary: '#e3bc08', secondary: '#FDF1BA' }
    }
  ];

  handleEvent(event: CalendarEvent): void {
    console.log('Clicked', event);
  }
}
