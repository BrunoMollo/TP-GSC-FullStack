import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserApiService } from 'src/app/services/usersApi/user-api.service';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {

  constructor(private userService:UserApiService, private router:Router) { }

  ngOnInit(): void {
  }

  logOut(){
    this.userService.disposeToken()
    this.router.navigate(["login"])
  }

}
