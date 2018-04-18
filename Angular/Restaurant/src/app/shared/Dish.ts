import { Restaurant } from './Restaurant';

export class Dish{
    id: number;
    dishName: string;
    dishPrice: string;
    dishImage: string;
    restaurantId: number;
    restaurants: Restaurant;
}