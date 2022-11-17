import { Component, OnInit } from '@angular/core';
import { PeopleApiService } from '../peoleApi/people-api.service';
import { Person } from '../person';

@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.css']
})
export class ListPeopleComponent implements OnInit {


  allPeople:Person[]=[]
  columnsToDisplay = ['Name', 'PhoneNumber', 'Email', 'delete'];

  constructor(private peopleApi: PeopleApiService) { }

  async ngOnInit() {
    this.allPeople= await this.peopleApi.getAll()
    console.log(this.allPeople);
  }

  delete(person:Person){
    console.log("dewde")
    this.peopleApi.delete(person);
    this.allPeople = this.allPeople.filter((p)=>p.id!=person.id);
  }

}
