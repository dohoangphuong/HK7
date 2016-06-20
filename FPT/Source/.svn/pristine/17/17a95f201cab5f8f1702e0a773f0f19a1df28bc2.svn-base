/*- Organization details 2 tab
- Organization details 4 tab (list premises)
- Service Attendance?
- string, bit should never be null?
*/

use master
if exists (select * from sys.databases where Name like 'ABSDDatabase')
drop database ABSDDatabase
create database ABSDDatabase
use ABSDDatabase
set dateformat dmy

/*ORGANIZATION*/
create table Organization
(
	OrganizationId int primary key identity(1,1),
	OrganizationName nvarchar(100) not null,
	OrganizationShortDescription nvarchar(500) not null,
	LeadContactId int not null,
	AddressLine1 nvarchar(200) not null,
	AddressLine2 nvarchar(200),
	AddressLine3 nvarchar(200),
	Postcode varchar(20) not null,
	CityTown nvarchar(50),
	CountyId int,
	CountryId int,
	IsPreferredOrganization bit,
	IsExpressionOfInterest bit,
	TypeOfBusiness nvarchar(100) not null,
	SICCode varchar(20) not null,
	OrganizationFullDescription nvarchar(2000),
	PhoneNumber varchar(20),
	Fax varchar(20),
	Email varchar(50),
	WebAddress varchar(50),
	CharityNumber varchar(20),
	CompanyNumber varchar(20),

	IsActive bit not null
);

create table Organization_RefDataDetail
(
	Organization_RefDataDetailId int primary key identity(1,1),
	OrganizationId int not null,
	RefDataDetailId int not null
);

create table SupportingMaterial
(
	SupportingMaterialId int primary key identity(1,1),
	Url nvarchar(100) not null,
	Description nvarchar(500),
	SupportingMaterialTypeId int not null,
	UserAddedId int not null,
	DateAdded DateTime not null,
	IsActive bit not null,

	OrganizationId int not null
);

create table Directorate
(
	DirectorateId int primary key identity(1,1),
	DirectorateName nvarchar(100) not null,
	DirectorateShortDescription nvarchar(500),
	LeadContactId int,
	AddressLine1 nvarchar(200) not null,
	AddressLine2 nvarchar(200),
	AddressLine3 nvarchar(200),
	Postcode varchar(20) not null,
	TownVillageCity nvarchar(200),
	CountyId int,
	CountryId int,
	TypeOfBusiness nvarchar(100) not null,
	SICCode varchar(20) not null,
	DirectorateFullDescription nvarchar(2000),
	PhoneNumber varchar(20),
	Fax varchar(20),
	Email varchar(50),
	WebAddress nvarchar(50),
	CharityNumber varchar(20),
	CompanyNumber varchar(20),

	IsActive bit not null,
	OrganizationId int not null

);

create table Department
(
	DepartmentId int primary key identity(1,1),
	DepartmentShortDescription nvarchar(500) not null,
	LeadContactId int,
	AddressLine1 nvarchar(200),
	AddressLine2 nvarchar(200),
	AddressLine3 nvarchar(200),
	Postcode varchar(20),
	TownVillagecity nvarchar(200),
	CountyId int,
	CountryId int,
	TypeOfBusiness nvarchar(100),
	SICCode varchar(20),
	DepartmentFullDescription nvarchar(2000),
	PhoneNumber varchar(20),
	Fax varchar(20),
	Email varchar(50),
	WebAddress nvarchar(100),

	IsActive bit not null,
	DirectorateId int not null
);

create table Team
(
	TeamId int primary key identity(1,1),
	TeamName nvarchar(50) not null unique,
	TeamShortDescription nvarchar(500),
	LeadContactId int,
	AddressLine1 nvarchar(200),
	AddressLine2 nvarchar(200),
	AddressLine3 nvarchar(200),
	Postcode varchar(20),
	TownVillageCity nvarchar(200),
	CountyId int,
	CountryId int,
	TypeOfBusiness nvarchar(100),
	SICCode varchar(20),
	TeamFullDescription nvarchar(2000),
	PhoneNumber varchar(20),
	Fax varchar(20),
	Email varchar(50),
	WebAddress nvarchar(100),

	IsActive bit not null,
	DepartmentId int not null
)

create table SupportingMaterialType
(
	SupportingMaterialTypeId int primary key identity(1,1),
	SupportingMaterialTypeName varchar(10) not null
)

create table County
(
	CountyId int primary key identity(1,1),
	CountyName nvarchar(50) not null
)

create table Country
(
	CountryId int primary key identity(1,1),
	CountryName nvarchar(50) not null
)

/*
create table Organization_Service
(
	Organization_ServiceId int primary key identity(1,1),
	OrganizationId int not null,
	ServiceId int not null,
);
*/

