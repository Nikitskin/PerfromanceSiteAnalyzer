import { Component } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [PerformanceResult]
})

export class AppComponent{

    responses: PerformanceResponseModel[];
    url: string;
    tableMode: boolean = false;          
 
    constructor(private provider: PerformanceResult) { }
 
    getResponseModels() {
        this.provider.getResponseModels(this.url).
            subscribe((data: PerformanceResponseModel[]) => this.responses = data);
        this.tableMode = true;
    }

 
    
 
}