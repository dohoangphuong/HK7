/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                  */
/* Created on:     9/01/2015 01:28:08 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Address') and o.name = 'FK_ADDRESS_IN3_TOWN')
alter table Address
   drop constraint FK_ADDRESS_IN3_TOWN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Contact') and o.name = 'FK_CONTACT_MANAGER_CONTACT')
alter table Contact
   drop constraint FK_CONTACT_MANAGER_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('County') and o.name = 'FK_COUNTY_IS_COUNTRY')
alter table County
   drop constraint FK_COUNTY_IS_COUNTRY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Department') and o.name = 'FK_DEPARTME_HAVE_CONTACT')
alter table Department
   drop constraint FK_DEPARTME_HAVE_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Department') and o.name = 'FK_DEPARTME_HAVE3_DIRECTOR')
alter table Department
   drop constraint FK_DEPARTME_HAVE3_DIRECTOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Directorate') and o.name = 'FK_DIRECTOR_HAVE2_ORGANISA')
alter table Directorate
   drop constraint FK_DIRECTOR_HAVE2_ORGANISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Directorate') and o.name = 'FK_DIRECTOR_OF1_CONTACT')
alter table Directorate
   drop constraint FK_DIRECTOR_OF1_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GovOfficeRegion') and o.name = 'FK_GOVOFFIC_OF_COUNTY')
alter table GovOfficeRegion
   drop constraint FK_GOVOFFIC_OF_COUNTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Organisation') and o.name = 'FK_ORGANISA_OF2_CONTACT')
alter table Organisation
   drop constraint FK_ORGANISA_OF2_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrganisationProgramme') and o.name = 'FK_ORGANISA_ORGANISAT_ORGANISA')
alter table OrganisationProgramme
   drop constraint FK_ORGANISA_ORGANISAT_ORGANISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrganisationProgramme') and o.name = 'FK_ORGANISA_ORGANISAT_PROGRAMM')
alter table OrganisationProgramme
   drop constraint FK_ORGANISA_ORGANISAT_PROGRAMM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Premise') and o.name = 'FK_PREMISE_IN2_SERVICE')
alter table Premise
   drop constraint FK_PREMISE_IN2_SERVICE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Programme') and o.name = 'FK_PROGRAMM_OF4_CONTACT')
alter table Programme
   drop constraint FK_PROGRAMM_OF4_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ServiceOrganisation') and o.name = 'FK_SERVICEO_SERVICEOR_SERVICE')
alter table ServiceOrganisation
   drop constraint FK_SERVICEO_SERVICEOR_SERVICE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ServiceOrganisation') and o.name = 'FK_SERVICEO_SERVICEOR_ORGANISA')
alter table ServiceOrganisation
   drop constraint FK_SERVICEO_SERVICEOR_ORGANISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SupportingMaterial') and o.name = 'FK_SUPPORTI_USE1_USER')
alter table SupportingMaterial
   drop constraint FK_SUPPORTI_USE1_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SupportingMaterial') and o.name = 'FK_SUPPORTI_USE2_ORGANISA')
alter table SupportingMaterial
   drop constraint FK_SUPPORTI_USE2_ORGANISA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Team') and o.name = 'FK_TEAM_HAVE4_DEPARTME')
alter table Team
   drop constraint FK_TEAM_HAVE4_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Team') and o.name = 'FK_TEAM_OF3_CONTACT')
alter table Team
   drop constraint FK_TEAM_OF3_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Town') and o.name = 'FK_TOWN_IN4_COUNTY')
alter table Town
   drop constraint FK_TOWN_IN4_COUNTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TrustDistrict') and o.name = 'FK_TRUSTDIS_IN_TRUSTREG')
alter table TrustDistrict
   drop constraint FK_TRUSTDIS_IN_TRUSTREG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TrustRegion') and o.name = 'FK_TRUSTREG_INCLUDE_COUNTRY')
alter table TrustRegion
   drop constraint FK_TRUSTREG_INCLUDE_COUNTRY
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Address')
            and   name  = 'IN3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Address.IN3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Address')
            and   type = 'U')
   drop table Address
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Contact')
            and   name  = 'MANAGER_FK'
            and   indid > 0
            and   indid < 255)
   drop index Contact.MANAGER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Contact')
            and   type = 'U')
   drop table Contact
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Country')
            and   type = 'U')
   drop table Country
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('County')
            and   name  = 'IS_FK'
            and   indid > 0
            and   indid < 255)
   drop index County.IS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('County')
            and   type = 'U')
   drop table County
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Department')
            and   name  = 'HAVE_FK'
            and   indid > 0
            and   indid < 255)
   drop index Department.HAVE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Department')
            and   name  = 'HAVE3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Department.HAVE3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Directorate')
            and   name  = 'OF1_FK'
            and   indid > 0
            and   indid < 255)
   drop index Directorate.OF1_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Directorate')
            and   name  = 'HAVE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Directorate.HAVE2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Directorate')
            and   type = 'U')
   drop table Directorate
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GovOfficeRegion')
            and   name  = 'OF_FK'
            and   indid > 0
            and   indid < 255)
   drop index GovOfficeRegion.OF_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GovOfficeRegion')
            and   type = 'U')
   drop table GovOfficeRegion
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Organisation')
            and   name  = 'OF2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Organisation.OF2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Organisation')
            and   type = 'U')
   drop table Organisation
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OrganisationProgramme')
            and   name  = 'ORGANISATIONPROGRAMME2_FK'
            and   indid > 0
            and   indid < 255)
   drop index OrganisationProgramme.ORGANISATIONPROGRAMME2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OrganisationProgramme')
            and   name  = 'ORGANISATIONPROGRAMME_FK'
            and   indid > 0
            and   indid < 255)
   drop index OrganisationProgramme.ORGANISATIONPROGRAMME_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrganisationProgramme')
            and   type = 'U')
   drop table OrganisationProgramme
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Premise')
            and   name  = 'IN2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Premise.IN2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Premise')
            and   type = 'U')
   drop table Premise
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Programme')
            and   name  = 'OF4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Programme.OF4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Programme')
            and   type = 'U')
   drop table Programme
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReferenceData')
            and   type = 'U')
   drop table ReferenceData
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Service')
            and   type = 'U')
   drop table Service
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ServiceOrganisation')
            and   name  = 'SERVICEORGANISATION2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ServiceOrganisation.SERVICEORGANISATION2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ServiceOrganisation')
            and   name  = 'SERVICEORGANISATION_FK'
            and   indid > 0
            and   indid < 255)
   drop index ServiceOrganisation.SERVICEORGANISATION_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ServiceOrganisation')
            and   type = 'U')
   drop table ServiceOrganisation
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SupportingMaterial')
            and   name  = 'USE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index SupportingMaterial.USE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SupportingMaterial')
            and   name  = 'USE1_FK'
            and   indid > 0
            and   indid < 255)
   drop index SupportingMaterial.USE1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SupportingMaterial')
            and   type = 'U')
   drop table SupportingMaterial
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Team')
            and   name  = 'HAVE4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Team.HAVE4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Team')
            and   name  = 'OF3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Team.OF3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Team')
            and   type = 'U')
   drop table Team
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Town')
            and   name  = 'IN4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Town.IN4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Town')
            and   type = 'U')
   drop table Town
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TrustDistrict')
            and   name  = 'IN_FK'
            and   indid > 0
            and   indid < 255)
   drop index TrustDistrict.IN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrustDistrict')
            and   type = 'U')
   drop table TrustDistrict
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TrustRegion')
            and   name  = 'INCLUDE_FK'
            and   indid > 0
            and   indid < 255)
   drop index TrustRegion.INCLUDE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrustRegion')
            and   type = 'U')
   drop table TrustRegion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"User"')
            and   type = 'U')
   drop table "User"
go

/*==============================================================*/
/* Table: Address                                               */
/*==============================================================*/
create table Address (
   AddressID            int                  not null,
   TownID               int                  null,
   AddressPostcode      char(10)             null,
   constraint PK_ADDRESS primary key nonclustered (AddressID)
)
go

