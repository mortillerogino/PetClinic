import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './models/patient';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  currentPatient: Patient;

  updatePatientForm = this.fb.group({
    Name: ['', Validators.required]
  })

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private fb: FormBuilder,
    private router: Router) { }

  newPatientForm = this.fb.group({
    Name: ['', Validators.required]
  });

  getPatients() {
    return this.http.get<Patient[]>(this.baseUrl + 'api/Patient');
  }

  getPatient(id: string) {
    this.http.get<Patient>(this.baseUrl + 'api/Patient/' + id)
      .toPromise()
      .then((data: any) => {
        this.currentPatient = data;
        this.router.navigate(['patient/details']);
      },
        err => {
          console.error(err)
        });;
  }

  add() {
    var body = {
      Name: this.newPatientForm.value.Name
    }
    return this.http.post(this.baseUrl + 'api/Patient', body);
  }

  update(id: string) {
    var body = {
      Name: this.updatePatientForm.value.Name
    }
    return this.http.put(this.baseUrl + 'api/Patient/' + id, body)
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + 'api/Patient/' + id);
  }
}
