import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  formModel = {
    UserName: '',
    Password: ''
  }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.service.loggedIn = true;
      this.router.navigateByUrl('/home');
    }
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        this.toastr.error(err.error.Message, "Login Error");
      }
      
    );
  }

}
