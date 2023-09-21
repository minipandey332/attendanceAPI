import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CalenderComponent } from './calender/calender.component';
import { AdminComponent } from './admin/admin.component';
import { Navbar2Component } from './navbar2/navbar2.component';


const routes: Routes = [
{path: "navbar" , component: Navbar2Component},
{path: "dashboard" , component: DashboardComponent},
{path:"calendar", component:CalenderComponent},
{path:"admin", component:AdminComponent},




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
