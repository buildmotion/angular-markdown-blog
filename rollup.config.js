export default {
  entry: 'dist/index.js',
  dest: 'dist/bundles/markdown-blog.umd.js',
  sourceMap: false,
  format: 'umd',
  moduleName: 'ng.MarkdownBlogModule',
  globals: {
    '@angular/core': 'ng.core'
  }
}