/*==============================================================*/
/* Index: IN3_FK                                                */
/*==============================================================*/
create index IN3_FK on Address (
TownID ASC
)
go

/*==============================================================*/
/* Table: Contact                                               */
/*==============================================================*/
create table Contact (
   ContactID            int                  not null,
   ManagerID            int                  null,
   FirstName            varchar(200)         null,
   SurnName             varchar(100)         null,
   KnowAs               varchar(200)         null,
   ContactType          char(10)             null,
   BestContactMethod    char(10)             null,
   MobilePhone          char(20)             null,
   OfficePhone          char(20)             null,
   STHomePhone          char(20)             null,
   ContactEmail         text                 null,
   ContactIsActive      bit                  null,
   Workbase             varchar(100)         null,
   JobRole              varchar(100)         null,
   constraint PK_CONTACT primary key nonclustered (ContactID)
)
go

/*==============================================================*/
/* Index: MANAGER_FK                                            */
/*==============================================================*/
create index MANAGER_FK on Contact (
ManagerID ASC
)
go

/*==============================================================*/
/* Table: Country                                               */
/*==============================================================*/
create table Country (
   CountryID            int                  not null,
   CountryName          text                 null,
   constraint PK_COUNTRY primary key nonclustered (CountryID)
)
go

/*==============================================================*/
/* Table: County                                                */
/*==============================================================*/
create table County (
   CountyID             int                  not null,
   CountryID            int                  not null,
   CountyName           text                 null,
   constraint PK_COUNTY primary key nonclustered (CountyID)
)
go

