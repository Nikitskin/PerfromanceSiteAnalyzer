"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var app_module_1 = require("./app/app.module");
var platform = platform_browser_dynamic_1.platformBrowserDynamic();
platform.bootstrapModule(app_module_1.AppModule);
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(function () {
        var oldRootElem = document.querySelector('app');
        var newRootElem = document.createElement('app');
        oldRootElem.parentNode.insertBefore(newRootElem, oldRootElem);
        platform.destroy();
    });
}
//# sourceMappingURL=main.js.map