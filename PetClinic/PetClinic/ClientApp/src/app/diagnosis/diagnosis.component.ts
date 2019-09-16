import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DiagnosisService } from '../shared/diagnosis.service';

@Component({
  selector: 'app-diagnosis',
  templateUrl: './diagnosis.component.html',
  styles: []
})
export class DiagnosisComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: DiagnosisService) { }

  ngOnInit() {
    this.route.params.subscribe(value => {

      this.service.formModel.get('PatientId').setValue(value['id']);
      this.service.formModel.get('PatientName').setValue(value['name']);
    })

  }

}
