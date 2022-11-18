import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
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

  RequestOne(id:number):Observable<Person|null>{
    let url=`${this.API}/${id}`
    return this.http.get<Person>(url).pipe( catchError(err=> of(null) ) );
  }

  sendAdd(newPerson:Person){
    let url=`${this.API}/`
    this.http.post(url, newPerson).subscribe()
  }

  sendDelete(targer:Person){
    let url=`${this.API}/${targer.id}`
    this.http.delete(url).subscribe()
  }

  sendUpdate(person:Person){
    let url=`${this.API}/${person.id}`
    this.http.put(url, person).subscribe();
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
