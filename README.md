# Example


## Pre-requies

Install wasm-tools
`dotnet workload install wasm-tools`

Install nodejs v18
`nvm use v18`

Github cli (https://github.com/cli/cli#installation)
`brew install gh`
`gh auth login`

## Install

`npm install`
`dotnet restore`
`bash ./publish-debug.sh`

## Test

`npx tsx tests.ts`
