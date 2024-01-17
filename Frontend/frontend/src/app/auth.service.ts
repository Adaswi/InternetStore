import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';
import * as moment from "moment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private webReqService: WebRequestService) { }

login(userEmail:string, userPassword:string ) {
  console.log({userEmail, userPassword});
  
  return this.webReqService.post('api/Users/login', {userEmail, userPassword});
}
}
