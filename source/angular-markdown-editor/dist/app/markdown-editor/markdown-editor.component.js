"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var ngControlBase_1 = require("./../ngControlBase");
var config_1 = require("./../config");
var SimpleMDE = require("simplemde");
var SIMPLEMDE_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return MarkdownEditorComponent; }),
    multi: true
};
var MarkdownEditorComponent = (function (_super) {
    __extends(MarkdownEditorComponent, _super);
    function MarkdownEditorComponent(config) {
        var _this = _super.call(this) || this;
        _this.config = config;
        _this.options = {};
        return _this;
    }
    MarkdownEditorComponent.prototype.ngOnInit = function () {
        if (typeof this.config !== 'object' || typeof this.options !== 'object') {
            throw new Error('config is not an object');
        }
        // const config = { ...this.config, ...this.options };
        var config = { config: this.config, options: this.options };
        // config.element = this.textarea.nativeElement;
        this.simplemde = new SimpleMDE(config);
    };
    MarkdownEditorComponent.prototype.writeValue = function (v) {
        if (v !== this._innerValue) {
            this._innerValue = v;
            if (this.value != null && this.simplemde != null) {
                this.simplemde.value(this.value);
            }
        }
    };
    MarkdownEditorComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        this.simplemde.codemirror.on('change', function () {
            _this.value = _this.simplemde.value();
        });
    };
    MarkdownEditorComponent.prototype.ngOnDestroy = function () {
        this.simplemde = null;
    };
    __decorate([
        core_1.ViewChild('simplemde'),
        __metadata("design:type", core_1.ElementRef)
    ], MarkdownEditorComponent.prototype, "textarea", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", typeof (_a = (typeof SimpleMDE !== "undefined" && SimpleMDE).Options) === "function" && _a || Object)
    ], MarkdownEditorComponent.prototype, "options", void 0);
    MarkdownEditorComponent = __decorate([
        core_1.Component({
            selector: 'simplemde',
            encapsulation: core_1.ViewEncapsulation.None,
            template: "\n    <textarea #simplemde></textarea>\n  ",
            providers: [
                SIMPLEMDE_CONTROL_VALUE_ACCESSOR
            ],
        }),
        __param(0, core_1.Inject(config_1.SIMPLEMDE_CONFIG)),
        __metadata("design:paramtypes", [Object])
    ], MarkdownEditorComponent);
    return MarkdownEditorComponent;
    var _a;
}(ngControlBase_1.NgControlBase));
exports.MarkdownEditorComponent = MarkdownEditorComponent;
//# sourceMappingURL=/app/markdown-editor/markdown-editor.component.js.map