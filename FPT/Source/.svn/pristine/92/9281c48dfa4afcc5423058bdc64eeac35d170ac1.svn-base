
/* Phung Duy Luong - 12520250@gm.uit.edu.vn */

USE [CSS]

GO
INSERT INTO [dbo].[Company]([Name],[Type],[Status],[Sector],[PhoneNumber],[FaxNumber],[Emailaddress],[CreatedDate],[CreatedBy],[AMISCode],[BusinessArea])
     VALUES('Ga con FC','Football club',1,'Soccer','0123456789',NULL,'gaconfc@gmail.com','08/19/1993',N'Mr. Gà','AMISCODE001',120)
INSERT INTO [dbo].[Company]([Name],[Type],[Status],[Sector],[PhoneNumber],[FaxNumber],[Emailaddress],[CreatedDate],[CreatedBy],[AMISCode],[BusinessArea])
     VALUES('Manutd FC','Football club',1,'Soccer','0223456789',NULL,'manutdfc@gmail.com','08/19/1993',N'Mr. Gà','AMISCODE002',160)
INSERT INTO [dbo].[Company]([Name],[Type],[Status],[Sector],[PhoneNumber],[FaxNumber],[Emailaddress],[CreatedDate],[CreatedBy],[AMISCode],[BusinessArea])
     VALUES('KFC HCM','Fast food store',1,'Food','0323456789',NULL,'kfc_hcm@gmail.com','08/19/1993',N'Mr. Gà','AMISCODE003',220)
INSERT INTO [dbo].[Company]([Name],[Type],[Status],[Sector],[PhoneNumber],[FaxNumber],[Emailaddress],[CreatedDate],[CreatedBy],[AMISCode],[BusinessArea])
     VALUES('Xuyen Viet coporate','Traveling',1,'Entertainment','0423456789',NULL,'xuyenviet@gmail.com','08/19/1993',N'Mr. Gà','AMISCODE004',80)
INSERT INTO [dbo].[Company]([Name],[Type],[Status],[Sector],[PhoneNumber],[FaxNumber],[Emailaddress],[CreatedDate],[CreatedBy],[AMISCode],[BusinessArea])
     VALUES('Big C Cong Hoa','Super market',1,'Grocery','0523456789',NULL,'bigcconghoa@gmail.com','08/19/1993',N'Mr. Gà','AMISCODE005',50)

GO
INSERT INTO [dbo].[Region]([RegionName]) VALUES('Western')
INSERT INTO [dbo].[Region]([RegionName]) VALUES('Eastern')
INSERT INTO [dbo].[Region]([RegionName]) VALUES('Northern')
INSERT INTO [dbo].[Region]([RegionName]) VALUES('Southern')

GO
INSERT INTO [dbo].[CompanyAddress]([Address1],[Address2],[Address3],[Address4],[Address5],[City],[State],[Country],[RegionId],[Postcode],[CompanyId])
     VALUES('79','Hung Vuong', 'TT. Easup', 'Easup', NULL, 'Dak Lak', NULL, 'Viet Nam',4,'ABC XZY01',1)
INSERT INTO [dbo].[CompanyAddress]([Address1],[Address2],[Address3],[Address4],[Address5],[City],[State],[Country],[RegionId],[Postcode],[CompanyId])
     VALUES('19','Hung Vuong', 'P.12', 'Go Vap', NULL, 'HCM', NULL, 'Viet Nam',4,'ABC XZY02',2)
INSERT INTO [dbo].[CompanyAddress]([Address1],[Address2],[Address3],[Address4],[Address5],[City],[State],[Country],[RegionId],[Postcode],[CompanyId])
     VALUES('79','Hung Vuong', 'P.1', 'Thanh Xuan', NULL, 'Ha Noi', NULL, 'Viet Nam',3,'ABC XZY03',3)
