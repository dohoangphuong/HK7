
/* Phung Duy Luong - 12520250@gm.uit.edu.vn */

/* Create new all table */

USE MASTER

GO
CREATE DATABASE [CSS]

GO
USE [CSS]

GO

CREATE TABLE [Company]
(
	[CompanyId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Type] NVARCHAR(100) NOT NULL,
	[Status] BIT NOT NULL, -- working or not
	[Sector] NVARCHAR(100) NULL,
	[PhoneNumber]  NVARCHAR(20) NULL,
	[FaxNumber] NVARCHAR(20) NULL,
	[Emailaddress] NVARCHAR(100) NOT NULL,
	[CreatedDate] DATE NOT NULL,
	[CreatedBy] NVARCHAR(50) NOT NULL,
	[AMISCode] NVARCHAR(50) NOT NULL,
	[BusinessArea] INT NOT NULL,

	CONSTRAINT PK_Company PRIMARY KEY ([CompanyId]),
)

CREATE TABLE [Region]
(
	[RegionId] INT IDENTITY(1,1) NOT NULL,
	[RegionName] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Region PRIMARY KEY ([RegionId]),
)

CREATE TABLE [CompanyAddress]
(
	[Address1] NVARCHAR(50) NULL,
	[Address2] NVARCHAR(50) NULL,
	[Address3] NVARCHAR(50) NULL,
	[Address4] NVARCHAR(50) NULL,
	[Address5] NVARCHAR(50) NULL,
	[City] NVARCHAR(50) NOT NULL,
	[State] NVARCHAR(50) NULL,
	[Country] NVARCHAR(50) NOT NULL,
	[RegionId] INT NOT NULL,
	[Postcode] NVARCHAR(50) NOT NULL,
	[CompanyId] INT NOT NULL,

	CONSTRAINT FK_CompanyAddress_Region FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Region] ([RegionId]),
	CONSTRAINT FK_CompanyAddress_Company FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company]([CompanyId]),
	CONSTRAINT PK_CompanyAddress PRIMARY KEY ([CompanyId]),
)

CREATE TABLE [CustomerType]
(
	[CustomerTypeId] INT IDENTITY(1,1) NOT NULL,
	[CustomerType] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_CustomerType PRIMARY KEY ([CustomerTypeId])
)

CREATE TABLE [RFONumber]
(
	[RFONumber] INT IDENTITY(1,1) NOT NULL,
	[RFOName] NVARCHAR(100) NOT NULL,
	[CustomerTypeId] INT NOT NULL,
	[CompanyId] INT NOT NULL,
	[CreatedDate] DATE NOT NULL,
	[CreatedBy] NVARCHAR(50) NOT NULL,
	[UpdatedDate] DATE NOT NULL,
	[UpdatedBy] NVARCHAR(50) NOT NULL,
	[PostCode] VARCHAR(10) NOT NULL,

	CONSTRAINT FK_RFONumber_CustomerTypeId FOREIGN KEY ([CustomerTypeid]) REFERENCES [dbo].[CustomerType]([CustomerTypeid]),
	CONSTRAINT FK_RFONumber_Company FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company]([CompanyId]),
	CONSTRAINT PK_RFONumber PRIMARY KEY ([RFONumber]),
)

CREATE TABLE [Volume]
(
	[VolumeId] INT IDENTITY(1,1) NOT NULL,
	[TriggerCredit] NVARCHAR(50) NULL,
	[PaymentTo] NVARCHAR(50) NULL,

	CONSTRAINT PK_Volume PRIMARY KEY ([VolumeId]),
)

CREATE TABLE [Banding]
(
	[BandingId] INT IDENTITY(1,1) NOT NULL,
	[VolumeId] INT NOT NULL,
	[Min] INT NOT NULL,
	[Max] INT NOT NULL,

	CONSTRAINT FK_Banding_Volume FOREIGN KEY ([VolumeId]) REFERENCES [dbo].[Volume] ([VolumeId]),
	CONSTRAINT PK_Banding PRIMARY KEY ([BandingId]),
)

CREATE TABLE [AgreementStatus]
(
	[StatusId] INT NOT NULL,
	[AgreementStatus] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_AgreementStatus PRIMARY KEY ([StatusId]),
)

