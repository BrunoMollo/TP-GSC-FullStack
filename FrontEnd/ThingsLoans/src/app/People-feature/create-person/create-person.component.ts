import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { PeopleApiService } from 'src/app/People-feature/peoleApi/people-api.service';
import { Person } from 'src/app/People-feature/person';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {


  personForm:FormGroup;

  constructor(builder:FormBuilder, private peopleApi: PeopleApiService, private router:Router) {
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
    this.router.navigate(['menu','people']);
  }


}
