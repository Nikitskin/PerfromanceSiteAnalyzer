import { Component } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';

@Component({
    selector: 'app',
    //templateUrl: './app.component.html',
    template: `<ul>
                  <li *ngFor="let item of items.result">{{item}}</li>
                </ul>`,
    //providers: [PerformanceResult]
})

export class AppComponent{

    items = ["Apple iPhone 7", "Huawei Mate 9", "Samsung Galaxy S7", "Motorola Moto Z"];
    //public responses: PerformanceResponseModel[] = [new PerformanceResponseModel("sadasd","fsafasf")];                
    tableMode: boolean = false;          
 
    //constructor(private provider: PerformanceResult) { }
 
    getResponseModels(url: string) {
        //this.provider.getResponseModels(url).
        //    subscribe((data: PerformanceResponseModel[]) => this.responses = data);
        this.tableMode = true;
    }

 
    
 
}