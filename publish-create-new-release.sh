#!/bin/bash

if [[ $1 =~ ^v([\\d])* ]]; then
    bash ./publish-release.sh
    tar -czvf ./dist/wasm.tar.gz ./dist
    gh release create "$1" ./dist/*.tar.gz
else
    echo "Please specify a version arg0 vX.X.X"
fi