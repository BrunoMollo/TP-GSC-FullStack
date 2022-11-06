import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AccountsService } from '../services/accounts/accounts.service';

@Injectable({
  providedIn: 'root'
})
export class IsLoggedInGuard implements CanActivate {

  constructor(private readonly accountsService:AccountsService){}

  canActivate( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
      return this.accountsService.isTokenValid();
  }
  
}
