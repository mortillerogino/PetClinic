import { Component, OnInit } from '@angular/core';
import { DiagnosisService } from '../../shared/diagnosis.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-diagnosis-form',
  templateUrl: './diagnosis-form.component.html',
  styles: []
})
export class DiagnosisFormComponent implements OnInit {

  constructor(private service: DiagnosisService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.service.postDiagnosis().subscribe(
      (res: any) => {
        this.toastr.success("Diagnosis Successfully Posted", "Saved");
        this.router.navigateByUrl('/patient');
      },
      err => {
        this.toastr.error(err.message, "Service Unavailable");
      }
    )
  }
}