CREATE TABLE [BudgetCode]
(
	[BudgetCode] CHAR(10) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
	[Status] NVARCHAR(100) NOT NULL,
	[Verified] DECIMAL NOT NULL, 

	CONSTRAINT PK_BudgetCode PRIMARY KEY ([BudgetCode]),
)

CREATE TABLE [CostCentre]
(
	[CostCentre] CHAR(10) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
	[Status] NVARCHAR(100) NOT NULL,
	[Verified] DECIMAL NOT NULL,

	CONSTRAINT PK_CostCentre PRIMARY KEY ([CostCentre]),
)

CREATE TABLE [FundingMethod]
(
	[FundingMethodId] INT IDENTITY(1,1) NOT NULL,
	[FundingMethodName] NVARCHAR(100) NOT NULL,
	[FundingType] NVARCHAR(100) NOT NULL,
	[BudgetCode] CHAR(10) NOT NULL,
	[CostCentre] CHAR(10) NOT NULL,
	[ContractTemplateLocation] NVARCHAR(50) NULL,
	[SignedContractDefault] NVARCHAR(50) NOT NULL,
	[Status] NVARCHAR(50) NOT NULL,
	[AMISDeptCode] NVARCHAR(50) NOT NULL,
	[AMISReasonCode] NVARCHAR(50) NOT NULL,

	CONSTRAINT FK_FundingMethod_BudgetCode FOREIGN KEY ([BudgetCode]) REFERENCES [dbo].[BudgetCode] ([BudgetCode]),
	CONSTRAINT FK_FundingMethod_CostCentre FOREIGN KEY ([CostCentre]) REFERENCES [dbo].[CostCentre] ([CostCentre]),
	CONSTRAINT PK_FundingMethod PRIMARY KEY ([FundingMethodId]),
)

CREATE TABLE [AgendaPayment]
(
	[AgendaPaymentId] INT IDENTITY(1,1) NOT NULL,
	[AgendaPayment] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_AgendaPayment PRIMARY KEY ([AgendaPaymentId]),
)

CREATE TABLE [Agreement]
(
	[AgreementNumber] INT NOT NULL,
	[VariantNumber] INT NOT NULL,
	[Name] NVARCHAR(100) NULL,
	[Description] NVARCHAR(1000) NULL,
	[StartDate] DATE NULL,
	[EndDate] DATE NULL,
	[StatusId] INT NOT NULL,
	[LastStatusUpdatedDate] DATE NOT NULL,
	[AuthorisedBy] NVARCHAR(50) NULL,
	[AuthorisedDate] DATE NULL,
	[CreatedDate] DATE NOT NULL,
	[CreatedBy] NVARCHAR(50) NOT NULL,
	[LastUpdatedBy] NVARCHAR(50) NOT NULL,
	[PaymentTo] NVARCHAR(50) NULL,
	[AMISAccountCode] NVARCHAR(10) NULL,
	[HandlingCharge] MONEY NULL,
	[FundingMethodId] INT NULL,
	[SignRequired] BIT NOT NULL,
	[SignReceived] BIT NOT NULL,
	[SignReceivedDate] DATE NULL,
	[DealerVisibility] NVARCHAR(50) NULL,
	[Combinability] NVARCHAR(50) NULL,
	[NumberOfRegistrations] INT NULL,
	[VolumeId] INT NULL,
	[DiscountUnit] NVARCHAR(10) NULL,
	[AgendaPaymentId] INT NULL,
	 
	CONSTRAINT FK_Agreement_AgendaPayment FOREIGN KEY ([AgendaPaymentId]) REFERENCES [dbo].[AgendaPayment] ([AgendaPaymentId]),
	CONSTRAINT FK_Agreement_AgreementStatus FOREIGN KEY ([StatusId]) REFERENCES [dbo].[AgreementStatus] ([StatusId]),
	CONSTRAINT FK_Agreement_FundingMethod FOREIGN KEY ([FundingMethodId]) REFERENCES [dbo].[FundingMethod] ([FundingMethodId]),
	CONSTRAINT FK_Agreement_Volume FOREIGN KEY ([VolumeId]) REFERENCES [dbo].[Volume] ([VolumeId]),

	CONSTRAINT PK_Agreement PRIMARY KEY ([AgreementNumber],[VariantNumber]),
)

