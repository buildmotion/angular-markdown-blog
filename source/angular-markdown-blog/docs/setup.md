# Setup 

## angular-cli installation

```
npm install --save-dev @angular/cli@latest
```

## package.json
asdf

```
npm init
```

## tsconfig.json
asdf

```
tsc --init
```

## angular modules

```
npm install @angular/compiler @angular/compiler-cli typescript rollup uglify-js --save-dev
```

### Updates for the tsconfig.json

Current: 
```
"baseUrl": "./", /* Base directory to resolve non-absolute module names. */
```

Update to: 
```
"baseUrl": ".", /* Base directory to resolve non-absolute module names. */
```

Add:
```
"stripInternal": true,
"strictNullChecks": true,
```

```
"paths": {
    "@angular/core": ["node_modules/@angular/core"],
    "rxjs/*": ["node_modules/rxjs/*"]
},
```

## Rollup Configuration

```
export default {
  entry: 'dist/index.js',
  dest: 'dist/bundles/markdownblog.umd.js',
  sourceMap: false,
  format: 'umd',
  moduleName: 'markdownblog',
  globals: {
    '@angular/core': 'ng.core',
    'rxjs/Observable': 'Rx',
    'rxjs/ReplaySubject': 'Rx',
    'rxjs/add/operator/map': 'Rx.Observable.prototype',
    'rxjs/add/operator/mergeMap': 'Rx.Observable.prototype',
    'rxjs/add/observable/fromEvent': 'Rx.Observable',
    'rxjs/add/observable/of': 'Rx.Observable'
  }
}
```