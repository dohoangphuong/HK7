CREATE DATABASE CSS
GO
USE CSS

CREATE TABLE Company
(
	[CompanyId] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100),
	[Type] NVARCHAR(100),
	[Status] NVARCHAR(100),
	[Sector] NVARCHAR(100),
	[PhoneNumber]  NVARCHAR(13),
	[FaxNumber] NVARCHAR(15),
	[Emailaddress] NVARCHAR(100),
	[CreatedDate] DATE,
	[CreatedBy] NVARCHAR(50),
	[AMISCode] NVARCHAR(50),
	[BusinessArea] NVARCHAR(100),
)

CREATE TABLE CustomerType
(
	[CustomerTypeId] INT IDENTITY(1,1) PRIMARY KEY,
	[CustomerType] NVARCHAR(50),
)

CREATE TABLE RFONumber
(
	[RFONumber] INT IDENTITY(1,1) PRIMARY KEY,
	[RFOName] NVARCHAR(50),
	[CustomerTypeId] INT FOREIGN KEY REFERENCES CustomerType([CustomerTypeid]),
	[CompanyId] INT FOREIGN KEY REFERENCES Company([CompanyId]),
	[CreatedDate] DATE,
	[CreatedBy] NVARCHAR(50),
	[UpdatedDate] DATE,
	[UpdatedBy] NVARCHAR(50),
	[PostCode] CHAR(10),
)

CREATE TABLE AgreementStatus
(
	[StatusId] INT IDENTITY(1,1) PRIMARY KEY,
	[AgreementStatus] NVARCHAR(100),
)

CREATE TABLE CommentType
(
	[CommentTypeId] INT IDENTITY(1,1) PRIMARY KEY,
	[CommentType] NVARCHAR(50),
)

CREATE TABLE FundingMethod
(
	[FundingMethodId] INT IDENTITY(1,1) PRIMARY KEY,
	[FundingMethodName] NVARCHAR(50),
	[FundingType] NVARCHAR(50),
	[ContractTemplateLocation] NVARCHAR(50),
	[SignedContractDefault] NVARCHAR(50),
	[Status] NVARCHAR(50),
	[AMISDeptCode] NVARCHAR(50),
	[AMISReasonCode] NVARCHAR(50),
)

CREATE TABLE Volume
(
	[VolumeId] INT IDENTITY(1,1) PRIMARY KEY,
	[TriggerCredit] NVARCHAR(50),
	[PaymentTo] NVARCHAR(50),
)

CREATE TABLE Banding
(
	[BandingId] INT IDENTITY(1,1) PRIMARY KEY,
	[VolumeId] INT FOREIGN KEY REFERENCES Volume([VolumeId]),
	[Min] INT,
	[Max] INT,
)

CREATE TABLE Agreement
(
	[AgreementNumber] INT,
	[VariantNumber] INT,
	[Name] NVARCHAR(100),
	[Description] NVARCHAR(1000),
	[StartDate] DATE,
	[EndDate] DATE,
	[StatusId] INT FOREIGN KEY REFERENCES AgreementStatus([StatusId]),
	[LastStatusUpdatedDate] DATE,
	[AuthorisedBy] NVARCHAR(50),
	[AuthorisedDate] DATE,
	[CreatedDate] DATE,
	[CreatedBy] NVARCHAR(50),
	[LastUpdatedDate] DATE,
	[LastUpdatedBy] NVARCHAR(50),
	[AMISAccountCode] NVARCHAR(50),
	[HandlingCharge] INT,
	[FundingMethodId] INT FOREIGN KEY REFERENCES FundingMethod([FundingMethodId]),
	[SignRequired] BIT,
	[SignReceived] BIT,
	[SignReceivedDate] DATE,
	[DealerVisibility] NVARCHAR(50),
	[Combinability] NVARCHAR(50),
	[NumberOfRegistrations] INT,
	[VolumeId] INT FOREIGN KEY REFERENCES Volume([VolumeId]),
	[DiscountUnit] INT,
	[VolumeDiscountTypeId] INT
	CONSTRAINT PK_Agreement PRIMARY KEY ([AgreementNumber],[VariantNumber]),
	CONSTRAINT FK_Agreement_VolumeDiscountType FOREIGN KEY([VolumeDiscountTypeId]) REFERENCES VolumeDiscountType([VolumeDiscountTypeId])
)

