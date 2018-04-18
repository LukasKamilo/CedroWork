import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantFormComponent } from './restaurant/restaurant-form/restaurant-form.component';
import { DishComponent } from './dish/dish.component';
import { DishFormComponent } from './dish/dish-form/dish-form.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'restaurant', component: RestaurantComponent },
  { path: 'restaurant/new', component: RestaurantFormComponent},
  { path: 'restaurantEdit/:id', component: RestaurantFormComponent},
  { path: 'dish', component: DishComponent },
  { path: 'dish/new', component: DishFormComponent},
  { path: 'dishEdit/:id', component: DishFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
