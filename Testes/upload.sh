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
echo "==================== LS DOCES"
ls ${PWD}
echo "==================== LS DOCES Unity"
ls ${PWD}/"DOCES - Unity"
echo "==================== LS Builds"
ls ${PWD}/"DOCES - Unity"/Builds/
echo "==================== LS Build.*"
ls ${PWD}/"DOCES - Unity"/Builds/*/*
echo "==================== TEMP"
ls ${PWD}/"DOCES - Unity"/Temp/

# tar -zcf web_build.tar ${PWD}/Build/Web

# echo ''
# echo ''
# echo "=============  Enviando arquivo comprimido para servidor ================"
# echo ''
# echo ''

# ftp -n $HOST <<END_SCRIPT
# quote USER $USER
# quote PASS $PASSWD
# cd $REMOTEPATH
# put web_build.tar
# quit
# END_SCRIPT
# exit 0