CREATE TABLE [AgreementRFO]
(
	[AgreementNumber] INT NOT NULL,
	[VariantNumber] INT NOT NULL,
	[RFONumber] INT NOT NULL,

	CONSTRAINT FK_AgreementRFO_Agreement FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES [dbo].[Agreement] ([AgreementNumber],[VariantNumber]),
	CONSTRAINT FK_AgreementRFO_RFONumber FOREIGN KEY ([RFONumber]) REFERENCES [dbo].[RFONumber] ([RFONumber]),

	CONSTRAINT PK_AgreementRFO PRIMARY KEY ([AgreementNumber],[VariantNumber],[RFONumber]),
)

CREATE TABLE [UserType]
(
	[UserTypeId] INT IDENTITY(1,1) NOT NULL,
	[UserType] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_UserType PRIMARY KEY ([UserTypeId]),
)

CREATE TABLE [PostCode]
(
	[PostCodeId] INT IDENTITY (1,1) NOT NULL,
	[PostCode] NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_PostCode PRIMARY KEY ([PostCodeId]),
)

CREATE TABLE [RFOUser]
(
	[UserId] INT IDENTITY(1,1) NOT NULL,
	[ManagerId] INT NULL,
	[Title] NVARCHAR(50) NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[ExtranetUser] NVARCHAR(50) NOT NULL,
	[EmailAddress] VARCHAR(50) NOT NULL,
	[UserTypeId] INT NOT NULL,
	[Status] VARCHAR(50) NULL,
	[TargetNumberOfRegistrations] INT NOT NULL,

	CONSTRAINT FK_RFOUser_UserType FOREIGN KEY ([UserTypeId]) REFERENCES [dbo].[UserType] ([UserTypeId]),
	CONSTRAINT FK_RFOUser_Manager FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[RFOUser] ([UserId]),
	CONSTRAINT PK_RFOUser PRIMARY KEY ([UserId]),
)

CREATE TABLE [PostCodeCovered]
(
	[UserId] INT NOT NULL,
	[PostCodeId] INT NOT NULL,

	CONSTRAINT FK_PostCodeCovered_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[RFOUser] ([UserId]),
	CONSTRAINT FK_PostCodeCovered_PostCode FOREIGN KEY ([PostCodeId]) REFERENCES [dbo].[PostCode] ([PostCodeId]),

	CONSTRAINT PK_PostCodeCovered PRIMARY KEY ([UserId],[PostCodeId]),
)

CREATE TABLE [CommentType]
(
	[CommentTypeId] INT NOT NULL,
	[CommentType] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_CommentType PRIMARY KEY ([CommentTypeId]),
)

CREATE TABLE [Comment]
(
	[CommentId] INT IDENTITY(1,1) NOT NULL,
	[AgreementNumber] INT NOT NULL,
	[VariantNumber] INT NOT NULL,
	[UserId] INT NOT NULL,
	[DateTime] DATETIME NOT NULL,
	[Comment] NVARCHAR(1000) NOT NULL,
	[CommentTypeId] INT NOT NULL,

	CONSTRAINT FK_Comment_Agreement FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES [dbo].[Agreement]([AgreementNumber],[VariantNumber]),
	CONSTRAINT FK_Comment_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[RFOUser]([UserId]),
	CONSTRAINT FK_Comment_CommentType FOREIGN KEY ([CommentTypeId]) REFERENCES [dbo].[CommentType]([CommentTypeId]),

	CONSTRAINT PK_Comment PRIMARY KEY ([CommentId]),
)

CREATE TABLE [CreditNoteText]
(
	[CreditNoteTextId] INT IDENTITY(1,1) NOT NULL,
	[AgreementNumber] INT NOT NULL,
	[VariantNumber] INT NOT NULL,
	[DateTime] DATETIME NOT NULL,
	[CreditNoteText] NVARCHAR(max) NOT NULL,

	CONSTRAINT FK_CreditNoteText_Agreement FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES [dbo].[Agreement]([AgreementNumber],[VariantNumber]),
	CONSTRAINT PK_CreditNoteText PRIMARY KEY ([CreditNoteTextId]),
)

