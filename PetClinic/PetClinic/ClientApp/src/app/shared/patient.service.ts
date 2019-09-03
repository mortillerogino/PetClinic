import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './models/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  currentPatient: Patient;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

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
}
