import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PeopleApiService } from 'src/app/services/peoleApi/people-api.service';
import { UserApiService } from 'src/app/services/usersApi/user-api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginForm:FormGroup;

  constructor(builder:FormBuilder, private readonly userService: UserApiService) { 
    this.userLoginForm=builder.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  ngOnInit(): void {}

  sendLogin(){
    let user=this.userLoginForm.value
    this.userService.login(user)
  }

}
