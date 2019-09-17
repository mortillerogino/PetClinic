import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../shared/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private userService: UserService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    let tokenExists = localStorage.getItem('token') != null;
    if (tokenExists) {

      this.userService.loggedIn = true;
      this.userService.getPayload();
      let roles = next.data['permittedRoles'] as Array<string>;
      if (roles) {
        if (this.userService.roleMatch(roles)) {
          return true;
        }
        else {
          this.router.navigate(['/forbidden']);
          return false;
        }
      }

      return true;
    }
    else {
      this.router.navigateByUrl('unauthorized');
      this.userService.loggedIn = false;
    }
  }
}
