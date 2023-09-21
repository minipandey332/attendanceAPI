import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HolidayService {
  private holidayApiUrl = 'https://date.nager.at/Api/v2/PublicHoliday';

  constructor(private http: HttpClient) { }

  getHolidaysForYear(year: number, countryCode: string = 'IN'): Observable<any> {
    return this.http.get(`${this.holidayApiUrl}/${year}/${countryCode}`);
  }
}
