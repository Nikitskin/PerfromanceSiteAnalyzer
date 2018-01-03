import { Component } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';
import { RequestModel } from './request.model';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [PerformanceResult]
})

export class AppComponent{

    responses: PerformanceResponseModel[];
    tableMode: boolean = false;          
 
    constructor(private provider: PerformanceResult) { }
 
    getResponseModels(requestModel: RequestModel) {
        this.provider.getResponseModels(requestModel).
            subscribe((data: PerformanceResponseModel[]) => this.responses = data);
        this.tableMode = true;
    }
}