import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Dish } from './../shared/Dish';

import { DishService } from './../shared/dish.service';

declare var jsOpenAlert: any;
declare var jsLoading: any;

@Component({
  selector: 'app-dish',
  templateUrl: './dish.component.html',
  styleUrls: ['./dish.component.css']
})
export class DishComponent implements OnInit {

  mostrarTemplateResultado = false;
  nameFilter: string = "";
  dishs: Dish[] = [];

  constructor(
    private router: Router, 
    private route: ActivatedRoute,
    private dishService: DishService
  ) { }

  ngOnInit() {
    this.dishService.getDishs(this.nameFilter)
      .subscribe(data => {
        this.dishs = data;
        this.mostrarTemplateResultado = true;
      });
      
  }

  searchDishs(){
    jsLoading(true);
    this.dishService.getDishs(this.nameFilter)
      .subscribe(data => {
        this.dishs = data
        jsLoading(false);      
      });
  }

  deleteDish(id: number){
    jsLoading(true);
    this.dishService.deleteDish(id)
    .subscribe(
      response => {
        jsLoading(false);
        if(response > 0){
          this.dishService.getDishs(this.nameFilter)
          .subscribe(data => this.dishs = data);
          jsOpenAlert('Sucesso!','Prato removido com sucesso.','success');
        }else{
          jsOpenAlert('Atenção!', 'Não foi possível remover o prato!', 'danger');
        }
      }
    );
  }

}
