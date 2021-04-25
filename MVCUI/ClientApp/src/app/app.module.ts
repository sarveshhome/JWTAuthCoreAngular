import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PatientaddComponent } from './patient/patientadd/patientadd.component';
import { PatientloginComponent } from './patient/patientlogin/patientlogin.component';
import { Token } from '../comman/security';
import { AuthenticationGuard } from './authentication.guard';
import { SecurityLogic } from '../comman/SecurityCheck';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PatientaddComponent,
    PatientloginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'patientlogin', component: PatientloginComponent },
      //{ path: 'patientadd', component: PatientaddComponent, canActivate: [SecurityLogic] }
      { path: 'patientadd', component: PatientaddComponent, canActivate: [AuthenticationGuard] }
    ])
  ],
  //exports: [RouterModule], 
  providers: [Token, SecurityLogic, AuthenticationGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