CREATE TABLE Comment
(
	[CommentId] INT IDENTITY(1,1) PRIMARY KEY,
	[AgreementNumber] INT,
	[VariantNumber] INT,
	[UserId] NVARCHAR(50),
	[DateTime] DATETIME,
	[Comment] NVARCHAR(1000),
	[CommentTypeId] INT FOREIGN KEY REFERENCES CommentType([CommentTypeId]),
	CONSTRAINT FK_Comment FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES Agreement([AgreementNumber],[VariantNumber]),
)

CREATE TABLE CreditNoteText
(
	[CreditNoteTextId] INT IDENTITY(1,1) PRIMARY KEY,
	[AgreementNumber] INT,
	[VariantNumber] INT,
	[DateTime] DATETIME,
	[CreditNoteText] NVARCHAR(1000),
	[SupportText] NVARCHAR(1000),
	CONSTRAINT FK_CreditNoteText FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES Agreement([AgreementNumber],[VariantNumber])
)

CREATE TABLE AgreementRFO
(
	[AgreementNumber] INT,
	[VariantNumber] INT,
	[RFONumber] INT FOREIGN KEY REFERENCES RFONumber([RFONumber]),
	CONSTRAINT FK_AgreementRFO FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES Agreement([AgreementNumber],[VariantNumber]),
	CONSTRAINT PK_AgreementRFO PRIMARY KEY ([AgreementNumber],[VariantNumber],[RFONumber])
)

CREATE TABLE UserType
(
	[UserTypeId] INT IDENTITY(1,1) PRIMARY KEY,
	[UserType] NVARCHAR(50),
)

CREATE TABLE RFOUser
(
	[UserId] INT IDENTITY(1,1) PRIMARY KEY,
	[ManagerId] INT FOREIGN KEY REFERENCES RFOUser([UserId]) NULL,
	[Title] NVARCHAR(50),
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[ExtranetUser] NVARCHAR(50),
	[EmailAddress] VARCHAR(50),
	[UserTypeId] INT FOREIGN KEY REFERENCES UserType([UserTypeId]),
	[Status] VARCHAR(50),
	[TargetNumberOfRegistrations] INT,
)

CREATE TABLE ContactAddress
(
	[ContactAddressId] INT IDENTITY(1,1) PRIMARY KEY,
	[UserId] INT FOREIGN KEY REFERENCES RFOUser([UserId]) NULL,
	[Town] NVARCHAR(50),
	[County] NVARCHAR(50),
	[Postcode] CHAR(10),
	[Country] NVARCHAR(50),
	[MobileNo] VARCHAR(12),
	[OfficeNo] VARCHAR(12),
	[FaxNo] VARCHAR(12),
	[Address1] NVARCHAR(50),
	[Address2] NVARCHAR(50),
	[Address3] NVARCHAR(50),
)

CREATE TABLE AgreementDealer
(
	[AgreementNumber] INT,
	[VariantNumber] INT,
	[DealerCode] INT FOREIGN KEY REFERENCES RFOUser([UserId]),
	CONSTRAINT FK_AgreementDealer FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES Agreement([AgreementNumber],[VariantNumber]),
	CONSTRAINT PK_AgreementDealer PRIMARY KEY ([AgreementNumber],[VariantNumber],[DealerCode]),
)

insert into AgreementStatus([AgreementStatus])values('Draft');
insert into AgreementStatus([AgreementStatus])values('Awaiting Approval');
insert into AgreementStatus([AgreementStatus])values('Signature Required');
insert into AgreementStatus([AgreementStatus])values('Approved');
insert into AgreementStatus([AgreementStatus])values('Rejected');
insert into AgreementStatus([AgreementStatus])values('Discontinued');
insert into AgreementStatus([AgreementStatus])values('Archived');
insert into AgreementStatus([AgreementStatus])values('Overdue');

