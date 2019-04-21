import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage.getItem('token');

        if (token != null) {
            const headers = new HttpHeaders({
                'Authorization': `Bearer ${token}`
            });

            const clone = req.clone({headers});

            return next.handle(clone);
        }

        return next.handle(req);
    }
}
