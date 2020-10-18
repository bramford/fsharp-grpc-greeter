fsharp-grpc-greeter
===========================

## Background & Purpose

Primarily F# implementation of sample "Greeter" gRPC Client & Server that is found in the official Microsoft .NET documentation:

[Tutorial: Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.1&tabs=visual-studio-code)

## Overview

- Actual gRPC & Protobuf definitions are only compatible with C# and are therefore in their own library [GrpcGreeterLib](./GrpcGreeterLib).
- F# gRPC server in [GrpcGreeter](./GrpcGreeter).
- F# gRPC client in [GrpcGreeterClient](./GrpcGreeterClient).

_Note:_ This server & client was developed on Debian GNU/Linux with VSCode and hasn't been tested in any other environment(s).

## Requirements

- .NET Core 3.1+

## Run

### Server

```
cd GrpcGreeter
dotnet run
```

### Client

- Requires the server already be running.
- Exits after sending a single gRPC message

```
cd GrpcGreeterClient
dotnet run
```