CREATE TABLE VolumeDiscountType
(
	VolumeDiscountTypeId INT IDENTITY(1,1) PRIMARY KEY,
	VolumeDiscountTypeName NVARCHAR(50)
)

INSERT INTO CustomerType([CustomerType]) VALUES(N'Fleet');
INSERT INTO CustomerType([CustomerType]) VALUES(N'Fleasing');

INSERT INTO Company([Name], [Type], [Status], [Sector], [PhoneNumber], [FaxNumber]
	, [Emailaddress], [CreatedDate], [CreatedBy], [AMISCode], [BusinessArea])
	VALUES (N'Bank of England', N'Type1', N'Status1', N'Sector1', N'123456789', N'12345'
	, N'company1@gmail.com', '08/24/2014', N'User1', N'Code1', N'-100');
INSERT INTO Company([Name], [Type], [Status], [Sector], [PhoneNumber], [FaxNumber]
	, [Emailaddress], [CreatedDate], [CreatedBy], [AMISCode], [BusinessArea])
	VALUES (N'Thames bank Industries', N'Type2', N'Status2', N'Sector2', N'123456789', N'12345'
	, N'company2@gmail.com', '09/24/2014', N'User2', N'Code2', N'+100');
INSERT INTO Company([Name], [Type], [Status], [Sector], [PhoneNumber], [FaxNumber]
	, [Emailaddress], [CreatedDate], [CreatedBy], [AMISCode], [BusinessArea])
	VALUES (N'Royal of Scotland', N'Type3', N'Status3', N'Sector3', N'123456789', N'12345'
	, N'company3@gmail.com', '08/22/2013', N'User3', N'Code3', N'-100');
INSERT INTO Company([Name], [Type], [Status], [Sector], [PhoneNumber], [FaxNumber]
	, [Emailaddress], [CreatedDate], [CreatedBy], [AMISCode], [BusinessArea])
	VALUES (N'Southern banking', N'Type4', N'Status4', N'Sector4', N'123456789', N'12345'
	, N'company4@gmail.com', '09/22/2013', N'User4', N'Code4', N'-100');

INSERT INTO RFONumber([RFOName], [CustomerTypeId], [CompanyId], [CreatedDate]
	, [CreatedBy], [UpdatedDate], [UpdatedBy], [PostCode])
	VALUES (N'RFO1', 1, 1, '08/24/2014', N'User1', '08/28/2014', N'User2', 'RG21 3FR')
INSERT INTO RFONumber([RFOName], [CustomerTypeId], [CompanyId], [CreatedDate]
	, [CreatedBy], [UpdatedDate], [UpdatedBy], [PostCode])
	VALUES (N'RFO2', 2, 2, '08/24/2014', N'User2', '09/29/2014', N'User3', 'SO43 4TR')
INSERT INTO RFONumber([RFOName], [CustomerTypeId], [CompanyId], [CreatedDate]
	, [CreatedBy], [UpdatedDate], [UpdatedBy], [PostCode])
	VALUES (N'RFO3', 1, 3, '09/22/2013', N'User3', '10/25/2013', N'User4', 'SL7 52R')
INSERT INTO RFONumber([RFOName], [CustomerTypeId], [CompanyId], [CreatedDate]
	, [CreatedBy], [UpdatedDate], [UpdatedBy], [PostCode])
	VALUES (N'RFO4', 2, 4, '09/25/2013', N'User4', '11/25/2013', N'User5', 'AB5 7DD')

INSERT INTO FundingMethod([FundingMethodName], [FundingType], [ContractTemplateLocation]
	,[SignedContractDefault], [Status], [AMISDeptCode], [AMISReasonCode])
	VALUES(N'Fleet', N'', N'', N'', N'', N'', N'')

CREATE TABLE SYSCFT
(
	NSYSTEMCONFGID INT PRIMARY KEY,
	XSYSCONFIGNAME NVARCHAR(50)
)

