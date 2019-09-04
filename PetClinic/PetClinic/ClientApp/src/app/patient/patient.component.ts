import { Component, OnInit } from '@angular/core';
import { PatientService } from '../shared/patient.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styles: []
})
export class PatientComponent implements OnInit {

  patients:any = [];
  isDelete: boolean = false;

  constructor(private service: PatientService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getPatients()
      .toPromise()
      .then((data: any) => {
        this.patients = data;
      },
        err => {
          console.error(err)
        });
  }

  onDetailsClick(event, id) {
    if (!this.isDelete) {
      this.service.getPatient(id);
    }
    
    this.isDelete = false;
  }

  onDelete(id, name) {
    this.isDelete = true;
    if (confirm("Are you sure to delete " + name)) {
      this.service.delete(id).subscribe(
        (res: any) => {
          var index = this.patients.indexOf(res);
          this.deletePatientFromUI(id);
          this.toastr.success("Patient " + res.name + ' Deleted', 'Process Successful.');
        },
        err => {
          this.toastr.error(err, "Process Failed.");
        }
      );
    }
  }

  deletePatientFromUI(id) {
    let index = -1;
    for (var i = 0; i < this.patients.length; i++) {
      if (this.patients[i].id === id) {
        index = i;
      }
    }
    this.patients.splice(index, 1);
  }

}
