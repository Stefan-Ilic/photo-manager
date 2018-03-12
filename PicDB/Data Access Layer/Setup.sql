USE PicDB
GO

DROP TABLE IF EXISTS IPTC
GO

CREATE TABLE IPTC (
	ID INT /*IDENTITY(1,1)*/ PRIMARY KEY,
	Keywords VARCHAR(255),
	ByLine VARCHAR(255),
	CopyrightNotice VARCHAR(255),
	Headline VARCHAR(255),
	Caption VARCHAR(255),
)
GO

DROP TABLE IF EXISTS EXIF
GO

CREATE TABLE EXIF (
	ID INT /*IDENTITY(1,1)*/ PRIMARY KEY,
	Make VARCHAR(255),
	FNumber DECIMAL(5,2),
	ExposureTime DECIMAL(8,4),
	ISOValue DECIMAL,
	Flash BIT,
	ExposureProgram INT
)
GO

DROP TABLE IF EXISTS Cameras
GO

CREATE TABLE Cameras (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Producer VARCHAR(255),
	Make VARCHAR(255),
	BoughtOn DATETIME,
	Notes VARCHAR(255),
	ISOLimitGood DECIMAL,
	ISOLimitAcceptable DECIMAL
)
GO

DROP TABLE IF EXISTS Pictures
GO

CREATE TABLE Pictures (
	ID INT /*IDENTITY(1,1)*/ PRIMARY KEY,
	FileName VARCHAR(255) NOT NULL,
	/*IPTC INT FOREIGN KEY REFERENCES IPTC(ID),*/
	/*EXIF INT FOREIGN KEY REFERENCES EXIF(ID),*/
	/*Camera INT FOREIGN KEY REFERENCES Cameras(ID)*/
)
GO