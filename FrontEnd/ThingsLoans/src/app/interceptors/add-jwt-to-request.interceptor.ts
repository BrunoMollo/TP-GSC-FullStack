import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserApiService } from '../services/usersApi/user-api.service';

@Injectable()
export class AddJwtToRequestInterceptor implements HttpInterceptor {

  constructor(private readonly userService: UserApiService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token=this.userService.getToken()

    const updatedRequest= request = this.addToken(request, token ?? "")
    
    return next.handle(updatedRequest);
  }

  private addToken(request: HttpRequest<any>, token: string){
    return request.clone({
      setHeaders: {
        'Authorization': `Bearer ${token}`
      },
    })
  }
}
