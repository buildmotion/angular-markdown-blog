"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var NgControlBase = (function () {
    function NgControlBase() {
    }
    Object.defineProperty(NgControlBase.prototype, "value", {
        get: function () {
            return this._innerValue;
        },
        set: function (v) {
            if (v !== this._innerValue) {
                this._innerValue = v;
                this.onChangeCallback(v);
            }
        },
        enumerable: true,
        configurable: true
    });
    NgControlBase.prototype.writeValue = function (v) {
        if (v !== this._innerValue) {
            this._innerValue = v;
        }
    };
    NgControlBase.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    NgControlBase.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    return NgControlBase;
}());
exports.NgControlBase = NgControlBase;
//# sourceMappingURL=/app/ngControlBase.js.map