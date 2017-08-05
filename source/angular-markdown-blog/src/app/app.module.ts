import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarkdownEditorComponent } from './markdown-editor/markdown-editor.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [MarkdownEditorComponent],
  exports: [
    MarkdownEditorComponent
  ]
})
export class AppModule { }
