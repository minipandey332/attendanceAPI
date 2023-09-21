import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  private apiUrl = 'https://localhost:7272'; // Replace with your API endpoint

  constructor(private http: HttpClient) { }

  // Fetch employees from the API
  getEmployees(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/Employee/read`);
  }
}
