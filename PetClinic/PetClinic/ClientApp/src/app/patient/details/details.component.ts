import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../shared/patient.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: []
})
export class DetailsComponent implements OnInit {

  constructor(private service:PatientService) { }

  ngOnInit() {
  }

}
