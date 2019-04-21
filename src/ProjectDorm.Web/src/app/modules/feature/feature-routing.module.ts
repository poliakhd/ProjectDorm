import { AddBookingComponent } from './components/add-booking/add-booking.component';
import { BookRoomComponent } from './components/book-room/book-room.component';
import { AuthGuard } from './../../services/auth-guard.service';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent, BookingsComponent, RoomsComponent } from './';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'bookings',
        component: BookingsComponent
      },
      {
        path: 'rooms',
        component: RoomsComponent
      },
      {
        path: 'rooms/:id/book',
        component: BookRoomComponent
      },
      {
        path: 'booking/add',
        component: AddBookingComponent
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeatureRoutingModule { }
