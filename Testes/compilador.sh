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
  -executeMethod WebGLBuilder.build \
  -quit

  #-buildTarget WebGL "${PWD}/Build"  \
  #-buildOSXUniversalPlayer "${PWD}/game.app" \

ls -LR > dados.log

echo 'Logs do processo de compilacao'
cat ${PWD}/unity.log
