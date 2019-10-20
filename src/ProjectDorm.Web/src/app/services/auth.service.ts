import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../modules/core';
import { map } from 'rxjs/operators';
import { Subject, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5000/api/v1';

  private _isLoggedIn: Subject<any> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  login(userName: string, password: string) {
    return this.http.post<User>(this.baseUrl + '/user/authenticate', {userName, password})
      .pipe(map(response => {
        if (response && response.token) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('userName', response.userName);
        }

        this.isLoggedIn();

        return response;
      }));
  }

  logout() {
    localStorage.removeItem('token');
    this.isLoggedIn();
  }

  isLoggedIn() {
    this._isLoggedIn.next();
    return this._isLoggedIn.asObservable();
  }
}
