import { Component, OnInit } from '@angular/core';
import { PatientService } from '../shared/patient.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styles: []
})
export class PatientComponent implements OnInit {

  patients:any = [];

  constructor(private service: PatientService) { }

  ngOnInit() {
    this.service.getPatients()
      .toPromise()
      .then((data: any) => {
        this.patients = data;
        console.log(this.patients);
      },
        err => {
          console.error(err)
        })
  }

}
