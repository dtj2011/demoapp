sudo killall -9 dotnet
nohup dotnet ./demoapp/build_artifacts/demoapp.dll --urls "http://0.0.0.0:5000;https://0.0.0.0:5001" &>/dev/null &