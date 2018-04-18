import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Restaurant } from './../../shared/Restaurant';

import { RestaurantService } from './../../shared/restaurant.service';

declare var jsOpenAlert: any;
declare var jsLoading: any;

@Component({
  selector: 'app-restaurant-form',
  templateUrl: './restaurant-form.component.html',
  styleUrls: ['./restaurant-form.component.css']
})
export class RestaurantFormComponent implements OnInit {

  private restaurant: Restaurant = new Restaurant();
  title: string;

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private restaurantService: RestaurantService
  ) { }

  ngOnInit() {

    var id = this.route.params.subscribe(params => {
      var id = params['id'];
      
      this.title = id ? 'Editar Restaurante' : 'Novo Restaurante';

      if (!id)
      return;

      this.restaurantService.getRestaurant(id)
      .subscribe(
        data => this.restaurant = data,
        response => {
          if (response.status == 404) {
            jsOpenAlert('Atenção!', 'O restaurante solicitado não existe!', 'danger');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Erro na requisição!', 'danger');
          }
        });
    });
  }

  save(){
    jsLoading(true);
    var result;

    if(this.restaurant.id && this.restaurant.id > 0){
      //UPDATE RESTAURANT
      this.restaurantService.putRestaurant(this.restaurant)
      .subscribe(
        response => {
          jsLoading(false);
          if(response > 0){
            this.router.navigate(['restaurant']);
            jsOpenAlert('Sucesso!','Restaurante atualizado com sucesso.','success');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Não foi possível atualizar o restaurante!', 'danger');
          }
        }
      );
    }else{
      //INSERT NEW RESTAURANT
      this.restaurantService.postRestaurant(this.restaurant)
      .subscribe(
        response => {
          jsLoading(false);
          if(response.id > 0){
            this.router.navigate(['restaurant']);
            jsOpenAlert('Sucesso!','Restaurante cadastrado com sucesso.','success');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Não foi possível inserir o restaurante!', 'danger');
          }
        }
      );
    }
  }
}
