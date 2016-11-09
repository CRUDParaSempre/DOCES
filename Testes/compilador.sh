#!/bin/sh

# Compilando Unity para Windows

project="DOCES - Unity"

echo "Compilando $project para ambientes webGL"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile ${PWD}/unity.log \
  -projectPath "${PWD}/DOCES - Unity" \
  -buildTarget WebGL "${PWD}/Build/Web"  \
  -quit

  #-buildOSXUniversalPlayer "${PWD}/game.app" \


echo 'Logs do processo de compilacao'
cat ${PWD}/unity.log
