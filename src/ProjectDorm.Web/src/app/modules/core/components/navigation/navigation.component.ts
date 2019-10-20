import { AuthService } from 'src/app/services';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.less']
})
export class NavigationComponent implements OnInit {

  hasBearer: boolean;
  userName: string;

  constructor(
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.authService.isLoggedIn().subscribe(s => this.isLoggedIn());
  }

  isLoggedIn () {
    this.hasBearer = true;

    if (localStorage.getItem('token') == null) {
      this.hasBearer = false;
    }

    this.userName = localStorage.getItem('userName');
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
