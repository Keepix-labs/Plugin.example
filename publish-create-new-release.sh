bash ./publish-release.sh
tar -czvf ./dist/wasm.tar.gz ./dist
gh release create v0.0.2 ./dist/*.tar.gz