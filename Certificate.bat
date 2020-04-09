set BIN=C:\Program Files (x86)\GnuWin32\bin
set CFG=C:\Program Files (x86)\GnuWin32\share\openssl.cnf
set NAME=SharpTerminal
cd %~dp0
"%BIN%\openssl" req -x509 -newkey rsa:4096 -keyout "%NAME%.key" -out "%NAME%.cer" -days 365 -subj "/CN=%NAME%" -passout pass:none -config "%CFG%"
"%BIN%\openssl" pkcs12 -inkey "%NAME%.key" -in "%NAME%.cer" -export -out "%NAME%.pfx" -passin pass:none -passout pass:none
del .rnd
