import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Person } from 'src/app/People-feature/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeopleApiService {

  private readonly API=`${environment.api}/people`

  constructor(private readonly http:HttpClient) { }

  RequestAll():Observable<Person[]>{  
    let url=`${this.API}/`
    return this.http.get<Person[]>(url);
  }

  sendAdd(newPerson:Person){
    let url=`${this.API}/`
    this.http.post(url, newPerson).subscribe(data=>console.log("Posted:", data))
  }

  sendDelete(targer:Person){
    let url=`${this.API}/${targer.id}`
    this.http.delete(url).subscribe(data=>console.log("Deleted: ", data))
  }

  removeForm(obs:Observable<Person[]>,personRemoved:Person):Observable<Person[]>{
    return obs.pipe(
      map( arr => arr.filter((p)=>p.id!=personRemoved.id) )
    )
  }

  addTo(obs:Observable<Person[]>,newPerson:Person):Observable<Person[]>{
    return obs.pipe(
      map( arr => {
        if(arr.some(p=>p.id=newPerson.id))
          return arr
        else
          return [...arr, newPerson]
      } )
    )
  }

}