create table Organization_Programme
(
	Organization_ProgrammeId int primary key identity(1,1),
	OrganizationId int not null,
	ProgrammeId int not null
);
/*
create table Organization_Premise
(

)
*/
/*SERVICE*/
create table Service
(
	ServiceId int primary key identity(1,1),
	ServiceName nvarchar(50) not null unique,
	ServiceShortDescription nvarchar(500) not null,
	ServiceSubTypeId int not null,
	LeadContactId int not null,
	ClientDescription nvarchar(500),
	ServiceAttendance nvarchar(100),
	ServiceStartExpected DateTime,
	ServiceStartDate DateTime,
	ServiceEndDate DateTime,
	ServiceExtendable bit,
	ServiceExtendableMonth int,
	ServiceExtendableYear int,
	ServiceFullDescription nvarchar(2000),
	DepartmentCode varchar(50) not null,
	ServiceTypeId int not null,
	ServiceDescriptionDelivery nvarchar(500),
	ServiceContractCode varchar(50),
	ServiceContractValue varchar(50),
	IsContractStagedPayment bit,
	ReferralMethodId int,
	IsTimeLimited bit,
	LimitedYears int,
	LimitedMonths int,

	ProgrammeId int,

	ContractParticipationTypeId int,

	IsActive bit not null,
)

create table ContractParticipationType
(
	ContractParticipationTypeId int primary key identity(1,1),
	ContractParticipationTypeName varchar(30) not null
)

create table ServiceFunding
(
	ServiceFundingId int primary key identity(1,1),
	FundingSourceId int,
	FundingContactId int not null,
	FundingAmount decimal not null,
	FundingStart date,
	FundingEnd date,
	FundingNeeds decimal,
	IsFundingContinuationNeeded bit,
	FundingContinuationAmount decimal,
	FundingContinuationDetail nvarchar(500),
	FundraisingForText nvarchar(500),
	FundraisingWhy nvarchar(500),
	FundraisingNeeds decimal,
	FundraisingRequiredBy date,
	IsFundRaisingComplete bit,
	FundraisingCompletedDate date,
	FundraisingDonorAnynymous bit,
	FundraisingDonorAmount decimal,
	FundDonationDate date,
	IsFundraisingDonationIncremental bit,

	ServiceId int not null
);

create table Service_Organization_OrganizationRoleType
(
	Service_Organization_OrganizationRoleTypeId int primary key identity(1,1),
	ServiceId int not null,
	OrganizationId int not null,
	OrganizationRoleTypeId int not null
)

create table OrganizationRoleType
(
	OrganizationRoleTypeId int primary key identity(1,1),
	OrganizationRoleTypeName nvarchar(100)
)

create table Service_RefDataDetail
(
	Service_RefDataDetailId int primary key identity(1,1),
	ServiceId int not null,
	RefDataDetailId int not null
);


create table FundingSource
(
	FundingSourceId int primary key identity(1,1),
	FundingSourceName nvarchar(200) not null
);

create table ReferralMethod
(
	ReferralMethodId int primary key identity(1,1),
	ReferralMethodName nvarchar(50) not null 
);

create table ServiceSubType
(
	ServiceSubTypeId int primary key identity(1,1),
	ServiceSubTypeName nvarchar(50) not null unique
);

create table ServiceType
(
	ServiceTypeId int primary key identity(1,1),
	ServiceTypeName nvarchar(50) not null unique
);

create table Service_Premise
(
	Service_PremiseId int primary key identity(1,1),
	ServiceId int not null,
	PremiseId int not null
);

create table RefData
(
	RefDataId int primary key identity(1,1),
	RefDataName nvarchar(200) not null unique,
	RefDataValue nvarchar(200) not null
);

create table RefDataDetail
(
	RefDataDetailId int primary key identity(1,1),
	RefDataDetailValue nvarchar(200) not null unique,
	RefDataId int not null
);

create table Programme
(
	ProgrammeId int primary key identity(1,1),
	ProgrammeName nvarchar(100) not null,
	ProgrammeDescription nvarchar(500),
	ContactId int,

	IsActive bit not null,
);

create table TrustRegion
(
	TrustRegionId int primary key identity(1,1),
	CountryId int not null,
	TrustRegionName nvarchar(100) not null,
	Description nvarchar(500),

	IsActive bit not null,
);

create table TrustDistrict
(
	TrustDistrictId int primary key identity(1,1),
	TrustDistrictName nvarchar(100) not null unique,
	Description nvarchar(500),

	TrustRegionId int not null,

	IsActive bit not null,
);

create table GovOfficeRegion
(
	GovOfficeRegionId int primary key identity(1,1),
	GovOfficeRegionName nvarchar(100),

	IsActive bit not null,
);