/*==============================================================*/
/* Index: IS_FK                                                 */
/*==============================================================*/
create index IS_FK on County (
CountryID ASC
)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   DepartmentID         int                  not null,
   DirectorateID        int                  null,
   ContactID            int                  null,
   DepartmentName       varchar(100)         not null,
   DepartmentShortDescription text                 not null,
   DepartmentAddressLine1 text                 null,
   DepartmentAddressLine2 text                 null,
   DepartmentAddressLine3 text                 null,
   DepartmentWebAddress text                 null,
   DepartmentPostcode   char(10)             null,
   DepartmentTownVillageCity text                 null,
   DepartmentCounty     text                 null,
   DepartmentNationCountry text                 null,
   DepartmentFullDescription text                 null,
   DepartmentPhoneNumber char(20)             null,
   DepartmentFax        char(20)             null,
   DepartmentEmail      text                 null,
   DepartmentStatus     bit                  null,
   constraint PK_DEPARTMENT primary key nonclustered (DepartmentID)
)
go

/*==============================================================*/
/* Index: HAVE3_FK                                              */
/*==============================================================*/
create index HAVE3_FK on Department (
DirectorateID ASC
)
go

/*==============================================================*/
/* Index: HAVE_FK                                               */
/*==============================================================*/
create index HAVE_FK on Department (
ContactID ASC
)
go

/*==============================================================*/
/* Table: Directorate                                           */
/*==============================================================*/
create table Directorate (
   DirectorateID        int                  not null,
   ContactID            int                  null,
   OrgID                int                  null,
   DirectorateName      varchar(100)         null,
   DirectoratePhoneNumber char(20)             null,
   DirectorateFax       char(20)             null,
   DirectorateEmail     text                 null,
   DirectorateWebAddress text                 null,
   DirectorateCharityNumber int                  null,
   DirectorateCompanyNumber int                  null,
   DirectorateAddressLine1 text                 null,
   DirectorateAddressLine2 text                 null,
   DirectorateAddressLine3 text                 null,
   DirectorateCountry   text                 null,
   DirectorateShortDescription text                 null,
   DirectorateFullDescription text                 null,
   DirectorateNationCountry text                 null,
   constraint PK_DIRECTORATE primary key nonclustered (DirectorateID)
)
go

/*==============================================================*/
/* Index: HAVE2_FK                                              */
/*==============================================================*/
create index HAVE2_FK on Directorate (
OrgID ASC
)
go

/*==============================================================*/
/* Index: OF1_FK                                                */
/*==============================================================*/
create index OF1_FK on Directorate (
ContactID ASC
)
go

/*==============================================================*/
/* Table: GovOfficeRegion                                       */
/*==============================================================*/
create table GovOfficeRegion (
   GovOfficeRegionID    int                  not null,
   CountyID             int                  null,
   GovOfficeRegionName  varchar(200)         null,
   GovOfficeRegionIsActive bit                  null,
   GovOfficeRegionShortDescription text                 null,
   constraint PK_GOVOFFICEREGION primary key nonclustered (GovOfficeRegionID)
)
go

