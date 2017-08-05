import { ElementRef, AfterViewInit, OnDestroy, OnInit } from '@angular/core';
import { NgControlBase } from './../ngControlBase';
import * as SimpleMDE from 'simplemde';
export declare class MarkdownEditorComponent extends NgControlBase implements OnInit, AfterViewInit, OnDestroy {
    private config;
    textarea: ElementRef;
    options: SimpleMDE.Options;
    private simplemde;
    ngOnInit(): void;
    writeValue(v: any): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    constructor(config: any);
}
