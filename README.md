# Sheridan.Flyball


[![Build Status](https://briansheridan.visualstudio.com/FlyballStatTracker/_apis/build/status/FlyballStatTracker?branchName=master)](https://briansheridan.visualstudio.com/FlyballStatTracker/_build/latest?definitionId=27?branchName=master)

This is a .net core application to fully manage your Flyball team.  Flyball is a dog sport that is similiar to a relay race that consists of 4 dogs racing another team with 4 dogs.

This program hopes to track the following items.
* People and Dogs on Team
* Tournaments you partcipate in 
* Who you race and if you win or loss
* What happened on each heat
* Statistics about your dogs from all the heat information

## Commands For EF
dotnet restore
dotnet build
dotnet ef migrations database update
dotnet ef database update