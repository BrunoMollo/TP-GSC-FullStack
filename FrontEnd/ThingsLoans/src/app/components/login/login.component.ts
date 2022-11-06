import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserApiService } from 'src/app/services/usersApi/user-api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginForm:FormGroup;
  failedToLogin=false;

  constructor(builder:FormBuilder, private userService: UserApiService, private router:Router) { 
    this.userLoginForm=builder.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  ngOnInit(): void {
    if(this.userService.istokenValid()){
      this.router.navigate(["menu"])
    }
  }

  sendLogin(){
    let user=this.userLoginForm.value
    this.userService.login(user).subscribe(
      (hasAccess)=>this.updateOnLogin(hasAccess)
    )
  }

  updateOnLogin(hasAccess:boolean){
    if(hasAccess){
      this.router.navigate(["menu"])
    }
    else{
      this.failedToLogin=true;
      this.userLoginForm.reset();
    }
  }

}
