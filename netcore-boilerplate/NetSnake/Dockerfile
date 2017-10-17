FROM microsoft/aspnetcore:2.0
ARG source
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "NetSnake.dll"]
