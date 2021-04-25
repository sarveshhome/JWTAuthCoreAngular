import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Token } from '../comman/security';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {

  constructor(private _router: Router, private _token: Token) {
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this._token.value.length != 0) {
      return true;
    }

    // navigate to login page
    this._router.navigate(['patientadd'], { queryParams: { returnUrl: state.url } });
    // you can save redirect url so after authing we can move them back to the page they requested
    return false;
  }
  
}
