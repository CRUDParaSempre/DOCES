#!/bin/sh

# Script para instalacao do Unity3D para testes no TRAVIS

#Link Temporario 

echo 'Baixando Unity de from http://download.unity3d.com/download_unity/960ebf59018a/MacEditorInstaller/Unity-5.3.5f1.pkg'

wget http://download.unity3d.com/download_unity/linux/unity-editor-5.3.5f1+20160525_amd64.deb -O file.deb

echo 'Instalando a unity versao 3.5.5f1'
sudo dpkg -i file.deb
