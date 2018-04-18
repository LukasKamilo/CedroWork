import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule }  from '@angular/router';
import { HttpModule } from '@angular/http';

import { DishService } from './../shared/dish.service';

import { DishFormComponent } from './dish-form/dish-form.component';
import { DishComponent } from './dish.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpModule
  ],
  declarations: [
    DishComponent,
    DishFormComponent
  ],
  providers: [
    DishService
  ],
  exports: [
    DishFormComponent
  ]
})
export class DishModule { }
