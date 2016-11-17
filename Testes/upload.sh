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

ls "DOCES*/Temp"

name=$( date +web_build_%Y%m%d%H%M%S.tar ) 
tar -zcf $name "${PWD}/DOCES\ -\ Unity/Temp/IntegrationTests/*"

echo ''
echo ''
echo "=============  Enviando arquivo comprimido para servidor ================"
echo ''
echo ''

curl -F "uploadedfile=@${name}" http://homepages.dcc.ufmg.br/~juniocezar/games/minhaempresa/builds/uploads.php
