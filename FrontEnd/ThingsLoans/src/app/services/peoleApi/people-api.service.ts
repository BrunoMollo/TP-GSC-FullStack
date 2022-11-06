import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleApiService {

  private readonly API=`${environment.api}/people`

  constructor(private readonly http:HttpClient) { }

  getAll(){  
    let url=`${this.API}/`
    this.http.get<any>(url).subscribe(data=>console.log(data)) //CREAR TIPO

  }
}
