import {Injectable, OnDestroy, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    baseUrl = environment.baseUrl;

    constructor(private http: HttpClient) {
    }

    public getOrders() {
      return this.http.get(this.baseUrl + '/order');
    }

    public getOrderProducts(orderId) {
      return this.http.get(this.baseUrl + '/order/' + orderId);
    }
}