CREATE TABLE [ContactAddress]
(
	[ContactAddressId] INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[Town] NVARCHAR(50),
	[County] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[Country] NVARCHAR(50) NOT NULL,
	[Postcode] CHAR(10) NOT NULL,
	[MobileNo] VARCHAR(20) NULL,
	[OfficeNo] VARCHAR(20) NULL,
	[FaxNo] VARCHAR(20) NULL,
	[Address1] NVARCHAR(50) NULL,
	[Address2] NVARCHAR(50) NULL,
	[Address3] NVARCHAR(50) NULL,
	[Address4] NVARCHAR(50) NULL,
	[Address5] NVARCHAR(50) NULL,

	CONSTRAINT FK_ContactAddress_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[RFOUser] ([UserId]),
	CONSTRAINT PK_ContactAddress PRIMARY KEY ([ContactAddressId]),
)

CREATE TABLE [AgreementDealer]
(
	[AgreementNumber] INT NOT NULL,
	[VariantNumber] INT NOT NULL,
	[DealerCode] INT NOT NULL,

	CONSTRAINT FK_AgreementDealer_Agreement FOREIGN KEY ([AgreementNumber],[VariantNumber]) REFERENCES [dbo].[Agreement]([AgreementNumber],[VariantNumber]),
	CONSTRAINT FK_AgreementDealer_DealerCode FOREIGN KEY ([DealerCode]) REFERENCES [dbo].[RFOUser] ([UserId]),
	CONSTRAINT PK_AgreementDealer PRIMARY KEY ([AgreementNumber],[VariantNumber],[DealerCode]),
)

CREATE TABLE [Account]
(
	[UserName] VARCHAR(20) NOT NULL,
	[UserId] INT NOT NULL,
	[Password] NCHAR(32) NOT NULL, --32 character in MD5 code

	CONSTRAINT FK_Account_User FOREIGN KEY ([UserId]) REFERENCES [dbo].[RFOUser] ([UserId]),
	CONSTRAINT PK_Account PRIMARY KEY ([UserName]),
)

CREATE TABLE [SystemConfig]
(
	[SystemConfigId] INT NOT NULL,
	[ConfigName] NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_SystemConfig PRIMARY KEY ([SystemConfigId]),
)

CREATE TABLE [SystemConfigValue]
(
	[SystemConfigValueId] INT IDENTITY(1,1) NOT NULL,
	[SystemConfigId] INT NOT NULL,
	[ConfigValue] NVARCHAR(100) NOT NULL,
	[Order] INT NOT NULL,

	CONSTRAINT FK_SystemConfigValue_SystemConfig FOREIGN KEY ([SystemConfigId]) REFERENCES [dbo].[SystemConfig]([SystemConfigId]),
	CONSTRAINT PK_SystemConfigValue PRIMARY KEY ([SystemConfigValueId]),
)


/* Create trigger */
GO
CREATE TRIGGER [CreateAgreementTrigger] ON [dbo].[Agreement]
FOR INSERT
AS
	BEGIN
		UPDATE [dbo].[SystemConfigValue]
		SET [Order] = [Order] + 1
		WHERE [SystemConfigId] = 18
	END

GO
CREATE TRIGGER [CreateVolumeTrigger] ON [dbo].[Volume]
FOR INSERT
AS
	BEGIN
		UPDATE [dbo].[SystemConfigValue]
		SET [Order] = [Order] + 1
		WHERE [SystemConfigId] = 19
	END

GO
CREATE TRIGGER [CreateBandingTrigger] ON [dbo].[Banding]
FOR INSERT
AS
	BEGIN
		UPDATE [dbo].[SystemConfigValue]
		SET [Order] = [Order] + 1
		WHERE [SystemConfigId] = 20
	END

GO
CREATE TRIGGER [CreateCommentTrigger] ON [dbo].[Comment]
FOR INSERT
AS
	BEGIN
		UPDATE [dbo].[SystemConfigValue]
		SET [Order] = [Order] + 1
		WHERE [SystemConfigId] = 21
	END

GO
CREATE TRIGGER [CreateCreditNoteTextTrigger] ON [dbo].[CreditNoteText]
FOR INSERT
AS
	BEGIN
		UPDATE [dbo].[SystemConfigValue]
		SET [Order] = [Order] + 1
		WHERE [SystemConfigId] = 22
	END
