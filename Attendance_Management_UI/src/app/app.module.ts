import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TimesheetComponent } from './timesheet/timesheet.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { AttendanceListComponent } from './attendance-list/attendance-list.component';
import { AnnualHolidaysComponent } from './annual-holidays/annual-holidays.component';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';

import { FlatpickrModule } from 'angularx-flatpickr';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { FullCalendarModule } from '@fullcalendar/angular';
import { CalenderComponent } from './calender/calender.component';
import { NgProgressModule } from 'ngx-progressbar';
import { AdminComponent } from './admin/admin.component';
import { Navbar2Component } from './navbar2/navbar2.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    TimesheetComponent,
    StatisticsComponent,
    AttendanceListComponent,
    AnnualHolidaysComponent,
    CalenderComponent,
    AdminComponent,
    Navbar2Component
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ProgressbarModule.forRoot(),
    FlatpickrModule.forRoot(),
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),

    ReactiveFormsModule,
    FormsModule,
    FullCalendarModule,
    NgProgressModule
     
  ],

  exports: [],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA], // Add CUSTOM_ELEMENTS_SCHEMA here
  bootstrap: [AppComponent]
})
export class AppModule { }
