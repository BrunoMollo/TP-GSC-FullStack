import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MockUserApiService {

  constructor() { }

  public login(user:any):Observable<string|null>{
    return new Observable<string|null>()
  }

  public checkToken():Observable<boolean>{
    return new Observable<boolean>()
  }

  
}
