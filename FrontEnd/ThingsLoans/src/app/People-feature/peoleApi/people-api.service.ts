import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Person } from 'src/app/People-feature/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleApiService {

  private readonly API=`${environment.api}/people`

  constructor(private readonly http:HttpClient) { }

  getAll():Promise<Person[]>{  
    let url=`${this.API}/`
    let observer=this.http.get<Person[]>(url);
    return firstValueFrom(observer);
  }

  add(newPerson:Person){
    let url=`${this.API}/`
    this.http.post(url, newPerson).subscribe(data=>console.log("Posted:", data))
  }
}
