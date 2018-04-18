import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Dish } from './../../shared/Dish';
import { Restaurant } from './../../shared/Restaurant';

import { DishService } from './../../shared/dish.service';
import { RestaurantService } from './../../shared/restaurant.service';

declare var jsOpenAlert: any;
declare var jsLoading: any;
declare var $: any;

@Component({
  selector: 'app-dish-form',
  templateUrl: './dish-form.component.html',
  styleUrls: ['./dish-form.component.css']
})
export class DishFormComponent implements OnInit {

  restaurants: Restaurant[];
  dish: Dish = new Dish();
  title: string;

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private dishService: DishService,
    private restaurantService: RestaurantService
  ) { }

  ngOnInit() {
    $(".maskMoney").each(function () {
			$(this).maskMoney({ decimal: ",", thousands: "." });
		});

    //GET RESTAURANTS
    this.restaurantService.getRestaurants("")
    .subscribe(data => {
      this.restaurants = data;
    });

    var id = this.route.params.subscribe(params => {
      var id = params['id'];
      
      this.title = id ? 'Editar Prato' : 'Novo Prato';

      if (!id)
      return;

      this.dishService.getDish(id)
      .subscribe(
        data => this.dish = data,
        response => {
          if (response.status == 404) {
            jsOpenAlert('Atenção!', 'O prato solicitado não existe!', 'danger');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Erro na requisição!', 'danger');
          }
        });
    });
  }

  save(){
    jsLoading(true);
    var result;

    this.dish.dishPrice = $('#dishPrice').val().replace(',','.');

    if(this.dish.id && this.dish.id > 0){
      
      this.dishService.putDish(this.dish)
      .subscribe(
        response => {
          jsLoading(false);
          if(response > 0){
            this.router.navigate(['dish']);
            jsOpenAlert('Sucesso!','Prato atualizado com sucesso.','success');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Não foi possível atualizar o prato!', 'danger');
          }
        }
      );
    }else{
      
      this.dishService.postDish(this.dish)
      .subscribe(
        response => {
          jsLoading(false);
          if(response.id > 0){
            this.router.navigate(['dish']);
            jsOpenAlert('Sucesso!','Prato cadastrado com sucesso.','success');
          }else if(response.status == 400){
            jsOpenAlert('Atenção!', 'Não foi possível inserir o prato!', 'danger');
          }
        }
      );
    }
  }
}
