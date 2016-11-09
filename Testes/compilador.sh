#!/bin/sh

# Compilando Unity para Windows

mkdir Build

project="DOCES - Unity"

echo "Compilando $project para ambientes webGL"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile ${PWD}/unity.log \
  -projectPath "${PWD}/DOCES - Unity" \
  -buildTarget WebGL "${PWD}/Build"  \
  -quit

  #-buildOSXUniversalPlayer "${PWD}/game.app" \

ls -LR > dados.log

echo 'Logs do processo de compilacao'
cat ${PWD}/unity.log
