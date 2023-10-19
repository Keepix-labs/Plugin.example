dotnet publish -c Debug -r browser-wasm --self-contained
rm -rf ./dist
cp -r ./bin/Debug/net7.0/browser-wasm/AppBundle ./dist