import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../product.service';
import { ActivatedRoute, Params, UrlSegment } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrl: './product-view.component.scss'
})
export class ProductViewComponent implements OnInit {

  products: any;
  title!: string;

  constructor(private productService: ProductService, private route: ActivatedRoute) { }

  ngOnInit() {

    if(this.route.snapshot.url.toString().includes('category'))
    {
      this.title = this.route.snapshot.paramMap.get(('name'))!;
      this.productService.getProductsByCategory(this.title).subscribe((products: any) => {
        console.log(products);
        this.products = products;
      })
    }
    else if(this.route.snapshot.url.toString().includes('filter')) {
      this.title = this.route.snapshot.paramMap.get(('name'))!;
      this.productService.getProductsByFilter(this.title).subscribe((products: any) => {
        console.log(products);
        this.products = products;
      })
      this.title = 'Wyszukiwania dla: '+this.title;
    }
    else
    {
      this.title = 'Najnowsze produkty';
      this.productService.getProducts().subscribe((products: any) => {
        console.log(products);
        this.products = products;
      })
    }
  }
}
