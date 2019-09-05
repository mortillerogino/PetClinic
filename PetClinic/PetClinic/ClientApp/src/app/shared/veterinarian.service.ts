import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Veterinarian } from './models/veterinarian';

@Injectable({
  providedIn: 'root'
})
export class VeterinarianService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getVets() {
    return this.http.get<Veterinarian[]>(this.baseUrl + 'api/Veterinarian');
  }

}
