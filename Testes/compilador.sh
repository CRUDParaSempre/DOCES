#!/bin/sh

# Compilando Unity para Windows

project="DOCES - Unity"

echo "Compilando $project para ambientes Windows"
/opt/Unity/Editor/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile ${PWD}/unity.log \
  -projectPath "${PWD}/DOCES - Unity" \
  -buildWindowsPlayer "${PWD}/aplicacao.exe" \
  -quit


echo 'Logs do processo de compilacao'
cat ${PWD}/unity.log
