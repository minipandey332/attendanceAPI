import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import { HolidayService } from 'src/service/holiday.service';

@Component({
  selector: 'app-calender',
  templateUrl: './calender.component.html',
  styleUrls: ['./calender.component.css']
})
export class CalenderComponent implements OnInit {

  constructor(){}

  ngOnInit(): void {
    
  }
  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    plugins: [dayGridPlugin],
    events: this.generateEvents()
  };

  // getHolidayEvents(): void {
  //   this.holiday.getHolidaysForYear(new Date().getFullYear()).subscribe(data => {
  //     const events = this.generateEvents(data);
  //     this.calendarOptions.events = events;
  //   });
  // }

  

  generateEvents() {
    const today = new Date();
    const year = today.getFullYear();
    const events = [];

    // Loop through all months of the year
    for (let month = 0; month < 12; month++) {
      const date = new Date(year, month, 1);

      // Add an event for each Saturday and Sunday in the current month
      while (date.getMonth() === month) {
        const dayOfWeek = date.getDay();

        if (dayOfWeek === 0 || dayOfWeek === 1) { // Saturday or Sunday
          events.push({
            start: date.toISOString().slice(0, 10),
            backgroundColor: 'blue' // Set the background color for Saturdays and Sundays
          });
        }

        date.setDate(date.getDate() + 1); // Move to the next day
      }
    }

    

    return events;
  }
}
