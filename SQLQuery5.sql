Select * From Addresses;
Select * From ElderlyResidents;
Select * From EmergencyContacts;

Create Table Address (
 AddressID INT PRIMARY KEY IDENTITY(1,1),
    Street NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    ZipCode NVARCHAR(10) NOT NULL
    );

CREATE TABLE ElderlyResidents (
    ElderlyResidentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    AddressID INT NOT NULL,
    CONSTRAINT FK_ElderlyResidents_Addresses FOREIGN KEY (AddressID) REFERENCES Addresses(AddressID) ON DELETE CASCADE
    );