create table GovOfficeRegion_County
(
	GovOfficeRegion_CountyId int primary key identity(1,1),
	GovOfficeRegionId int not null,
	CountyId int not null,
);

create table Premise
(
	PremiseId int primary key identity(1,1),
	LocationName nvarchar(100) not null,
	KnownAs nvarchar(100),
	LocationOrganizationId int,
	LocationStatusId int not null,
	LocationStatusDate date,
	AddressLine1 nvarchar(200),
	AddressLine2 nvarchar(200),
	AddressLine3 nvarchar(200),
	Postcode varchar(20),
	CityTown nvarchar(20),
	CountyId int,
	CountryId int,
	IsPrimaryLocation bit,
	IsLocationManaged bit,
	HasSTNetworkConnectivity bit,
	LocationDescription nvarchar(500),
	PhoneNumber varchar(20) not null,
	GeneralFaxNumber varchar(20),
	MinicommNumber varchar(20),
	IsNewShop bit,
	ShopFlagDate date,
	IsSpecialistShop bit,
	/*Location opening day*/

)

/*Premise detail tab 2++*/

create table LocationStatus
(
	LocationStatusId int primary key identity(1,1),
	LocationStatusName varchar(20) not null
);

create table LocationType
(
	LocationTypeId int primary key identity(1,1),
	LocationTypeName nvarchar(50) not null
);

create table Premise_LocationType
(
	Premise_LocationTypeId int primary key identity(1,1),
	PremiseId int not null,
	LocationTypeId int not null
);

/*Facility maintenance*/




create table Contact
(
	ContactId int primary key identity(1,1),
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	KnownAs nvarchar(20) not null,
	OfficePhone varchar(20),
	MobilePhone varchar(20),
	STHomePhone varchar(20),
	EmailAddress varchar(50),
	ManagerContactId int,
	ContactTypeId int not null,
	BestContactMethodId int,
	JobRole nvarchar(20),
	WorkBase nvarchar(20),
	JobTitle nvarchar(20),
	IsActive bit not null
);

create table ContactType
(
	ContactTypeId int primary key identity(1,1),
	ContactTypeName nvarchar(20)
);

create table BestContactMethod
(
	BestContactMethodId int primary key identity(1,1),
	BestContactMethodName nvarchar(20)
);

create table Address
(
	AddressId int primary key identity(1,1),
	Address nvarchar(100) not null unique,
	Postcode varchar(20) not null,
	Town nvarchar(50) not null,
	County nvarchar(50) not null,
	Country nvarchar(50) not null
);

create table TypeOfBusiness
(
	TypeOfBusinessId int primary key identity(1,1),
	BusinessName nvarchar(100) not null unique,
	SICCode varchar(20) not null unique
);

/*Foreign key*/





alter table Organization add constraint fk_Organization_Contact
foreign key (LeadContactId) references Contact(ContactId)

alter table Organization add constraint fk_Organization_County
foreign key (CountyId) references County(CountyId)

alter table Organization add constraint fk_Organization_Country
foreign key (CountryId) references Country(CountryId)

alter table Organization_RefDataDetail add constraint fk_Organization_RefDataDetail_Organization
foreign key (OrganizationId) references Organization(OrganizationId)

alter table Organization_RefDataDetail add constraint fk_Organization_RefDataDetail_RefDataDetail
foreign key (RefDataDetailId) references RefDataDetail(RefDataDetailId)

alter table SupportingMaterial add constraint fk_SupportingMaterial_SupportingMaterialType
foreign key (SupportingMaterialTypeId) references SupportingMaterialType(SupportingMaterialTypeId)

alter table SupportingMaterial add constraint fk_SupportingMaterial_Organization
foreign key (OrganizationId) references Organization(OrganizationId)

alter table Directorate add constraint fk_Directorate_Contact
foreign key (LeadContactId) references Contact(ContactId)

alter table Directorate add constraint fk_Directorate_County
foreign key (CountyId) references County(CountyId)

alter table Directorate add constraint fk_Directorate_Country
foreign key (CountryId) references Country(CountryId)

alter table Directorate add constraint fk_Directorate_Organization
foreign key (OrganizationId) references Organization(OrganizationId)

alter table Department add constraint fk_Department_Contact
foreign key (LeadContactId) references Contact(ContactId)

alter table Department add constraint fk_Department_County
foreign key (CountyId) references County(CountyId)

alter table Department add constraint fk_Department_Country
foreign key (CountryId) references Country(CountryId)

alter table Department add constraint fk_Department_Directorate
foreign key (DirectorateId) references Directorate(DirectorateId)

alter table Team add constraint fk_Team_Contact
foreign key (LeadContactId) references Contact(ContactId)

alter table Team add constraint fk_Team_County
foreign key (CountyId) references County(CountyId)

