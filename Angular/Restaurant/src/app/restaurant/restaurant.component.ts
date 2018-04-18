import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Restaurant } from './../shared/Restaurant';

import { RestaurantService } from './../shared/restaurant.service';

declare var jsOpenAlert: any;
declare var jsLoading: any;

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {

  mostrarTemplateResultado = false;
  nameFilter: string = "";
  restaurants: Restaurant[] = [];

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private restaurantService: RestaurantService
  ) { }

  ngOnInit() {
    jsLoading(true);
    this.restaurantService.getRestaurants(this.nameFilter)
      .subscribe(data => {
        this.restaurants = data;
        jsLoading(false);
      });

      this.mostrarTemplateResultado = true;
  }

  searchRestaurant(){
    jsLoading(true);
    this.restaurantService.getRestaurants(this.nameFilter)
      .subscribe(data => {
        this.restaurants = data
        jsLoading(false);      
      });
  }

  deleteRestaurant(id: number){
    jsLoading(true);
    this.restaurantService.deleteRestaurant(id)
    .subscribe(
      response => {
        jsLoading(false);
        if(response > 0){
          this.restaurantService.getRestaurants(this.nameFilter)
          .subscribe(data => this.restaurants = data);
          jsOpenAlert('Sucesso!','Restaurante removido com sucesso.','success');
        }else{
          jsOpenAlert('Atenção!', 'Não foi possível remover o restaurante!', 'danger');
        }
      }
    );
  }

}
