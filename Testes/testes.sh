#!/bin/bash

echo "Rodando testes de integracao"
mkdir ${PWD}/web2000

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile /tmp/unity.log \
  -executeMethod UnityTest.Batch.RunIntegrationTests \
  -testscenes=GameScenes \
  -projectPath "${PWD}/DOCES - Unity" \
  -targetPlatform=WebGL \
  -resultsFileDirectory=${PWD}/web2000 \
  -quit

#-buildTarget WebGL "${PWD}/Build/Web"

echo "Log do teste"
echo ""
echo ""
echo ""
echo ""
echo ""
echo ""
echo ""
cat /tmp/unity.log
