# Dr. Sillystringz's Factory

#### Dr. Sillystringz's Factory allows an user to input engineers, machines, and expertises

#### By Michael Watts

## Description

Dr. Sillystringz's Factory is a C#/CSHTML Website that allows to create new engineers, machines, and expertises and associate engineers to the machines and vice versa. 

## Setup/Installation Requirements

## MySQL Workbench Schema Setup:
1. Open [MySql Workbench](https://www.mysql.com/products/workbench/) and connect to Local instance
2. Create a new sql tab by clicking the upper left icon: 'Create A New SQL Tab for Executing Queries'
3. Copy and paste the following code into "Query" and "Run":
---
### **Copy The Following Text**
CREATE DATABASE `michael_watts` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE michael_watts;
CREATE TABLE `engineerexpertise` (
  `EngineerExpertiseId` int NOT NULL AUTO_INCREMENT,
  `ExpertiseId` int NOT NULL,
  `EngineerId` int NOT NULL,
  PRIMARY KEY (`EngineerExpertiseId`),
  KEY `IX_EngineerExpertise_EngineerId` (`EngineerId`),
  KEY `IX_EngineerExpertise_ExpertiseId` (`ExpertiseId`),
  CONSTRAINT `FK_EngineerExpertise_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_EngineerExpertise_Expertises_ExpertiseId` FOREIGN KEY (`ExpertiseId`) REFERENCES `expertises` (`ExpertiseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `engineermachine` (
  `EngineerMachineId` int NOT NULL AUTO_INCREMENT,
  `EngineerId` int NOT NULL,
  `MachineId` int NOT NULL,
  PRIMARY KEY (`EngineerMachineId`),
  KEY `IX_EngineerMachine_EngineerId` (`EngineerId`),
  KEY `IX_EngineerMachine_MachineId` (`MachineId`),
  CONSTRAINT `FK_EngineerMachine_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_EngineerMachine_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `engineers` (
  `EngineerId` int NOT NULL AUTO_INCREMENT,
  `EngineerName` longtext,
  `EngineerDate` longtext,
  PRIMARY KEY (`EngineerId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `expertises` (
  `ExpertiseId` int NOT NULL AUTO_INCREMENT,
  `ExpertiseArea` longtext,
  PRIMARY KEY (`ExpertiseId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `machines` (
  `MachineId` int NOT NULL AUTO_INCREMENT,
  `MachineName` longtext,
  `MachineInstall` longtext,
  PRIMARY KEY (`MachineId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




## Website Setup:
* Download or Clone project from Github repository.
* Open a terminal within Factory folder within main project directory.
* Use Command, type in 'dotnet build'.
* After build, run the program with 'dotnet run' in the terminal.
* If you don't have it already, create a "appsettings.json" file in the "Factory" directory and Insert the code below with your user name and password for MySQL: 

> {
>  "ConnectionStrings": {
>      "DefaultConnection": "Server=localhost;Port=3306;database=michael_watts;uid={YOUR USERNAME};pwd={YOUR USERNAME}"
>  }
>}
## Known Bugs

Buttons are not centering - Will fix at a later date

## Support and contact details

https://github.com/wattsjmichael

## Technologies Used

C#, LINQ, Entity Framework Core, MVCTest, MySql, CSHTML, CSS, Bootstrap and Markdown.

## Link To Active Site:
Not Applicable

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **Michael Watts** - _Dr. Sillystringz's Factory_