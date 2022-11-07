import { Injectable } from '@angular/core';
import { firstValueFrom, map } from 'rxjs';
import { User } from 'src/app/entites/user';
import { UserApiService } from '../usersApi/user-api.service';

const LOCAL_STORAGE_KEY="jwt"

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  static LOCAL_STORAGE_KEY=LOCAL_STORAGE_KEY

  constructor(private userApi:UserApiService) { }


  async login(user:User):Promise<boolean>{
    const observable=this.userApi.login(user)
    const token= await firstValueFrom(observable) 

    if(token!=null){
      this.saveToken(token)
      return true
    }
    else return false
    
  }

  saveToken(jwt:string):void{
    localStorage.setItem(LOCAL_STORAGE_KEY, jwt);
  }

  isTokenValid():Promise<boolean>{
    const observable=this.userApi.checkToken()
    return firstValueFrom(observable)
  }

  getToken():string|null{
    return localStorage.getItem(LOCAL_STORAGE_KEY);
  }

  disposeToken():void{
    localStorage.removeItem(LOCAL_STORAGE_KEY)
  }


}
