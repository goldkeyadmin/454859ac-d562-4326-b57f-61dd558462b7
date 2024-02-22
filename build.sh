dotnet clean
dotnet build
dotnet test
dotnet build -c Release
cd ./app
docker build . -t sequence-finder
numberString="1 2 3 1 1 3 4 5 6 1"
echo executing sequence-finder with string $numberString
echo result: $(docker run sequence-finder "$numberString")