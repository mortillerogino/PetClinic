import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../shared/patient.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styles: []
})
export class AddComponent implements OnInit {

  constructor(private service: PatientService, private toastr: ToastrService, private userService: UserService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.service.add().subscribe(
      (res: any) => {
        this.service.newPatientForm.reset();
        this.toastr.success("Patient " + res.name + ' Submitted', 'Process Successful.');
      },
      err => {
        this.toastr.error(err.error.Message, "Process Failed.");
      })
  }
}
