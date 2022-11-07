import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from 'src/app/entites/user';
import { AccountsService } from '../accounts/accounts.service';



@Injectable({
  providedIn: 'root'
})
export class MockUserApiService{

  login(user:User):Observable<string|null>{
    if(user.UserName=="Mr. Valid" && user.Password=="123")
        return of("<<token>>")
    else 
      return of(null)
  }

  checkToken():Observable<boolean>{           //no me convence
    if(localStorage.getItem(AccountsService.LOCAL_STORAGE_KEY)=="<<token>>")
      return of(true)
    else
      return of(false)
  }

  
}
