import { Component, OnInit, Inject } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Token } from '../../../comman/security';

@Component({
  selector: 'app-patientlogin',
  templateUrl: './patientlogin.component.html',
  styleUrls: ['./patientlogin.component.css']
})
export class PatientloginComponent implements OnInit {
  public apiUrl: string;
  constructor(private _http: HttpClient, private _token: Token) {
    this.apiUrl = environment.apiURL;
  }

  ngOnInit(): void {
      
  }

  loginclick() {
    var user: any = {};
    user.userName = "Sar";
    var observable = this._http.post(this.apiUrl + '/Login', user);
    observable.subscribe(res => this.Success(res), res => this.Error(res));
  }
  Success(res) {
    this._token.value = res;
  }
  Error(res) {
    console.log(res);
  }
}
