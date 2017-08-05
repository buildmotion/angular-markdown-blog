"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var app_module_1 = require("./app/app.module");
var markdown_editor_component_1 = require("./app/markdown-editor/markdown-editor.component");
var MarkdownMotionModule = (function () {
    function MarkdownMotionModule() {
    }
    MarkdownMotionModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, app_module_1.AppModule],
            declarations: [
                markdown_editor_component_1.MarkdownEditorComponent
            ],
            exports: [markdown_editor_component_1.MarkdownEditorComponent]
        })
    ], MarkdownMotionModule);
    return MarkdownMotionModule;
}());
exports.MarkdownMotionModule = MarkdownMotionModule;
//# sourceMappingURL=/markdown-motion.module.js.map