import { TestBed } from '@angular/core/testing';
import { User } from 'src/app/login/user';
import { MockUserApiService } from '../usersApi/mock-user-api.service';
import { UserApiService } from '../usersApi/user-api.service';

import { AccountsService } from './accounts.service';

describe('AccountsService', () => {
  let service: AccountsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:[
        { provide:UserApiService, useValue: new MockUserApiService() }
      ]
    });
    service = TestBed.inject(AccountsService);

    localStorage.clear()
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should login valid user',async ()=>{
    const validUser:User={UserName:"Mr. Valid", Password:"123"}
    const response= await service.login(validUser)
    
    expect(response).toBeTruthy()
    expect(service.getToken()).toEqual("<<token>>")
  })

  it('should not login invalid user',async ()=>{
    const validUser:User={UserName:"Mr. Hacker", Password:"brute_force#6423"}
    const response= await service.login(validUser)
    
    expect(response).toBeFalsy()
    expect(service.getToken()).toEqual(null)
  })

  it('should validate legit token',async ()=>{
    const legitToken="<<token>>"
    service.saveToken(legitToken)
    const response= await service.isTokenValid()
    expect(response).toBeTruthy()
  })

  it('should say that a token is invlaid when it is not in localstorage',async ()=>{
    const response= await service.isTokenValid()
    expect(response).toBeFalsy()
  })

  it('should say that a token is invlaid when it is not legit',async ()=>{
    const invalidToken="<<fake_token>>"
    service.saveToken(invalidToken)
    const response= await service.isTokenValid()
    expect(response).toBeFalsy()
  })


});
