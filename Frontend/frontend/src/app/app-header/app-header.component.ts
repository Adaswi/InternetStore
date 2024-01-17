import { Component, Input, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app-header.component.html',
  styleUrl: './app-header.component.scss'
})



export class AppHeaderComponent implements OnInit {

  categories: any;

  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(
      (params: Params) => {
        console.log(params);
      }
    )

    this.categoryService.getCategories().subscribe((categories: any) => {
      console.log(categories);
      this.categories = categories;
    })
  }

  Search(){
    const input = document.getElementById('input') as HTMLInputElement | null;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/filter/'+input?.value])});
  }

  Login(){
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/login'])});
  }

  Register(){
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/register'])});
  }

  readLocalStorageValue(token: string) {
    return localStorage.getItem(token);
}
  LogOut(){
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
    localStorage.removeItem("user");
  }
}
