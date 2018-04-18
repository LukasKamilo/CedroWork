import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule }  from '@angular/router';
import { HttpModule } from '@angular/http';

import { RestaurantService } from './../shared/restaurant.service';

import { RestaurantComponent } from './restaurant.component';
import { RestaurantFormComponent } from './restaurant-form/restaurant-form.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpModule
  ],
  declarations: [
    RestaurantComponent,
    RestaurantFormComponent
  ],
  providers: [
    RestaurantService
  ],
  exports: [
    RestaurantFormComponent
  ]
})
export class RestaurantModule { }
