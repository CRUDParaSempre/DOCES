#!/bin/sh

# Compilando Unity para Windows


echo "==================== LS DOCES"
ls ${PWD}
echo "==================== LS DOCES Unity"
ls ${PWD}/"DOCES - Unity"
echo "==================== LS Builds"
ls ${PWD}/"DOCES - Unity"/Builds/
echo "==================== LS Build.*"
ls ${PWD}/"DOCES - Unity"/Builds/*/*
echo "==================== TEMP"
ls ${PWD}/"DOCES - Unity"/Temp/


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
