import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})



export class UserApiService {

  private readonly API=`${environment.api}/users`

  constructor(private readonly http:HttpClient) { }

  login(user:any){
    let url=`${this.API}/login`
    let body=JSON.stringify(user)

    this.http.post<{token:string}>(url, body, {headers:{"Content-Type":"application/json"}})
          .pipe(map(resp=>resp.token))
          .subscribe(this.saveToken)
  }

  private saveToken(jwt:string):void{
    localStorage.setItem("jwt", jwt);
  }

  public getToken():string|null{
    return localStorage.getItem("jwt");
  }



}
