import { Component, OnInit } from '@angular/core';
import { DiagnosisService } from '../../shared/diagnosis.service';

@Component({
  selector: 'app-diagnosis-list',
  templateUrl: './diagnosis-list.component.html',
  styles: []
})
export class DiagnosisListComponent implements OnInit {

  constructor(private service: DiagnosisService) { }

  ngOnInit() {
    this.service.populateDiagnoses();
  }

}
