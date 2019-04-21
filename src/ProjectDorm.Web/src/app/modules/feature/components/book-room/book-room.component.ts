import { ApiService } from 'src/app/services';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DateRange } from 'src/app/modules/core/models/base/date-range.model';

@Component({
  selector: 'app-book-room',
  templateUrl: './book-room.component.html',
  styleUrls: ['./book-room.component.less']
})
export class BookRoomComponent implements OnInit {

  bookForm: FormGroup;
  roomId: number;

  availableDates: Array<DateRange>;

  formErrors: any;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.bookForm = this.formBuilder.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });

    this.roomId = this.route.snapshot.params['id'];

    this.apiService.getRoomAvailableDates(this.roomId)
      .pipe()
      .subscribe(response => this.availableDates = response);

    this.formErrors = [];
  }

  onSubmit() {
    if (this.bookForm.invalid) {
      return;
    }

    this.apiService.bookRoom(this.roomId, this.bookForm.controls.startDate.value, this.bookForm.controls.endDate.value)
      .pipe()
      .subscribe(response => {
        this.router.navigate(['/bookings']);
      }, error => {
        this.formErrors = error.error;
      });
  }
}
