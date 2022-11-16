import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PeopleApiService } from 'src/app/services/peoleApi/people-api.service';
import { Person } from 'src/app/entites/person';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {


  personForm:FormGroup;

  constructor(builder:FormBuilder, private peopleApi: PeopleApiService) {
    this.personForm=builder.group({
      Name:[''],
      PhoneNumber:[''],
      Email:[''],
    })

  }

  ngOnInit(): void {
  }

  submit(){
    let newPerson:Person= this.personForm.value;
    this.peopleApi.add(newPerson)
  }


}
