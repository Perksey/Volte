dotnet restore
dotnet publish -c release -r linux-x64 -p:PublishSingleFile=true && dotnet publish -c release -r win10-x64 -p:PublishSingleFile=true