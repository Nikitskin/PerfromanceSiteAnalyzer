﻿import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { PerformanceResponseModel } from './performanceResponseModel';

@Injectable()
export class PerformanceResult {

    public getResponseModels(url : string ) : PerformanceResponseModel {
        return undefined;
    }
    
}