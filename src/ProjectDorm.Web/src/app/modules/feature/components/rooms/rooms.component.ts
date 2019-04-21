import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/modules/core/models/room.model';
import { Paged } from 'src/app/modules/core/models/base/paged.model';
import { ApiService } from 'src/app/services';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.less']
})
export class RoomsComponent implements OnInit {

  rooms: Paged<Room>;
  pages: Array<number>;

  constructor(private apiService: ApiService) {
    this.rooms = new Paged<Room>();
  }

  ngOnInit() {
    this.apiService.getRooms(1, 10)
      .subscribe(response => {
        this.rooms = response;
        this.pages = Array.from({length: this.rooms.pageCount}, (v, k) => k + 1);
      });
  }

  pageActive(index: number) {
    return {
      'active': index === this.rooms.currentPage
    };
  }

  pagePreviousDisabled() {
    return {
      'disabled': this.rooms.currentPage - 1 <= 0;
    };
  }

  pageNextDisabled() {
    return {
      'disabled': this.rooms.currentPage + 1 > this.rooms.pageCount
    };
  }

  page(pageNumber: number) {
    this.getRooms(pageNumber);
  }

  previousPage() {
    if (this.rooms.currentPage - 1 > 0) {
      this.getRooms(this.rooms.currentPage - 1);
    }
  }

  nextPage() {
    if (this.rooms.currentPage + 1 <= this.rooms.pageCount) {
      this.getRooms(this.rooms.currentPage + 1);
    }
  }

  getRooms(page: number, size: number = 10) {
    this.apiService.getRooms(page, size)
      .subscribe(response => {
        console.log(response);
        this.rooms = response;
      });
  }
}
