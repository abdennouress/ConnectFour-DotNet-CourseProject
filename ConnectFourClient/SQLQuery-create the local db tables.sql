CREATE TABLE Players (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Phone NVARCHAR(20),
    Country NVARCHAR(50),
    Identifier INT
);

CREATE TABLE Games (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlayerId INT FOREIGN KEY REFERENCES Players(Id),
    StartTime DATETIME,
    Duration INT,
    Result NVARCHAR(20),
    PlayerMoves INT,
    ServerMoves INT
);

CREATE TABLE Moves (
    Id INT PRIMARY KEY IDENTITY(1,1),
    GameId INT FOREIGN KEY REFERENCES Games(Id),
    Who INT,
    ColumnNum INT,
    RowNum INT,
    Timestamp DATETIME
);