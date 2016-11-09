#!/bin/bash

HOST='ftp.sitemalucao.esy.es'
USER="u250717177.travis"
PASSWD="123456"
REMOTEPATH='jogo'


 echo ''
 echo ''
 echo "=============  Enviando arquivo comprimido para servidor ================"
 echo ''
 echo ''

 ftp -n $HOST <<END_SCRIPT
 quote USER $USER
 quote PASS $PASSWD
 cd $REMOTEPATH
 put dados.log
 quit
 END_SCRIPT


 tar -zcf web_b.tar WebGL-Dist

 ftp -n $HOST <<END_SCRIPT
 quote USER $USER
 quote PASS $PASSWD
 cd $REMOTEPATH
 put web_b.tar
 quit
 END_SCRIPT


 exit 0
