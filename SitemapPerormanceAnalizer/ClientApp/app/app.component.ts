import { Component, OnInit } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [PerformanceResult]
})

export class AppComponent implements OnInit {
 
    products: PerformanceResponseModel[];                
    tableMode: boolean = true;          
 
    constructor(private dataService: PerformanceResponseModel) { }
 
     ngOnInit() {
       /*  this.loadProducts();     */
     }
     /*loadProducts() {
         this.dataService.getProducts()
             .subscribe((data: Product[]) => this.products = data);
     }*/
    
 
}