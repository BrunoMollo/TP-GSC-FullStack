import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { PeopleApiService } from '../peoleApi/people-api.service';
import { Person } from '../person';

@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.css']
})
export class ListPeopleComponent implements OnInit {


  allPeople:Observable<Person[]>=EMPTY
  columnsToDisplay = ['Name', 'PhoneNumber', 'Email', 'delete', 'edit'];

  constructor(private peopleApi: PeopleApiService) { }

  ngOnInit() {
    this.allPeople= this.peopleApi.RequestAll()
    setTimeout(this.refreshList.bind(this),600)
  }

  delete(person:Person){
    this.peopleApi.sendDelete(person);
    this.allPeople=this.peopleApi.removeForm(this.allPeople, person)
  }

  refreshList(){
    this.allPeople= this.peopleApi.RequestAll()
  }
}
