import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from 'src/app/login/accounts--service/accounts.service';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {

  constructor(private accountsService:AccountsService, private router:Router) { }

  ngOnInit(): void {
  }

  logOut(){
    this.accountsService.disposeToken()
    this.router.navigate(["login"])
  }

}
