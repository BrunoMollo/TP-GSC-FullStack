import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
      name:['', [Validators.required, Validators.minLength(3)]],
      phoneNumber:['', [Validators.pattern("[0-9 ]{10}")]],
      email:['', [Validators.email]],
    })

  }

  ngOnInit(): void {
  }

  submit(){
    const newPerson:Person= this.personForm.value;
    newPerson.phoneNumber=newPerson.phoneNumber.toString() //del form viene como un number

    this.peopleApi.sendAdd(newPerson)
    this.router.navigate(['menu','people']);
  }


}
