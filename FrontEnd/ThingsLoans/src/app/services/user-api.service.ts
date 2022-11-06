import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
    this.http.post<String>(url,body).subscribe(jwt=>console.log(jwt))

  }



}