/*==============================================================*/
/* Index: OF_FK                                                 */
/*==============================================================*/
create index OF_FK on GovOfficeRegion (
CountyID ASC
)
go

/*==============================================================*/
/* Table: Organisation                                          */
/*==============================================================*/
create table Organisation (
   OrgID                int                  not null,
   ContactID            int                  null,
   OrgName              text                 not null,
   OrganisationPreferred bit                  null,
   OrganisationExpressionOfInterest bit                  null,
   OrganisationAddressLine1 text                 not null,
   OrganisationAddressLine2 text                 null,
   OrganisationAddressLine3 text                 null,
   OrganisationPremiseNumber numeric              null,
   OrganisationFax      numeric              null,
   OrganisationEmail    text                 null,
   OrganisationWebAddress text                 null,
   OrganisationCharityNumber numeric              null,
   OrganisationCompanyNumber numeric              null,
   OrganisationPostode  varchar(100)         not null,
   OrganisationCityTown text                 null,
   OrganisationNationCountry text                 null,
   OrganisationCounty   text                 null,
   OrganisationShortDescription text                 not null,
   OrganisationFullDescription text                 null,
   constraint PK_ORGANISATION primary key nonclustered (OrgID)
)
go

/*==============================================================*/
/* Index: OF2_FK                                                */
/*==============================================================*/
create index OF2_FK on Organisation (
ContactID ASC
)
go

/*==============================================================*/
/* Table: OrganisationProgramme                                 */
/*==============================================================*/
create table OrganisationProgramme (
   OrgID                int                  not null,
   ProgrammeID          int                  not null,
   constraint PK_ORGANISATIONPROGRAMME primary key (OrgID, ProgrammeID)
)
go

/*==============================================================*/
/* Index: ORGANISATIONPROGRAMME_FK                              */
/*==============================================================*/
create index ORGANISATIONPROGRAMME_FK on OrganisationProgramme (
OrgID ASC
)
go

/*==============================================================*/
/* Index: ORGANISATIONPROGRAMME2_FK                             */
/*==============================================================*/
create index ORGANISATIONPROGRAMME2_FK on OrganisationProgramme (
ProgrammeID ASC
)
go

/*==============================================================*/
/* Table: Premise                                               */
/*==============================================================*/
create table Premise (
   PremiseID            int                  not null,
   ServiceID            int                  null,
   PremiseName          varchar(100)         null,
   PrimaryLocation      text                 null,
   PremisePhoneNumber   char(20)             null,
   PremiseAddress       text                 null,
   constraint PK_PREMISE primary key nonclustered (PremiseID)
)
go

/*==============================================================*/
/* Index: IN2_FK                                                */
/*==============================================================*/
create index IN2_FK on Premise (
ServiceID ASC
)
go

/*==============================================================*/
/* Table: Programme                                             */
/*==============================================================*/
create table Programme (
   ProgrammeID          int                  not null,
   ContactID            int                  null,
   ProgrammeName        varchar(100)         null,
   ProgrammeDescription text                 null,
   constraint PK_PROGRAMME primary key nonclustered (ProgrammeID)
)
go

/*==============================================================*/
/* Index: OF4_FK                                                */
/*==============================================================*/
create index OF4_FK on Programme (
ContactID ASC
)
go

/*==============================================================*/
/* Table: ReferenceData                                         */
/*==============================================================*/
create table ReferenceData (
   RefID                int                  not null,
   RefCode              varchar(100)         null,
   RefValue             varchar(100)         null,
   constraint PK_REFERENCEDATA primary key nonclustered (RefID)
)
go

/*==============================================================*/
/* Table: Service                                               */
/*==============================================================*/
create table Service (
   ServiceID            int                  not null,
   ServiceName          varchar(100)         null,
   ServiceActive        text                 null,
   ShortDescription     text                 null,
   DeptCode             char(10)             null,
   ClientDescription    text                 null,
   DeliveryDescription  text                 null,
   Attendance           varchar(100)         null,
   StartExpected        datetime             null,
   StartDate            datetime             null,
   EndDate              datetime             null,
   Extendable           bit                  null,
   ExtendableYears      int                  null,
   ExtendableMonths     int                  null,
   ContractCode         char(10)             null,
   ContractValue        varchar(100)         null,
   StagedPayment        bit                  null,
   ReferalProcessMethod varchar(100)         null,
   TimeLimited          bit                  null,
   TimeLimitedYears     int                  null,
   TimeLimitedMonths    int                  null
      constraint CKC_TIMELIMITEDMONTHS_SERVICE check (TimeLimitedMonths is null or (TimeLimitedMonths between 1 and 12)),
   constraint PK_SERVICE primary key nonclustered (ServiceID)
)
go

