import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestModel } from './request.model';

@Injectable()
export class PerformanceResult {

    private url = "/api/SitemapAnalyze";

    constructor(private http: HttpClient) {
    }

    getResponseModels(requestModel: RequestModel) {
        return this.http.post(this.url, requestModel.url);
    }
}