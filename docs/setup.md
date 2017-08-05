# Setup 

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
```