/*==============================================================*/
/* Table: ServiceOrganisation                                   */
/*==============================================================*/
create table ServiceOrganisation (
   ServiceID            int                  not null,
   OrgID                int                  not null,
   constraint PK_SERVICEORGANISATION primary key (ServiceID, OrgID)
)
go

/*==============================================================*/
/* Index: SERVICEORGANISATION_FK                                */
/*==============================================================*/
create index SERVICEORGANISATION_FK on ServiceOrganisation (
ServiceID ASC
)
go

/*==============================================================*/
/* Index: SERVICEORGANISATION2_FK                               */
/*==============================================================*/
create index SERVICEORGANISATION2_FK on ServiceOrganisation (
OrgID ASC
)
go

/*==============================================================*/
/* Table: SupportingMaterial                                    */
/*==============================================================*/
create table SupportingMaterial (
   SupportingMaterialID int                  not null,
   UserID               int                  null,
   OrgID                int                  null,
   URL                  text                 null,
   Type                 varchar(100)         null,
   AddedDate            datetime             null,
   SupportingMaterialDescription text                 null,
   constraint PK_SUPPORTINGMATERIAL primary key nonclustered (SupportingMaterialID)
)
go

/*==============================================================*/
/* Index: USE1_FK                                               */
/*==============================================================*/
create index USE1_FK on SupportingMaterial (
UserID ASC
)
go

/*==============================================================*/
/* Index: USE2_FK                                               */
/*==============================================================*/
create index USE2_FK on SupportingMaterial (
OrgID ASC
)
go

/*==============================================================*/
/* Table: Team                                                  */
/*==============================================================*/
create table Team (
   TeamID               int                  not null,
   DepartmentID         int                  null,
   ContactID            int                  null,
   TeamName             varchar(100)         null,
   TeamAddressLine1     text                 null,
   TeamAddressLine2     text                 null,
   TeamAddressLine3     text                 null,
   TeamCountry          text                 null,
   TeamPostcode         int                  null,
   TeamShortDescription text                 null,
   TeamFullDescription  text                 null,
   TeamCounty           text                 null,
   TeamFax              char(20)             null,
   TeamEmail            text                 null,
   TeamWebAddress       text                 null,
   TeamNationCountry    text                 null,
   TeamTownVillageCity  text                 null,
   TeamPremiseNumber    numeric              null,
   constraint PK_TEAM primary key nonclustered (TeamID)
)
go

/*==============================================================*/
/* Index: OF3_FK                                                */
/*==============================================================*/
create index OF3_FK on Team (
ContactID ASC
)
go

/*==============================================================*/
/* Index: HAVE4_FK                                              */
/*==============================================================*/
create index HAVE4_FK on Team (
DepartmentID ASC
)
go

/*==============================================================*/
/* Table: Town                                                  */
/*==============================================================*/
create table Town (
   TownID               int                  not null,
   CountyID             int                  not null,
   TownName             text                 null,
   constraint PK_TOWN primary key nonclustered (TownID)
)
go

/*==============================================================*/
/* Index: IN4_FK                                                */
/*==============================================================*/
create index IN4_FK on Town (
CountyID ASC
)
go

/*==============================================================*/
/* Table: TrustDistrict                                         */
/*==============================================================*/
create table TrustDistrict (
   TrustDistrictID      int                  not null,
   TrustRegionID        int                  null,
   TrustDistrictName    varchar(100)         null,
   TrustDistrictShortDescription text                 null,
   TrustDistrictIsActive bit                  null,
   constraint PK_TRUSTDISTRICT primary key nonclustered (TrustDistrictID)
)
go

/*==============================================================*/
/* Index: IN_FK                                                 */
/*==============================================================*/
create index IN_FK on TrustDistrict (
TrustRegionID ASC
)
go

