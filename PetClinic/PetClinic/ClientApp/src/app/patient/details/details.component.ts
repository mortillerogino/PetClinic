import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../shared/patient.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: []
})
export class DetailsComponent implements OnInit {

  constructor(private service:PatientService, private router: Router) { }

  ngOnInit() {
    if (this.service.currentPatient == null) {
      this.router.navigate(['/patient'])
    }
  }

}
