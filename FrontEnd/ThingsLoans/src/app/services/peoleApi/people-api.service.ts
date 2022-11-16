import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from 'src/app/entites/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleApiService {

  private readonly API=`${environment.api}/people`

  constructor(private readonly http:HttpClient) { }

  getAll(){  
    let url=`${this.API}/`
    this.http.get<Person>(url).subscribe(data=>console.log(data))

  }

  add(newPerson:Person){
    let url=`${this.API}/`
    this.http.post(url, newPerson).subscribe(data=>console.log(data))
  }
}
