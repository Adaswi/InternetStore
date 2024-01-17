import { Routes } from '@angular/router';
import { ProductViewComponent } from './pages/product-view/product-view.component';
import { ItemViewComponent } from './pages/item-view/item-view.component';
import { LoginViewComponent } from './pages/login-view/login-view.component';
import { RegisterViewComponent } from './pages/register-view/register-view.component';

export const routes: Routes = [
    { path: '',component: ProductViewComponent },
    { path: 'category/:name',component: ProductViewComponent },
    { path: 'filter/:name',component: ProductViewComponent },
    { path: 'product/:id',component: ItemViewComponent},
    { path: 'login',component: LoginViewComponent},
    { path: 'register',component: RegisterViewComponent}
];
