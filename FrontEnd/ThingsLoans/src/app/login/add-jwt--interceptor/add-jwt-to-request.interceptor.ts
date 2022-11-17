import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountsService } from '../accounts--service/accounts.service';

@Injectable()
export class AddJwtToRequestInterceptor implements HttpInterceptor {

  constructor(private readonly accountsService: AccountsService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token=this.accountsService.getToken()

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
