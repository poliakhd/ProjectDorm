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

  constructor(private apiService: ApiService) {
    this.rooms = new Paged<Room>();
  }

  ngOnInit() {
    this.apiService.getRooms(1, 10)
      .subscribe(response => {
        this.rooms = response;
      });
  }

  page(page: number) {
    this.getRooms(page);
  }

  previousPage(page: number) {
    this.getRooms(page);
  }

  nextPage(page: number) {
    this.getRooms(page);
  }

  getRooms(page: number, size: number = 10) {
    this.apiService.getRooms(page, size)
      .subscribe(response => {
        console.log(response);
        this.rooms = response;
      });
  }
}