/*==============================================================*/
/* Table: TrustRegion                                           */
/*==============================================================*/
create table TrustRegion (
   TrustRegionID        int                  not null,
   CountryID            int                  null,
   TrustRegionName      varchar(100)         null,
   TrustRegionIsActive  bit                  null,
   TrustRegionShortDescription text                 null,
   constraint PK_TRUSTREGION primary key nonclustered (TrustRegionID)
)
go

/*==============================================================*/
/* Index: INCLUDE_FK                                            */
/*==============================================================*/
create index INCLUDE_FK on TrustRegion (
CountryID ASC
)
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   UserID               int                  not null,
   Account              varchar(100)         null,
   Role                 varchar(100)         null,
   Password             varchar(100)         null,
   UserEmail            text                 null,
   constraint PK_USER primary key nonclustered (UserID)
)
go

alter table Address
   add constraint FK_ADDRESS_IN3_TOWN foreign key (TownID)
      references Town (TownID)
go

alter table Contact
   add constraint FK_CONTACT_MANAGER_CONTACT foreign key (ManagerID)
      references Contact (ContactID)
go

alter table County
   add constraint FK_COUNTY_IS_COUNTRY foreign key (CountryID)
      references Country (CountryID)
go

alter table Department
   add constraint FK_DEPARTME_HAVE_CONTACT foreign key (ContactID)
      references Contact (ContactID)
go

alter table Department
   add constraint FK_DEPARTME_HAVE3_DIRECTOR foreign key (DirectorateID)
      references Directorate (DirectorateID)
go

alter table Directorate
   add constraint FK_DIRECTOR_HAVE2_ORGANISA foreign key (OrgID)
      references Organisation (OrgID)
go

alter table Directorate
   add constraint FK_DIRECTOR_OF1_CONTACT foreign key (ContactID)
      references Contact (ContactID)
go

alter table GovOfficeRegion
   add constraint FK_GOVOFFIC_OF_COUNTY foreign key (CountyID)
      references County (CountyID)
go

alter table Organisation
   add constraint FK_ORGANISA_OF2_CONTACT foreign key (ContactID)
      references Contact (ContactID)
go

alter table OrganisationProgramme
   add constraint FK_ORGANISA_ORGANISAT_ORGANISA foreign key (OrgID)
      references Organisation (OrgID)
go

alter table OrganisationProgramme
   add constraint FK_ORGANISA_ORGANISAT_PROGRAMM foreign key (ProgrammeID)
      references Programme (ProgrammeID)
go

alter table Premise
   add constraint FK_PREMISE_IN2_SERVICE foreign key (ServiceID)
      references Service (ServiceID)
go

alter table Programme
   add constraint FK_PROGRAMM_OF4_CONTACT foreign key (ContactID)
      references Contact (ContactID)
go

alter table ServiceOrganisation
   add constraint FK_SERVICEO_SERVICEOR_SERVICE foreign key (ServiceID)
      references Service (ServiceID)
go

alter table ServiceOrganisation
   add constraint FK_SERVICEO_SERVICEOR_ORGANISA foreign key (OrgID)
      references Organisation (OrgID)
go

alter table SupportingMaterial
   add constraint FK_SUPPORTI_USE1_USER foreign key (UserID)
      references "User" (UserID)
go

alter table SupportingMaterial
   add constraint FK_SUPPORTI_USE2_ORGANISA foreign key (OrgID)
      references Organisation (OrgID)
go

alter table Team
   add constraint FK_TEAM_HAVE4_DEPARTME foreign key (DepartmentID)
      references Department (DepartmentID)
go

alter table Team
   add constraint FK_TEAM_OF3_CONTACT foreign key (ContactID)
      references Contact (ContactID)
go

alter table Town
   add constraint FK_TOWN_IN4_COUNTY foreign key (CountyID)
      references County (CountyID)
go

alter table TrustDistrict
   add constraint FK_TRUSTDIS_IN_TRUSTREG foreign key (TrustRegionID)
      references TrustRegion (TrustRegionID)
go

alter table TrustRegion
   add constraint FK_TRUSTREG_INCLUDE_COUNTRY foreign key (CountryID)
      references Country (CountryID)
go
