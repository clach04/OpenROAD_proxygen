@echo off
set II_W4GLAPPS_DIR=%PROXYGEN%
set PATH=%PATH%;%PROXYGEN%
set II_DATE_FORMAT=MULTINATIONAL4
start /B w4glrun ProxyGen.img -Tmin -A -L%PROXYGEN%\proxygen.log
