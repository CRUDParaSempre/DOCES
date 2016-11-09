#! /bin/sh

# Script para instalacao do Unity3D para testes no TRAVIS

#Link Temporario 
echo 'Baixando Unity de from http://download.unity3d.com/download_unity/960ebf59018a/MacEditorInstaller/Unity-5.3.5f1.pkg'
curl -o mac.pkg http://download.unity3d.com/download_unity/960ebf59018a/MacEditorInstaller/Unity-5.3.5f1.pkg

echo 'Instalando a unity versao 3.5.5f1'
sudo installer -dumplog -package mac.pkg -target /
