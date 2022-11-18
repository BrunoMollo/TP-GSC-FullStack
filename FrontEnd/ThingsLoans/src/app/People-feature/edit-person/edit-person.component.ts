import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, firstValueFrom, of, pipe } from 'rxjs';
import { PeopleApiService } from '../peoleApi/people-api.service';
import { Person } from '../person';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent implements OnInit {

  person:Person|undefined
  personForm:FormGroup;

  constructor(builder:FormBuilder, private peopleApi: PeopleApiService, private router:Router, private activatedRoute:ActivatedRoute) {
    this.personForm=builder.group({
      name:['', [Validators.required, Validators.minLength(3)]],
      phoneNumber:['', [Validators.pattern("[0-9 ]{10}")]],
      email:['', [Validators.email]],
    })

  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe( async (params) => {

      let id:string| null=params.get("id")
      if(id==null){ 
        this.router.navigate(['menu','people'])
      }
     else{
        this.peopleApi.RequestOne(+id)
                .subscribe(
                      data => {
                        if(data==null)
                          this.router.navigate(['menu','people'])
                        else
                          this.person=data
                      }
                )
     } 
     
      
    }
  );

  }

  submit(){
    const changedPerson:Person= { id:this.person?.id, ...this.personForm.value } ;
    changedPerson.phoneNumber=changedPerson.phoneNumber?.toString() //del form viene como un number

    this.peopleApi.sendUpdate(changedPerson);
    this.router.navigate(['menu','people']);
  }
}
