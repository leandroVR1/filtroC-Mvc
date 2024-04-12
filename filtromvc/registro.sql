-- Active: 1712691870298@@b32vnmkbhsdashuwtu5j-mysql.services.clever-cloud.com@3306@b32vnmkbhsdashuwtu5j
CREATE TABLE Jobs (
    Id INT  PRIMARY KEY AUTO_INCREMENT,
    NameCompany VARCHAR(255),
    LogoCompany VARCHAR(255),
    OfferTitle VARCHAR(255),
    Description VARCHAR(255),
    Salary DOUBLE,
    Positions INT,
    Status VARCHAR(45),
    Country VARCHAR(45),
    Languages VARCHAR(45)
)

CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(255),
    LastNames VARCHAR(45),
    Email VARCHAR(155),
    BirthDate DATE,
    ProfilePicture VARCHAR(255),
    Cv VARCHAR(255),
    Gender VARCHAR(20),
    Phone VARCHAR(25),
    Address VARCHAR(125),
    CivilStatus VARCHAR(45),
    Salary DOUBLE,
    About VARCHAR(255),
    AcademicTitle VARCHAR(125),
    Languages VARCHAR(125),
    Areas VARCHAR(45)
)