INSERT INTO [dbo].[CompanyAddress]([Address1],[Address2],[Address3],[Address4],[Address5],[City],[State],[Country],[RegionId],[Postcode],[CompanyId])
     VALUES('79','Hung Vuong', 'P.3', 'Pleiku', NULL, 'Gia Lai', NULL, 'Viet Nam',1,'ABC XZY04',4)
INSERT INTO [dbo].[CompanyAddress]([Address1],[Address2],[Address3],[Address4],[Address5],[City],[State],[Country],[RegionId],[Postcode],[CompanyId])
     VALUES('79','Hung Vuong', 'P.5', 'Truong Sa', NULL, 'Da Nang', NULL, 'Viet Nam',2,'ABC XZY05',5)

GO
INSERT INTO [dbo].[RFONumber]([RFOName],[CustomerTypeId],[CompanyId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy],[PostCode])
     VALUES('Ga Con FC',1,1,'08/24/2015','Mr. Gà', '08/24/2015', 'Mr. Gà', 'ABC XYZ01')
INSERT INTO [dbo].[RFONumber]([RFOName],[CustomerTypeId],[CompanyId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy],[PostCode])
     VALUES('Manutd FC',1,2,'08/24/2015','Mr. Gà', '08/24/2015', 'Mr. Gà', 'ABC XYZ02')
INSERT INTO [dbo].[RFONumber]([RFOName],[CustomerTypeId],[CompanyId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy],[PostCode])
     VALUES('KFC HCM',1,3,'08/24/2015','Mr. Gà', '08/24/2015', 'Mr. Gà', 'ABC XYZ03')
INSERT INTO [dbo].[RFONumber]([RFOName],[CustomerTypeId],[CompanyId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy],[PostCode])
     VALUES('Xuyen Viet coporate',1,4,'08/24/2015','Mr. Gà', '08/24/2015', 'Mr. Gà', 'ABC XYZ04')
INSERT INTO [dbo].[RFONumber]([RFOName],[CustomerTypeId],[CompanyId],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy],[PostCode])
     VALUES('Big C Cong Hoa',1,5,'08/24/2015','Mr. Gà', '08/24/2015', 'Mr. Gà', 'ABC XYZ05')

GO
INSERT INTO [dbo].[FundingMethod]([FundingMethodName],[FundingType],[BudgetCode],[CostCentre],[ContractTemplateLocation],[SignedContractDefault]
           ,[Status],[AMISDeptCode],[AMISReasonCode])
     VALUES('Fleet', 'End user', 'CHA', 'HCMB', 'G:\Wip\Documents\Q&A', 'Yes(Enable)','Active','ABCXYZ01', 'ABCXYZ02')
INSERT INTO [dbo].[FundingMethod]([FundingMethodName],[FundingType],[BudgetCode],[CostCentre],[ContractTemplateLocation],[SignedContractDefault]
           ,[Status],[AMISDeptCode],[AMISReasonCode])
     VALUES('Leasing', 'Leasing', 'CHA', 'HNC', 'G:\Wip\Documents\Q&A', 'Yes(Enable)','Active','ABCXYZ01', 'ABCXYZ02')
INSERT INTO [dbo].[FundingMethod]([FundingMethodName],[FundingType],[BudgetCode],[CostCentre],[ContractTemplateLocation],[SignedContractDefault]
           ,[Status],[AMISDeptCode],[AMISReasonCode])
     VALUES('Motability', 'End user', 'CK', 'LDC', 'G:\Wip\Documents\Q&A', 'Yes(Enable)','Active','ABCXYZ01', 'ABCXYZ02')

GO
INSERT INTO [dbo].[AgendaPayment]([AgendaPayment]) VALUES('Count & Earn')
INSERT INTO [dbo].[AgendaPayment]([AgendaPayment]) VALUES('Count & Not Earn')
INSERT INTO [dbo].[AgendaPayment]([AgendaPayment]) VALUES('Neither Count or Earn')

