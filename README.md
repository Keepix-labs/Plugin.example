# Example


## Pre-requies

Install Dotnet
`dotnet version 7.0.402`
- Linux: (source: https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual)
`wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh`
`chmod +x ./dotnet-install.sh`
`./dotnet-install.sh --version 7.0.402`
`./dotnet-install.sh --version 7.0.402 --runtime aspnetcore`
`./dotnet-install.sh --channel 7.0.402`
`export DOTNET_ROOT=$HOME/.dotnet`
`export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools`
- Macos: (source: https://github.com/isen-ng/homebrew-dotnet-sdk-versions)
`brew tap isen-ng/dotnet-sdk-versions`
`brew install --cask 7.0.402`
see your installed versions: `dotnet --list-sdks`
- Windows:
Install it via "Visual Studio" and if necessary change the version 7.? on globals.json


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
