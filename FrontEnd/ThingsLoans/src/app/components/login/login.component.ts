import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserApiService } from 'src/app/services/user-api.service';


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
