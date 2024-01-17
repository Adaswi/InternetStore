import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private webReqService: WebRequestService) { }

  getCartByUserId(id: string) {
    return this.webReqService.get('api/Carts/'+id);
  }
}
