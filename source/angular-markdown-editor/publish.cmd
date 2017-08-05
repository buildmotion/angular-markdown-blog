rmdir /s /q ..\ng-resources\markdown-motion-editor\app
del /q ..\ng-resources\markdown-motion-editor\*.*
xcopy dist\*.* ..\ng-resources\markdown-motion-editor /S /I /F /R /Y