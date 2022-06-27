# ToyRobotSimulator

The project simulates a toy robot moving on a 6 x 6 square tabletop using a console application developed with .NET 6, C# 10 and XUnit.

[![.NET Build and Test](https://github.com/khurrampunjwani/ToyRobotSimulator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/khurrampunjwani/ToyRobotSimulator/actions/workflows/dotnet.yml)
[![Lint Code Base](https://github.com/khurrampunjwani/ToyRobotSimulator/actions/workflows/super-linter.yml/badge.svg)](https://github.com/khurrampunjwani/ToyRobotSimulator/actions/workflows/super-linter.yml)

## Table of contents

* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)

## Technologies

Project is created with:

* .NET version: 6

## Setup

To run this project, install it locally using dotnet cli:

```bash
cd ../src
dotnet build
```

## Features

It can read the following commands:

* PLACE X, Y, DIRECTION
* MOVE
* LEFT
* RIGHT
* REPORT
