import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { pairs } from 'rxjs';

@Component({
  selector: 'app-patientadd',
  templateUrl: './patientadd.component.html',
  styleUrls: ['./patientadd.component.css']
})
export class PatientaddComponent implements OnInit {
  public apiUrl: string;
  constructor(private _http: HttpClient) {
    this.apiUrl = environment.apiURL;
  }

  ngOnInit(): void {

  
  }
  generateQuickGuid() {
  return Math.random().toString(36).substring(2, 15) +
    Math.random().toString(36).substring(2, 15);
}

  AddPatient() {

    var patient: any = {};
    patient.id = this.generateQuickGuid();
    patient.patientName = "Sarvesh";
    var observable = this._http.post(this.apiUrl + '/api/patient', patient);
    observable.subscribe(res => this.Success(res), res => this.Error(res));

  }
  Success(res) {
    
    console.log(res);
  }
  Error(res) {
    console.log(res);
  }

}
