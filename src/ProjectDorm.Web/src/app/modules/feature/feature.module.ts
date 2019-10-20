import { CoreModule } from './../core/core.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookingsComponent } from './components/bookings/bookings.component';
import { BrowserModule } from '@angular/platform-browser';
import { RoomsComponent } from './components/rooms/rooms.component';
import { BookRoomComponent } from './components/book-room/book-room.component';
import { AddBookingComponent } from './components/add-booking/add-booking.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    CoreModule
  ],
  declarations: [HomeComponent, LoginComponent, BookingsComponent, RoomsComponent, BookRoomComponent, AddBookingComponent]
})
export class FeatureModule { }
