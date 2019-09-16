import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  loggedIn: boolean = false;
  userName: string;
  userRole: string;

  getPayload() {
    let user = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]))
    this.userName = user.unique_name;
    this.userRole = user.role;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login(formData) {
    return this.http.post(this.baseUrl + 'api/User/Login', formData);
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn = false;
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    allowedRoles.forEach(element => {
      if (this.userRole == element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
  

}
