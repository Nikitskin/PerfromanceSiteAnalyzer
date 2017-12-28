var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { PerformanceResult } from './performanceResult';
import { PerformanceResponseModel } from './performanceResponseModel';
var AppComponent = (function () {
    function AppComponent(dataService) {
        this.dataService = dataService;
        this.tableMode = true;
    }
    AppComponent.prototype.ngOnInit = function () {
        /*  this.loadProducts();     */
    };
    return AppComponent;
}());
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        providers: [PerformanceResult]
    }),
    __metadata("design:paramtypes", [PerformanceResponseModel])
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map