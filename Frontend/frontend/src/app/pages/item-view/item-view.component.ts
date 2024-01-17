import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../product.service';
import { ActivatedRoute, Params, Router, UrlSegment } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ItemService } from '../../item.service';
import { CartService } from '../../cart.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-item-view',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './item-view.component.html',
  styleUrl: './item-view.component.scss'
})
export class ItemViewComponent implements OnInit {
  product: any;
  selectedOption: string | null;
  selectedQuantity: string | null;
  identificator: any;

  constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router, private itemService: ItemService, private cartService: CartService) { }

  ngOnInit() {
    const prodId = this.route.snapshot.paramMap.get('id')!;
    this.productService.getProductById(prodId).subscribe((product: any) => {
      console.log(product);
      this.product = product;
    })
  }

  AddToCart() {
    if (localStorage.getItem('id_token') == null && localStorage.getItem('user')) {
      this.router.navigate(['/login']);
    }
    else if ((this.selectedOption == null && this.product.options != 0) || this.selectedQuantity == null) { console.log('Option or quantity not chosen') }
    else {      
      var user = JSON.parse(localStorage.getItem('user')!);
      this.cartService.getCartByUserId(user.userPassword).subscribe((cartId: any) => {
         this.identificator = cartId.cartId;
      });

      var cartId = this.identificator;
      var productId = this.product.productId;
      var optionId = this.selectedOption?.valueOf();
      var itemQuantity = this.selectedQuantity.valueOf();
      var itemPrice = this.product.productPrice * parseInt(this.selectedQuantity.valueOf());


      console.log({ cartId, productId, optionId, itemQuantity, itemPrice })
      this.itemService.createItem({ cartId, productId, optionId, itemQuantity, itemPrice }).subscribe(res => {console.log(res);

        this.router.navigate(['/cart']);
      })
    }
  }
}
