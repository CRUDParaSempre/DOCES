#!/bin/sh

# Compilando Unity para Windows

project="DOCES - Unity"

echo "Compilando $project para ambientes OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile ${PWD}/unity.log \
  -projectPath "${PWD}/DOCES - Unity" \
  -buildOSXUniversalPlayer "${PWD}/game.app"
  -quit


echo 'Logs do processo de compilacao'
cat ${PWD}/unity.log
