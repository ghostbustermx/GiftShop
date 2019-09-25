import { NgModule } from '@angular/core';

import { Routes, RouterModule } from '@angular/router';
import { CuerpoComponent } from './pages/cuerpo/cuerpo.component';
import { ItemComponent } from './pages/item/item.component';
import { ShoppingCartComponent } from './pages/shopping-cart/shopping-cart.component';


// tslint:disable-next-line: variable-name
const app_routes: Routes = [
    { path: 'home', component: CuerpoComponent },
    { path: 'item', component: ItemComponent },
    { path: 'cuerpo', component: CuerpoComponent },
    { path: 'shoppingcart', component: ShoppingCartComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'home' }
];


@NgModule({
    imports: [
        RouterModule.forRoot( app_routes )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }






