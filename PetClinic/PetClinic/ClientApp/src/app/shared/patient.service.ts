import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './models/patient';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  currentPatient: Patient;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) { }

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
        console.log(data);
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
}
