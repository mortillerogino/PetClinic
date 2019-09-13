import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  loggedIn: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login(formData) {
    return this.http.post(this.baseUrl + 'api/User/Login', formData);
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn = false;
  }
}
