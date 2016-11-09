#!/bin/sh

# Script para instalacao do Unity3D para testes no TRAVIS

#Link Temporario 

echo 'Baixando Unity de http://download.unity3d.com/download_unity/960ebf59018a/MacEditorInstaller/Unity-5.3.5f1.pkg'

curl -o "Unity.pkg" "http://download.unity3d.com/download_unity/960ebf59018a/MacEditorInstaller/Unity-5.3.5f1.pkg?_ga=1.92322139.717821165.1475358332"

echo 'Instalando a Unity versao 3.5.5f1'
sudo installer -dumplog -package Unity.pkg -target /


echo 'Baixando Modulo de compilacao OSX'
curl -o "moduloOSX.pkg" "http://download.unity3d.com/download_unity/960ebf59018a/MacEditorTargetInstaller/UnitySetup-Mac-Support-for-Editor-5.3.5f1.pkg"


echo 'Instalando modulo MAC para a Unity versao 3.5.5f1'
sudo installer -dumplog -package moduloOSX.pkg -target /
