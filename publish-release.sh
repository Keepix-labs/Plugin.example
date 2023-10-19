dotnet publish -c Release -r browser-wasm
rm -rf ./dist
cp -r ./bin/Release/net7.0/browser-wasm/AppBundle ./dist