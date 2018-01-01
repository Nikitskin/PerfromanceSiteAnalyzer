var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var AppComponent = (function () {
    function AppComponent() {
        this.items = ["Apple iPhone 7", "Huawei Mate 9", "Samsung Galaxy S7", "Motorola Moto Z"];
        //public responses: PerformanceResponseModel[] = [new PerformanceResponseModel("sadasd","fsafasf")];                
        this.tableMode = false;
    }
    //constructor(private provider: PerformanceResult) { }
    AppComponent.prototype.getResponseModels = function (url) {
        //this.provider.getResponseModels(url).
        //    subscribe((data: PerformanceResponseModel[]) => this.responses = data);
        this.tableMode = true;
    };
    return AppComponent;
}());
AppComponent = __decorate([
    Component({
        selector: 'app',
        //templateUrl: './app.component.html',
        template: "<ul>\n                  <li *ngFor=\"let item of items.result\">{{item}}</li>\n                </ul>",
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map