FROM microsoft/aspnetcore:2.0
ARG source
COPY ${source:-NetSnake/obj/Docker/publish} .
ENTRYPOINT ["dotnet", "NetSnake.dll"]