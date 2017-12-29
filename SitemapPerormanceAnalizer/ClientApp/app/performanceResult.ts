import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { PerformanceResponseModel } from './performanceResponseModel';

@Injectable()
export class PerformanceResult {

    private url = "/api/SitemapAnalyze";

    constructor(private http: HttpClient) {
    }

    getResponseModels(url : string ) {
        return this.http.post(this.url, url);
    }
}