alter table Team add constraint fk_Team_Country
foreign key (CountryId) references Country(CountryId)

alter table Organization_Programme add constraint fk_Organization_Programme_Organization
foreign key (OrganizationId) references Organization(OrganizationId)

alter table Organization_Programme add constraint fk_Organization_Programme_Programme
foreign key (ProgrammeId) references Programme(ProgrammeId)

alter table Service add constraint fk_Service_ServiceSubType
foreign key (ServiceSubTypeId) references ServiceSubType(ServiceSubTypeId)

alter table Service add constraint fk_Service_Contact
foreign key (LeadContactId) references Contact(ContactId)

alter table Service add constraint fk_Service_ServiceType
foreign key (ServiceTypeId) references ServiceType(ServiceTypeId)

alter table Service add constraint fk_Service_ReferralMethod
foreign key (ReferralMethodId) references ReferralMethod(ReferralMethodId)

alter table Service add constraint fk_Service_Programme
foreign key (ProgrammeId) references Programme(ProgrammeId)

alter table Service add constraint fk_Service_ContractParticipationType
foreign key (ContractParticipationTypeId) references ContractParticipationType(ContractParticipationTypeId)

alter table ServiceFunding add constraint fk_ServiceFunding_FundingSource
foreign key (FundingSourceId) references FundingSource(FundingSourceId)

alter table ServiceFunding add constraint fk_ServiceFunding_Contact
foreign key (FundingContactId) references Contact(ContactId)

alter table ServiceFunding add constraint fk_ServiceFunding_Service
foreign key (ServiceId) references Service(ServiceId)

alter table Service_Organization_OrganizationRoleType add constraint fk_Service_Organization_OrganizationRoleType_Service
foreign key (ServiceId) references Service(ServiceId)

alter table Service_Organization_OrganizationRoleType add constraint fk_Service_Organization_OrganizationRoleType_Organization
foreign key (OrganizationId) references Organization(OrganizationId)

alter table Service_Organization_OrganizationRoleType add constraint fk_Service_Organization_OrganizationRoleType_OrganizationRoleType
foreign key (OrganizationRoleTypeId) references OrganizationRoleType(OrganizationRoleTypeId)

alter table Service_RefDataDetail add constraint fk_Service_RefDataDetail_Service
foreign key (ServiceId) references Service(ServiceId)

alter table Service_RefDataDetail add constraint fk_Service_RefDataDetail_RefDataDetail
foreign key (RefDataDetailId) references RefDataDetail(RefDataDetailId)

alter table Service_Premise add constraint fk_Service_Premise_Service
foreign key (ServiceId) references Service(ServiceId)

alter table Service_Premise add constraint fk_Service_Premise_PRemise
foreign key (PremiseId) references PRemise(PremiseId)

alter table RefDataDetail add constraint fk_RefDataDetail_RefData
foreign key (RefDataId) references RefData(RefDataId)

alter table Programme add constraint fk_Programme_Contact
foreign key (ContactId) references Contact(ContactId)

alter table TrustRegion add constraint fk_TrustRegion_Country
foreign key (CountryId) references Country(CountryId)

alter table TrustDistrict add constraint fk_TrustDistrict_TrustRegion
foreign key (TrustRegionId) references TrustRegion(TrustRegionId)

alter table GovOfficeRegion_County add constraint fk_GovOfficeRegion_County_GovOfficeRegion
foreign key (GovOfficeRegionId) references GovOfficeRegion(GovOfficeRegionId)

alter table GovOfficeRegion_County add constraint fk_GovOfficeRegion_County_County
foreign key (CountyId) references County(CountyId)

alter table Premise add constraint fk_Premise_Organization
foreign key (LocationOrganizationId) references Organization(OrganizationId)

alter table Premise add constraint fk_Premise_LocationStatus
foreign key (LocationStatusId) references LocationStatus(LocationStatusId)

alter table Premise add constraint fk_Premise_County
foreign key (CountyId) references County(CountyId)

alter table Premise add constraint fk_Premise_Country
foreign key (CountryId) references Country(CountryId)

alter table Premise_LocationType add constraint fk_Premise_LocationType_Premise
foreign key (PremiseId) references Premise(PremiseId)

alter table Premise_LocationType add constraint fk_Premise_LocationType_LocationType
foreign key (LocationTypeId) references LocationType(LocationTypeId)

alter table Contact add constraint fk_Contact_Contact
foreign key (ManagerContactId) references Contact(ContactId)

alter table Contact add constraint fk_Contact_ContactType
foreign key (ContactTypeId) references ContactType(ContactTypeId)

alter table Contact add constraint fk_Contact_BestContactMethod
foreign key (BestContactMethodId) references BestContactMethod(BestContactMethodId)