CREATE TABLE SYSCVT
(
	NSYSCONFIGVALID INT PRIMARY KEY,
	XCONFIGVALUE NVARCHAR(50),
	NORDER INT,
	NSYSTEMCONFGID INT,
	CONSTRAINT FK_SYSCVT_SYSCFT FOREIGN KEY(NSYSTEMCONFGID) REFERENCES SYSCFT(NSYSTEMCONFGID)
)

insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(1,'PAYMENT TO');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(2,'DEALER VISIBILITY');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(3,'DISCOUNT UNIT');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(4,'COMBINABILITY');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(5,'TRIGGER CREDIT ');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(6,'CRM AGREEMENT FILE LOCATION');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(7,'FUNDING TYPE');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(8,'FUNDING STATUS');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(9,'ARCHIVE YEARS');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(10,'SCHEDULED DATES');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(11,'VOLUME DISCOUNT TYPE');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(12,'BUSINESS AREA');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(13,'NUMBER LEVEL');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(14,'SIGNED CONTRACT DEFAULT');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(15,'ORDER TYPE');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(16,'REG TYPE');
insert into SYSCFT(NSYSTEMCONFGID,XSYSCONFIGNAME)values(17,'FUNDING MATCH BASED ON');



insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(1,'Customer',1,1);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(2,'Dealer',2,1);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(3,'All',1,2);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(4,'Preferred dealers only',2,2);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(5,'Selected dealers only',3,2);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(6,'Leasing co. preferred dealers only',4,2);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(7,'£',1,3);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(8,'%',2,3);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(9,'End user support only',1,4);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(10,'Leasing support only',2,4);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(11,'End user and Leasing',3,4);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(12,'End of ki',1,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(13,'End of month',2,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(14,'end of quarter',3,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(15,'June 30th & Dec 31st',4,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(16,'End of calendar year',5,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(17,'Move to next Banding',6,5);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(18,'G:\Wip\Documents\Q&A',1,6);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(19,'C:\Setup_Ruby\Watir',2,6);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(20,'End User',1,7);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(21,'Leasing',2,7);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(22,'Active',1,8);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(23,'InActive',2,8);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(24,'60',1,9);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(25,'30',2,9);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(26,'Immediate',1,10);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(27,'daily',2,10);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(28,'weekly',3,10);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(29,'None',4,10);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(30,'None',1,11);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(31,'Banding',2,11);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(32,'Retrospective Banding',3,11);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(33,'0 - 100',1,12);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(34,'100+',2,12);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(35,'8',1,13);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(36,'Yes(Enable)',2,14);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(37,'Yes(Protected)',2,14);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(38,'No',2,14);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(39,'Fleet',1,15);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(40,'Leasing',2,15);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(41,'R',1,16);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(42,'P',2,16);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(48, 'Registration date', 0, 17);
insert into SYSCVT(NSYSCONFIGVALID,XCONFIGVALUE,NORDER,NSYSTEMCONFGID)values(49, 'Order date', 1, 17);
insert into SYSCVT (NSYSCONFIGVALID, XCONFIGVALUE, NORDER, NSYSTEMCONFGID) values (50, 'Leasing campaign: In lieu of end user support', 0, 4);

INSERT INTO RFOUser([FirstName], [LastName]) VALUES(N'Westgate', N'Honda')
INSERT INTO RFOUser([FirstName], [LastName]) VALUES(N'R J Williams', N'Honda')
INSERT INTO RFOUser([FirstName], [LastName]) VALUES(N'Rylan', N'Honda')
INSERT INTO RFOUser([FirstName], [LastName]) VALUES(N'Yeomans', N'Honda')

INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (1, N'Grimsby', N'North East Lincolnshire')
INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (2, N'Talsarnau', N'Gwynedd')
INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (3, N'Cardiff', N'')
INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (4, N'Bognor Regis', N'West Sussex')
INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (4, N'Farnham', N'Surrey')
INSERT INTO ContactAddress([UserId], [Town], [County]) VALUES (4, N'Littlehampton', N'West Sussex')