#!/bin/bash

HOST='ftp.sitemalucao.esy.es'
USER="u250717177.travis"
PASSWD="123456"
REMOTEPATH='jogo'


# echo ''
# echo ''
# echo "=============  Enviando arquivo comprimido para servidor ================"
# echo ''
# echo ''

# ftp -n $HOST <<END_SCRIPT
# quote USER $USER
# quote PASS $PASSWD
# cd $REMOTEPATH
# put dados.log
# quit
# END_SCRIPT

echo '================ Zipando arquivo ==================='
name=$(date +'game_%Y%m%d%H%M%S.tar')
tar -zcf $name ${PWD}/'DOCES - Unity'/WEBGLRODA

ls -la $name

echo "================ Enviando arquivo $name ==================="

 ftp -n $HOST <<END_SCRIPT
 quote USER $USER
 quote PASS $PASSWD
 cd $REMOTEPATH
 put $name
 quit
 END_SCRIPT

echo '================ Enviado arquivo game.tar ==================='

 exit 0
