import { Component } from '@angular/core';
import { NgProgressModule } from 'ngx-progressbar';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent {
 // Define variables for weekly, monthly, and completed hours
 weeklyHours = 45; // Adjust this value as needed
 monthlyHours = 180; // Adjust this value as needed
 completedHoursForWeek = 40; // Change this value according to your data
 completedHoursForMonths = 100; 
 // Calculate remaining weekly and monthly hours
 remainingWeeklyHours = this.weeklyHours - this.completedHoursForWeek;
 remainingMonthlyHours = this.monthlyHours - this.completedHoursForMonths;

 // Calculate the completion percentage for both weekly and monthly
 weeklyCompletionPercentage = (this.completedHoursForWeek / this.weeklyHours) * 100;
 monthlyCompletionPercentage = (this.completedHoursForMonths / this.monthlyHours) * 100;

 // Set the progress bar color based on completion percentage
 progressBarColor = this.getProgressBarColor(this.weeklyCompletionPercentage);

 // Set the completion percentage for the progress bar
 completionPercentage = this.weeklyCompletionPercentage;

 // Function to determine progress bar color
 getProgressBarColor(percentage: number): string {
   if (percentage < 40) {
     return 'danger'; // Red
   } else if (percentage < 70) {
     return 'warning'; // Yellow
   } else {
     return 'success'; // Green
   }
 }
}
