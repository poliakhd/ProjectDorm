import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Paged } from '../modules/core/models/base/paged.model';
import { Room } from '../modules/core/models/room.model';
import { Booking } from '../modules/core/models/booking.model';
import { DateRange } from '../modules/core/models/base/date-range.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'http://localhost:5000/api/v1';

  constructor(private http: HttpClient) { }

  getBookings(page: number, size: number) {
    return this.http.get<Paged<Booking>>(this.baseUrl + `/booking/all?page=${page}&size=${size}`);
  }

  getRooms(page: number, size: number) {
    return this.http.get<Paged<Room>>(this.baseUrl + `/room/all?page=${page}&size=${size}`);
  }

  bookRoom(roomId: number, startDate: Date, endDate: Date) {
    return this.http.post<any>(this.baseUrl + '/booking/add', {'roomId': roomId, 'startDate': startDate, 'endDate': endDate});
  }

  getRoomAvailableDates(roomId: number) {
    return this.http.get<Array<DateRange>>(this.baseUrl + `/room/${roomId}/available`);
  }
}
