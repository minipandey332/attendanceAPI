import { Component } from '@angular/core';
import { totalHrs } from 'src/assets/hrs';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserModule } from '@angular/platform-browser';
import { Color, ScaleType , LegendPosition} from '@swimlane/ngx-charts';

@Component({
  selector: 'app-timesheet',
  templateUrl: './timesheet.component.html',
  styleUrls: ['./timesheet.component.css']
})
export class TimesheetComponent {
  view!: [60, 60];
  colorScheme: Color = { 
    domain: ['#99CCE5', '#808080'], 
    group: ScaleType.Ordinal, 
    selectable: true, 
    name: 'Customer Usage', 
};

 

  totalHours = 9;
  completedHours = 5; // Change this value according to your data

 

  chartData = [
    {
      name: "Completed Hours",
      value: this.completedHours,
    },
    {
      name: "Remaining Hours",
      value: this.totalHours - this.completedHours,
    },
  ];

 

  ngOnInit(): void {
    // Calculate the percentage of completion
    const completionPercentage = (this.completedHours / this.totalHours) * 100;
    console.log('Completion Percentage:', completionPercentage);
  }

  // totalHrs: any[] | undefined;
  // view: [number, number] = [400, 200]; // Corrected the type of 'view'

  // options
  showLegend: boolean = true;
  showLabels: boolean = false;
  isDoughnut : boolean = true;
  public legendPosition: LegendPosition = LegendPosition.Below;
  title : string = "Status"

  // colorScheme = {
  //   domain: ['#5AA454', '#E44D25'],
  //   name: 'custom', // Example name
  //   selectable: true, // Example selectable property
  //   group: true 
  // };

  constructor() {
    Object.assign(this, { totalHrs });
  }

  onSelect(event: any) {
    console.log(event);
  }
}
