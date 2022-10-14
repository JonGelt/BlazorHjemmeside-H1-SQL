USE Master
GO	
IF DB_ID('HjemmesideDB') IS NOT NULL
	BEGIN
ALTER DATABASE HjemmesideDB SET SINGLE_USER
DROP DATABASE HjemmesideDB
	END
CREATE DATABASE HjemmesideDB 
GO
USE HjemmesideDB
GO

CREATE TABLE Fisk(
FiskID INT  PRIMARY KEY IDENTITY(1,1)NOT NULL,
FiskNavn NVARCHAR(30),
FiskVægt INT,
FiskFarve NVARCHAR(15)
)

INSERT INTO Fisk (FiskNavn,FiskVægt,FiskFarve)
VALUES ('Nemo','5','Red' )
INSERT INTO Fisk (FiskNavn,FiskVægt,FiskFarve)
VALUES ('Dory','7','Blue' )
INSERT INTO Fisk (FiskNavn,FiskVægt,FiskFarve)
VALUES ('Catfish','7','Grey' )

