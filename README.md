# MatkaLasku

## Asennus

#### SQL Server
```sh
$ docker-compose up -d
```

#### ASP .NET 3.1 (api)
```sh
$ cd Api
$ dotnet restore
$ dotnet ef database update
```

#### Angular (frontend)
```sh
$ cd Frontend
$ npm ci
$ ng serve --open
```