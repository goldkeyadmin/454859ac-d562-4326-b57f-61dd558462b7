dotnet clean
dotnet build
dotnet test
dotnet build -c Release
cd ./app
docker build . -t sequence-finder
docker run sequence-finder "1 2 3 1 1 3 4 5 6 1"