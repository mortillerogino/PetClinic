import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../../shared/patient.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styles: []
})
export class EditComponent implements OnInit {

  constructor(private service: PatientService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    if (this.service.currentPatient == null) {
      this.router.navigate(['/patient'])
    }
  }

  onSubmit() {
    this.service.update(this.service.currentPatient.id).subscribe(
      (res: any) => {
        this.router.navigate(['/patient'])
        this.toastr.success("Patient " + res.name + ' Updated', 'Process Successful.');
      },
      err => {
        this.toastr.error(err.error.Message, "Process Failed.");
      }
    )
  }

}
