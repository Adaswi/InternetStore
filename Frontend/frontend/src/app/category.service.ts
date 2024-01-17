import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private webReqService: WebRequestService) { }

  getCategories() {
    return this.webReqService.get('api/Categories');
  }
}
