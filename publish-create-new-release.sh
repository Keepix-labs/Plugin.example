bash ./publish-release.sh
tar -czvf ./dist/wasm.tar.gz ./dist
gh release create v0.0.1 ./dist/*.tar.gz