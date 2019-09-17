import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router, private service: UserService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let tokenValue = localStorage.getItem('token');
    if (tokenValue != null) {
      const clonedReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
      });
      return next.handle(clonedReq).pipe(
        tap(
          succ => { },
          err => {
            if (tokenValue != null && err.status === 401) {
              this.service.logout();
              this.router.navigateByUrl('expired');
            }
            else if (err.status === 401) {
              this.router.navigateByUrl('unauthorized');
            }
            else if (err.status === 403) {
              this.router.navigateByUrl('forbidden');
            }
          }
        )
      )
    }
    else {
      return next.handle(req.clone());
    }
  }
}
