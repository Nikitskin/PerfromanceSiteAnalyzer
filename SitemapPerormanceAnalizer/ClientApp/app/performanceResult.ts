import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable()
export class PerformanceResult {

    private url = "/api/SitemapAnalyze";

    constructor(private http: HttpClient) {
    }

    getResponseModels(urlToTest: string) {
        const body = { asfas: "fasfafa" };
        return this.http.post(this.url, body);
    }
}