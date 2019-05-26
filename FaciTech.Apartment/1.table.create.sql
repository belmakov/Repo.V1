CREATE TABLE Contact
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Phone] VARCHAR(15) NULL
)
CREATE TABLE [dbo].[User] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Username]  VARCHAR (15) NOT NULL,
	[Salt]  VARCHAR (25) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [ContactId] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([Id])
);
Create TABLE [Role]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50)
)
CREATE TABLE Feature
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Code VARCHAR(25) NOT NULL,
	[Name] Varchar(100) NOT NULL
)
CREATE TABLE Role_Feature
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	RoleId INT FOREIGN KEY REFERENCES Role(Id),
	FeatureId INT FOREIGN KEY REFERENCES Feature(Id)
)

CREATE TABLE Country
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(50) NOT NULL
)
CREATE TABLE City
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(50) NOT NULL,
	CountryId int FOREIGN KEY REFERENCES Country(Id)
)
CREATE TABLE Area
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(50) NOT NULL,
	CityId int FOREIGN KEY REFERENCES City(Id)

)
CREATE TABLE SubArea
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(50) NOT NULL,
	AreaId int FOREIGN KEY REFERENCES Area(Id)

)
CREATE TABLE Amenity
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(50) NOT NULL,
)

CREATE TABLE Community
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] Varchar(100) NOT NULL,
	[BuilderName] Varchar(100),
	SubAreaId int FOREIGN KEY REFERENCES SubArea(Id),
	[Address] Varchar(500),
	[Landmark] Varchar(100),
	[LocationLink] Varchar(500),
	[AssociationName] Varchar(100),
	[AssociationNumber] Varchar(25),
	[AssociationBankName] Varchar(100),
	[AssociationBankAccountNumber] Varchar(25),
	[AssociationBankBranchAddress] Varchar(500),
	[AssociationBankIFSC] Varchar(25),
	[AmenityIds] Varchar(100)
)
CREATE TABLE [Block]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BlockName Varchar(50),
	NoOfFloors int,
	CommunityId int Foreign Key References Community(Id)
)
CREATE TABLE Unit
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BlockId int Foreign Key References [Block](Id),
	FloorNumber int,
	UnitNumber varchar(10),
	Specification varchar(100)
)