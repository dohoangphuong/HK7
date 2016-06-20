DROP TABLE Authors;
CREATE TABLE Authors (
       AuthorID             INT(5) NOT NULL,
       FirstName            VARCHAR(25) NULL,
       LastName             VARCHAR(30) NULL,
       PRIMARY KEY (AuthorID)
);

DROP TABLE Publishers;
CREATE TABLE Publishers (
       PublisherID          INT(4) NOT NULL,
       PublisherName        VARCHAR(50) NOT NULL,
       PRIMARY KEY (PublisherID)
);


DROP TABLE Titles;
CREATE TABLE Titles (
       ISBN                 CHAR(18) NOT NULL,
       Title                VARCHAR(50) NOT NULL,
       EditionNumber        INT(2) NULL,
       CopyRight            CHAR(4) NULL,
       PublisherID          INT(4) NOT NULL,
       ImageFile            VARCHAR(50) NULL,
       Price                FLOAT(8,2) NOT NULL,
       PRIMARY KEY (ISBN), 
       FOREIGN KEY (PublisherID)
                             REFERENCES Publishers
);

DROP TABLE AuthorISBN;
CREATE TABLE AuthorISBN (
       AuthorID             INT(5) NOT NULL,
       ISBN                 CHAR(18) NOT NULL,
       PRIMARY KEY (AuthorID, ISBN), 
       FOREIGN KEY (ISBN)
                             REFERENCES Titles, 
       FOREIGN KEY (AuthorID)
                             REFERENCES Authors
);


LOAD DATA LOCAL INFILE 'D:/AL/Java3/Lesson7/authors.dat' INTO TABLE authors;
LOAD DATA LOCAL INFILE 'D:/AL/Java3/Lesson7/publishers.dat' INTO TABLE publishers;
LOAD DATA LOCAL INFILE 'D:/AL/Java3/Lesson7/titles.dat' INTO TABLE titles;
LOAD DATA LOCAL INFILE 'D:/AL/Java3/Lesson7/author_isbn.dat' INTO TABLE authorisbn;

