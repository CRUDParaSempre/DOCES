#! /bin/sh

# Compilando Unity para Windows

project="DOCES - Unity"

echo "Compilando $project para ambientes Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildWindowsPlayer "$(pwd)/Build/windows/aplicacao.exe" \
  -quit


echo 'Logs do processo de compilacao'
cat $(pwd)/unity.log
