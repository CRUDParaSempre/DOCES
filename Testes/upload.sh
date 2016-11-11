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
tar -zcf game.tar ${PWD}/'DOCES - Unity'/WEBGLRODA

echo '================ Enviando arquivo game.tar ==================='

 ftp -n $HOST <<END_SCRIPT
 quote USER $USER
 quote PASS $PASSWD
 cd $REMOTEPATH
 put game.tar
 quit
 END_SCRIPT

echo '================ Enviado arquivo game.tar ==================='

 exit 0
