import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar2',
  templateUrl: './navbar2.component.html',
  styleUrls: ['./navbar2.component.css']
})
export class Navbar2Component implements OnInit {
  
  ngOnInit(): void {
    this.updateTime();
    this.updateDate();
   
    setInterval(() => {
      this.updateTime();
    }, 1000);
  }


  constructor(){

  }

  updateTime() {
    const now = new Date();
    const timeElement = document.getElementById("time")!;
    timeElement.textContent = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  }
 
  updateDate() {
    const now = new Date();
    const dateElement = document.getElementById("date")!;
    dateElement.textContent = now.toDateString();
  }
}
