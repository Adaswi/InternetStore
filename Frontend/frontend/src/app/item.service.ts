import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private webReqService: WebRequestService) { 
  }
  createItem(payload: Object) {
    return this.webReqService.post('api/Items', payload);
  }
}
