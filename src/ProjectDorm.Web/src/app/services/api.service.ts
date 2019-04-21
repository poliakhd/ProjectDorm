import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Paged } from '../modules/core/models/base/paged.model';
import { Room } from '../modules/core/models/room.model';
import { Booking } from '../modules/core/models/booking.model';
import { DateRange } from '../modules/core/models/base/date-range.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'http://localhost:5000/api/v1';

  constructor(private http: HttpClient) { }

  getBookings(page: number, size: number): Observable<Paged<Booking>> {
    return this.http.get<Paged<Booking>>(this.baseUrl + `/booking/all?page=${page}&size=${size}`);
  }

  getRooms(page: number, size: number): Observable<Paged<Room>> {
    return this.http.get<Paged<Room>>(this.baseUrl + `/room/all?page=${page}&size=${size}`);
  }

  bookRoom(roomId: number, startDate: Date, endDate: Date): Observable<any> {
    return this.http.post<any>(this.baseUrl + '/booking/add', {'roomId': roomId, 'startDate': startDate, 'endDate': endDate});
  }

  getRoomAvailableDates(roomId: number): Observable<Array<DateRange>> {
    return this.http.get<Array<DateRange>>(this.baseUrl + `/room/${roomId}/available`);
  }

  getAvalaibleRooms(startDate: Date, endDate: Date, page: number, size: number): Observable<Paged<Room>> {
    return this.http.get<Paged<Room>>(
      this.baseUrl + `/room/all/available?startDate=${startDate}&endDate=${endDate}&page=${page}&size=${size}`
    );
  }
}
