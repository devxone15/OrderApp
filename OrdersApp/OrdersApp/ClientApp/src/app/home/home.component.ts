import {Component, OnDestroy, OnInit} from '@angular/core';
import {OrderService} from './services/order.service';
import {SubscriptionLike} from 'rxjs';
import {Order} from './models/order.model';
import {Product} from './models/product.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy {
    subscription: SubscriptionLike;
    order: Order;
    orders: Order[];
    products: Product[];
    qtySum: Number;
    priceSum: Number;
    totalSum: Number;
    isActive = [];

    constructor(private orderService: OrderService) {
    }

    ngOnInit(): void {
      this.orderService.getOrders().subscribe((response: Order[]) => {
        this.orders = response;
      });

      setTimeout(() => {
        if (this.orders != null) {
          this.getOrderProducts(this.orders[0]);
          this.isActive[0] = true;
        }
      }, 200);
    }

    ngOnDestroy(): void {
      if (this.subscription) {
        this.subscription.unsubscribe();
        this.subscription = null;
      }
    }

    public getOrderProducts(order) {
      this.order = order;

      this.orderService.getOrderProducts(this.order.id).subscribe((response: Product[]) => {
        this.products = response;
        this.qtySum = this.products.reduce((sum, p) => sum + p.quantity, 0);
        this.priceSum = this.products.reduce((sum, p) => sum + p.price, 0);
        this.totalSum = this.products.reduce((sum, p) => sum + p.total, 0);
      });
    }
}
