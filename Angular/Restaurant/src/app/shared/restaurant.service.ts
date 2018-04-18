import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Rx';

import { Restaurant } from './Restaurant';

@Injectable()
export class RestaurantService {

  private url: string = "http://localhost:4200/api/api/restaurants";

  constructor(private http: Http) { }

  getRestaurants(name: string){
    return this.http.get(this.url + "?name=" + name)
      .map(res => res.json());
  }

  getRestaurant(id){
    return this.http.get(this.url + "/" + id)
      .map(res => res.json());
  }

  putRestaurant(restaurant: Restaurant){
    return this.http.put(this.url, restaurant)
      .map(res => res.json());
  }

  postRestaurant(restaurant: Restaurant){
    return this.http.post(this.url, restaurant)
      .map(res => res.json());
  }

  deleteRestaurant(id: number){
    return this.http.delete(this.url + "/" + id)
      .map(res => res.json());
  }

}
