import { Booking } from './../../../core/models/booking.model';
import { Paged } from './../../../core/models/base/paged.model';
import { ApiService } from './../../../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.less']
})
export class BookingsComponent implements OnInit {

  bookings: Paged<Booking>;

  constructor(private apiService: ApiService) {
    this.bookings = new Paged<Booking>();
  }

  ngOnInit() {
    this.apiService.getBookings(1, 10)
      .subscribe(response => {
        this.bookings = response;
      });
  }

  page(page: number) {
    this.getBookings(page);
  }

  previousPage(page: number) {
    this.getBookings(page);
  }

  nextPage(page: number) {
    this.getBookings(page);
  }

  getBookings(page: number, size: number = 10) {
    this.apiService.getBookings(page, size)
      .subscribe(response => {
        console.log(response);
        this.bookings = response;
      });
  }
}
