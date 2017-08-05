import {
  Component,
  NgModule,
  forwardRef,
  ElementRef,
  ViewChild,
  AfterViewInit,
  Input,
  OnDestroy,
  OnInit,
  ModuleWithProviders,
  Inject,
  ViewEncapsulation
} from '@angular/core';
import {
  NG_VALUE_ACCESSOR
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgControlBase } from './../ngControlBase';
import { SIMPLEMDE_CONFIG } from './../config';
import * as SimpleMDE from 'simplemde';

const SIMPLEMDE_CONTROL_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MarkdownEditorComponent),
  multi: true
};

@Component({
  selector: 'simplemde',
  encapsulation: ViewEncapsulation.None,
  template: `
    <textarea #simplemde></textarea>
  `,
  providers: [
    SIMPLEMDE_CONTROL_VALUE_ACCESSOR
  ],
  // styleUrls: ['../node_modules/simplemde/dist/simplemde.min.css']
})
export class MarkdownEditorComponent extends NgControlBase implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('simplemde') textarea: ElementRef;
  @Input() options: SimpleMDE.Options = {};

  private simplemde: SimpleMDE;

  ngOnInit() {
    if (typeof this.config !== 'object' || typeof this.options !== 'object') {
      throw new Error('config is not an object');
    }

    // const config = { ...this.config, ...this.options };
    const config = {config: this.config, options: this.options};
    // config.element = this.textarea.nativeElement;

    this.simplemde = new SimpleMDE(config);
  }

  writeValue(v: any) {
    if (v !== this._innerValue) {
      this._innerValue = v;
      if (this.value != null && this.simplemde != null) {
        this.simplemde.value(this.value);
      }
    }
  }

  ngAfterViewInit() {
    this.simplemde.codemirror.on('change', () => {
      this.value = this.simplemde.value();
    });
  }

  ngOnDestroy() {
    this.simplemde = null;
  }

  constructor(
    @Inject(SIMPLEMDE_CONFIG) private config
  ) {
    super();
  }

}
