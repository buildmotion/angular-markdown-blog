
import { NgModule }     from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppModule } from './app/app.module';
import { MarkdownEditorComponent } from './app/markdown-editor/markdown-editor.component';

@NgModule({
  imports: [CommonModule, AppModule],
  declarations: [
    MarkdownEditorComponent
  ]
  exports: [ MarkdownEditorComponent]
})
export class MarkdownBlogModule {}