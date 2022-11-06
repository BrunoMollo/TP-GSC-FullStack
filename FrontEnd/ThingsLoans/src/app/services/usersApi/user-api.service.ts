import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  private readonly API=`${environment.api}/users`

  constructor(private http:HttpClient ) { }

  public login(user:any):Observable<boolean>{
    let url=`${this.API}/login`
    let body=JSON.stringify(user)
    
    return this.http.post<{token:string}>(url, body, {headers:{"Content-Type":"application/json"}})
          .pipe(map(resp=>resp.token))
          .pipe(map(this.saveToken))
          .pipe(catchError((err)=>of(false)))

  }

  public istokenValid():Observable<boolean>{
    let url=`${this.API}/checkToken`
    return this.http.get<{isValid:boolean}>(url)
          .pipe(map(resp=>resp.isValid))
  }

  private saveToken(jwt:string):boolean{
    localStorage.setItem("jwt", jwt);
    return true;
  }

  public getToken():string|null{
    return localStorage.getItem("jwt");
  }

  public disposeToken():void{
    localStorage.removeItem("jwt")
  }


}