GO
INSERT INTO [dbo].[RFOUser]([ManagerId],[Title],[FirstName],[LastName],[ExtranetUser],[EmailAddress],[UserTypeId],[Status],[TargetNumberOfRegistrations])
     VALUES(NULL,'Westgate Honda','NA', 'NA','NA','westgatehonda@gmail.com',2,'Business motorcylce of Honda',100)
INSERT INTO [dbo].[RFOUser]([ManagerId],[Title],[FirstName],[LastName],[ExtranetUser],[EmailAddress],[UserTypeId],[Status],[TargetNumberOfRegistrations])
     VALUES(NULL,'Ryland Honda','NA', 'NA','NA','rylandhonda@gmail.com',2,'Business car of Honda',120)
INSERT INTO [dbo].[RFOUser]([ManagerId],[Title],[FirstName],[LastName],[ExtranetUser],[EmailAddress],[UserTypeId],[Status],[TargetNumberOfRegistrations])
     VALUES(NULL,'Yeomans Honda','NA', 'NA','NA','yeomanshonda@gmail.com',2,'Business container of Honda',200)
INSERT INTO [dbo].[RFOUser]([ManagerId],[Title],[FirstName],[LastName],[ExtranetUser],[EmailAddress],[UserTypeId],[Status],[TargetNumberOfRegistrations])
     VALUES(NULL,'Yeomans Honda','NA', 'NA','NA','yeomanshonda@gmail.com',2,'Business motorcylce of Honda',300)
INSERT INTO [dbo].[RFOUser]([ManagerId],[Title],[FirstName],[LastName],[ExtranetUser],[EmailAddress],[UserTypeId],[Status],[TargetNumberOfRegistrations])
     VALUES(NULL,'Yeomans Honda','NA', 'NA','NA','yeomanshonda@gmail.com',2,'Business car of Honda',50)

GO
INSERT INTO [dbo].[ContactAddress]([UserId],[Town],[County],[City],[Country],[Postcode],[MobileNo],[OfficeNo]
           ,[FaxNo],[Address1],[Address2],[Address3],[Address4],[Address5])
     VALUES(1,'Grimsby','North East Lincolshire','Ha Noi','Viet Nam','ABC XYZ01','0123654789', NULL
			,NULL,NULL,NULL,NULL,NULL,NULL)
INSERT INTO [dbo].[ContactAddress]([UserId],[Town],[County],[City],[Country],[Postcode],[MobileNo],[OfficeNo]
           ,[FaxNo],[Address1],[Address2],[Address3],[Address4],[Address5])
     VALUES(2,'Cardiff','Thu Duc','Ho Chi Minh','Viet Nam','ABC XYZ02','0123657789', NULL
			,NULL,NULL,NULL,NULL,NULL,NULL)
INSERT INTO [dbo].[ContactAddress]([UserId],[Town],[County],[City],[Country],[Postcode],[MobileNo],[OfficeNo]
           ,[FaxNo],[Address1],[Address2],[Address3],[Address4],[Address5])
     VALUES(3,'Bognor Regis','West Sussex','Ha Noi','Viet Nam','ABC XYZ03','01236584789', NULL
			,NULL,NULL,NULL,NULL,NULL,NULL)
INSERT INTO [dbo].[ContactAddress]([UserId],[Town],[County],[City],[Country],[Postcode],[MobileNo],[OfficeNo]
           ,[FaxNo],[Address1],[Address2],[Address3],[Address4],[Address5])
     VALUES(4,'Franham','Surrey','Ha Noi','Viet Nam','ABC XYZ04','0193654789', NULL
			,NULL,NULL,NULL,NULL,NULL,NULL)
INSERT INTO [dbo].[ContactAddress]([UserId],[Town],[County],[City],[Country],[Postcode],[MobileNo],[OfficeNo]
           ,[FaxNo],[Address1],[Address2],[Address3],[Address4],[Address5])
     VALUES(5,'Littlehampton','West Sussex','Hue','Viet Nam','ABC XYZ05','0126654789', NULL
			,NULL,NULL,NULL,NULL,NULL,NULL)










