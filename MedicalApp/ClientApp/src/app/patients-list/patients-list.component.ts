import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PatientsListService } from './patients-list.service';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.css']
})
export class PatientsListComponent implements OnInit {
  public patientsList;

  constructor(private _httpClient: HttpClient, private _patientsListService: PatientsListService) {
  }

  ngOnInit() {
    this.getPatientsList();
  }

  getPatientsList() {
    this._patientsListService.getPatientsList().subscribe(
      data => { this.patientsList = data },
      err => console.error(err),
      () => console.log('done loading patients')
    );
  }
}
