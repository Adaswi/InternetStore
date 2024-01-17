import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private webReqService: WebRequestService) { }
  
  getProducts() {
    return this.webReqService.get('api/Products');
  }

  getProductsByCategory(name: string) {
    return this.webReqService.get('api/Products/Category/'+name)
  }

  getProductById(id: string) {
    return this.webReqService.get('api/Products/'+id);
  }

  getProductsByFilter(name: string) {
    return this.webReqService.get('api/Products/Filter/'+name)
  }
}
