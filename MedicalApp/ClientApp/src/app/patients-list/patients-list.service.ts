import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class PatientsListService {

  constructor(private http: HttpClient) { }

  patientListUrl = "api/Patient/GetPatients";

  getPatientsList() {
    return this.http.get(this.patientListUrl);
  }
}
