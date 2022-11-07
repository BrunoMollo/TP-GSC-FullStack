import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { User } from 'src/app/entites/user';
import { environment } from 'src/environments/environment';


const API=`${environment.api}/users`

@Injectable({
  providedIn: 'root'
})
export class UserApiService{

  constructor(private http:HttpClient) { }

  public login(user:User):Observable<string|null>{
    let url=`${API}/login`
    let body=JSON.stringify(user)
    
    return this.http.post<{token:string}>(url, body, {headers:{"Content-Type":"application/json"}})
          .pipe(map(resp=>resp.token))
          .pipe(catchError((err)=>of(null)))
  }

  public checkToken():Observable<boolean>{
    let url=`${API}/checkToken`
    return this.http.get<{isValid:boolean}>(url)
          .pipe(map(resp=>resp.isValid))
  }

  
}
