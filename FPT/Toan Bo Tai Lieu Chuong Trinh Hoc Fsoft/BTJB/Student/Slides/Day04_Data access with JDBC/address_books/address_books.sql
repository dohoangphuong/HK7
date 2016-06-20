DROP TABLE Names;

CREATE TABLE Names (
       PersonID             INT(5) AUTO_INCREMENT,
       FirstName            VARCHAR(25) NOT NULL,
       LastName             VARCHAR(30) NOT NULL,
       PRIMARY KEY (PersonID)
);


DROP TABLE Addresses;

CREATE TABLE Addresses (
       AddressID            INT(4) AUTO_INCREMENT,
       PersonID             INT(5) NOT NULL,
       Address1             VARCHAR(40) NOT NULL,
       Address2             VARCHAR(40) NULL,
       City                 VARCHAR(25) NOT NULL,
       State                VARCHAR(30) NULL,
       ZipCode              CHAR(6) NOT NULL,
       PRIMARY KEY (AddressID), 
       FOREIGN KEY (PersonID)
                             REFERENCES Names
);


DROP TABLE EmailAddresses;

CREATE TABLE EmailAddresses (
       EmailID              INT(4) AUTO_INCREMENT,
       PersonID             VARCHAR(30) NOT NULL,
       EmailAddress         CHAR(18) NOT NULL,       PRIMARY KEY (EmailID), 
       FOREIGN KEY (PersonID)
                             REFERENCES Names
);


DROP TABLE PhoneNumbers;

CREATE TABLE PhoneNumbers (
       PhoneID              INT(5) AUTO_INCREMENT,
       PersonID             INT(5) NOT NULL,
       PhoneNumber          VARCHAR(12) NOT NULL,
       PRIMARY KEY (PhoneID), 
       FOREIGN KEY (PersonID)
                             REFERENCES Names
);