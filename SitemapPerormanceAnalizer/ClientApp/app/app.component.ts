import { Component, OnInit } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';

@Component({
    selector: 'app',
    providers: [PerformanceResult]
})

export class AppComponent implements OnInit {
 
    performanceResultModels: PerformanceResponseModel[];                
    tableMode: boolean = true;          
 
    constructor(private provider: PerformanceResult) { }
 
     ngOnInit() {
         
     }

     loadResults(url: string) {
         this.provider.getResponseModels(url).
             subscribe((data: PerformanceResponseModel[]) => this.performanceResultModels = data);
     }

    getResponseModels(url: string) {
        return this.provider.getResponseModels(url);
    }

 
    
 
}