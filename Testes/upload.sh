#!/bin/bash

HOST='ftp.sitemalucao.esy.es'
USER="u250717177.travis"
PASSWD="123456"
REMOTEPATH='jogo'

echo ''
echo ''
echo "=============  Comprimindo arquivos gerados ================="
echo ''
echo ''
ls ${PWD} -lah
ls ${PWD}/Build/ -lah
ls ${PWD}/Build/Web -lah
tar -zcf web_build.tar ${PWD}/Build/Web

echo ''
echo ''
echo "=============  Enviando arquivo comprimido para servidor ================"
echo ''
echo ''

ftp -n $HOST <<END_SCRIPT
quote USER $USER
quote PASS $PASSWD
cd $REMOTEPATH
put web_build.tar
quit
END_SCRIPT
exit 0
