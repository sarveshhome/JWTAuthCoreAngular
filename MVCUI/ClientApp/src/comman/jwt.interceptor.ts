import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';


import { Token } from './security';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authenticationService: Token) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add auth header with jwt if user is logged in and request is to the api url
    
    
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.authenticationService.value}`
        }
      });
    

    return next.handle(request);
  }
}
