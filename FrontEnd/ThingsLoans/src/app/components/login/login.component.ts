import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountsService } from 'src/app/services/accounts/accounts.service';
import { UserApiService } from 'src/app/services/usersApi/user-api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginForm:FormGroup;
  failedToLogin=false;

  constructor(builder:FormBuilder, private accountService: AccountsService, private router:Router) { 
    this.userLoginForm=builder.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  async ngOnInit(): Promise<void> {
    const valid = await this.accountService.isTokenValid()
    if(valid){  
      this.router.navigate(["menu"])
    }
  }

  async sendLogin(){
    let user=this.userLoginForm.value
    let hasAccess= await this.accountService.login(user)
    
    if(hasAccess){
      this.router.navigate(["menu"])
    }
    else{
      this.failedToLogin=true;
      this.userLoginForm.reset();
    }
  }


}
