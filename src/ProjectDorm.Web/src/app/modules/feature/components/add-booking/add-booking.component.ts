import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/services';
import { Room } from 'src/app/modules/core/models/room.model';
import { Paged } from 'src/app/modules/core/models/base/paged.model';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.less']
})
export class AddBookingComponent implements OnInit {

  bookingForm: FormGroup;
  formErrors: any;

  rooms: Paged<Room>;

  roomId: number;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.bookingForm = this.formBuilder.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });

    this.formErrors = [];
    this.rooms = new Paged<Room>();
  }

  controls() {
    return this.bookingForm.controls;
  }

  page(page: number) {
    this.getRooms(this.controls().startDate.value, this.controls().endDate.value, page);
  }

  previousPage(page: number) {
    this.getRooms(this.controls().startDate.value, this.controls().endDate.value, page);
  }

  nextPage(page: number) {
    this.getRooms(this.controls().startDate.value, this.controls().endDate.value, page);
  }

  selectRoom(id: number) {
    this.roomId = id;
  }

  findRooms() {
    this.getRooms(this.controls().startDate.value, this.controls().endDate.value, 1);
  }

  getRooms(startDate: Date, endDate: Date, page: number, size: number = 10) {
    this.apiService.getAvalaibleRooms(startDate, endDate, page, size)
      .subscribe(response => {
        this.rooms = response;
      });
  }

  onSubmit() {
    if (this.bookingForm.invalid) {
      return;
    }

    this.apiService.bookRoom(this.roomId, this.controls().startDate.value, this.controls().endDate.value)
      .pipe()
      .subscribe(response => {
        this.router.navigate(['/bookings']);
      }, error => {
        this.formErrors = error.error;
      });
  }
}
