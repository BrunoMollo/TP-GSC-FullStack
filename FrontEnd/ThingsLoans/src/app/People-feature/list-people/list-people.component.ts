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
  columnsToDisplay = ['Name', 'PhoneNumber', 'Email'];

  constructor(private peopleApi: PeopleApiService) { }

  async ngOnInit() {
    this.allPeople= await this.peopleApi.getAll()
    console.log(this.allPeople);
  }

}
