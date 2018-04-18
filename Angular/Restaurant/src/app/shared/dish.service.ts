import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Rx';

import { Dish } from './Dish';

@Injectable()
export class DishService {

  private url: string = "http://localhost:4200/api/api/dishes";

  constructor(private http: Http) { }

  getDishs(name: string){
    return this.http.get(this.url + "?name=" + name)
      .map(res => res.json());
  }

  getDish(id){
    return this.http.get(this.url + "/" + id)
      .map(res => res.json());
  }

  putDish(dish: Dish){
    return this.http.put(this.url, dish)
      .map(res => res.json());
  }

  postDish(dish: Dish){
    return this.http.post(this.url, dish)
      .map(res => res.json());
  }

  deleteDish(id: number){
    return this.http.delete(this.url + "/" + id)
      .map(res => res.json());
  }
}
