# Battlesnake ASP.NET Core 2.0 boilerplate
This is a boilerplate for battle snake written in ASP.NET Core 2.0 which requires the [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core).

You will also need Docker to be able to run it on the Evolve Battle Snake server. If you are running Windows you can download it [here](https://docs.docker.com/docker-for-windows/install/#download-docker-for-windows)

A few modifications are required to have it run properly

1. Replace `[TEAM_NAME]` with your team name in the `nginx.conf.sigil` located under NetSnake\obj\Docker\publish\app

2. Replace `[INTERNAL_IP]` with your internal IP (check with ipconfig in command window e.g. 192.168.xxx.xxx) in the `applicationhost.config` file located under .vs\config

<br/>
Happy coding!
