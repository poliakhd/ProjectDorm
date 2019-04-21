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
  pages: Array<number>;

  constructor(private apiService: ApiService) {
    this.bookings = new Paged<Booking>();
  }

  ngOnInit() {
    this.apiService.getBookings(1, 10)
      .subscribe(response => {
        this.bookings = response;
        this.pages = Array.from({length: this.bookings.pageCount}, (v, k) => k + 1);
      });
  }

  pageActive(index: number) {
    return {
      'active': index === this.bookings.currentPage
    };
  }

  pagePreviousDisabled() {
    return {
      'disabled': this.bookings.currentPage - 1 <= 0;
    };
  }

  pageNextDisabled() {
    return {
      'disabled': this.bookings.currentPage + 1 > this.bookings.pageCount
    };
  }

  page(pageNumber: number) {
    this.getBookings(pageNumber);
  }

  previousPage() {
    if (this.bookings.currentPage - 1 > 0) {
      this.getBookings(this.bookings.currentPage - 1);
    }
  }

  nextPage() {
    if (this.bookings.currentPage + 1 <= this.bookings.pageCount) {
      this.getBookings(this.bookings.currentPage + 1);
    }
  }

  getBookings(page: number, size: number = 10) {
    this.apiService.getBookings(page, size)
      .subscribe(response => {
        console.log(response);
        this.bookings = response;
      });
  }
}
