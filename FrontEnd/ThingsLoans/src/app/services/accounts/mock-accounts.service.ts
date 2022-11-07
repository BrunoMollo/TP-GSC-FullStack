import { Injectable } from '@angular/core';
import { User } from 'src/app/entites/user';

@Injectable({
  providedIn: 'root'
})
export class MockAccountsService {

  constructor() { }

  async login(user:User):Promise<boolean>{
    throw new Error("no implementado")
  }

  private saveToken(jwt:string):void{
    throw new Error("no implementado")
  }

  isTokenValid():Promise<boolean>{
    throw new Error("no implementado")
  }

  getToken():string|null{
    throw new Error("no implementado")
  }

  disposeToken():void{
    throw new Error("no implementado")
  }


}
