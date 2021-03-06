import { Injectable, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';


@Injectable({
  providedIn: 'root'
})
export class DiagnosisService {

  patientId: string;
  patientName: string;
  diagnoses: string[];

  formModel = this.fb.group({
    PatientName: [{value: "", disabled: true}],
    PatientId: [{value: "", disabled: true}],
    Notes: ['', Validators.required]
  })

  constructor(private http: HttpClient, private fb: FormBuilder, @Inject('BASE_URL') private baseUrl: string, private toastr: ToastrService) { }

  postDiagnosis() {
    var body = {
      Notes: this.formModel.get("Notes").value,
      PatientId: this.formModel.get("PatientId").value
    }
    return this.http.post(this.baseUrl + 'api/Diagnosis', body);
  }

  getDiagnoses() {
    return this.http.get(this.baseUrl + 'api/Diagnosis/' + this.patientId);
  }

  populateForm() {
    this.formModel.get('PatientId').setValue(this.patientId);
    this.formModel.get('PatientName').setValue(this.patientName);
  }

  populateDiagnoses() {
    this.getDiagnoses().subscribe(
      (res: any) => {
        this.diagnoses = res;
      },
      err => {
        this.toastr.error(err.error.Message, "Cannot get Diagnoses");
      }
    )
  }
}
