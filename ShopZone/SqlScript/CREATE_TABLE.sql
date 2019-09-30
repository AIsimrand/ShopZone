--ShopzoneTest@gmail.com/Shopzone123

Use ShopZone;




Create Table Role
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);

GO


INSERT INTO ROLE 
Select 'Admin', 'Admin Role', 1, 0, 0, GETDATE(), NULL, NULL

GO

INSERT INTO ROLE 
Select 'User', 'User Role', 1, 0, 0, GETDATE(), NULL, NULL

GO





Create Table LoginUser
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
RoleId int not null,
EmailId nvarchar(500) NOT NULL,
Password nvarchar(200) NOT NULL,
SecurityQuestion nvarchar(MAX) NOT NULL,
SecurityAnswer nvarchar(MAX) NOT NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);
GO

INSERT INTO LoginUser 
Select 1, 'admin','admin','Your username', 'admin', 1, 0, 0, GETDATE(), NULL, NULL

GO



Create Table Category
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
ParentId int NULL,
IsTopBrand bit NOT NULL  DEFAULT(0),
IsActive bit NOT NULL  DEFAULT(1),
IsDeleted bit NOT NULL  DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);

GO

INSERT INTO Category 
Select 'Watch','Watch',NULL,1,1, 0, 1, GETDATE(), NULL, NULL
UNION
Select 'Footwear','Footwear',NULL,1,1, 0, 1, GETDATE(), NULL, NULL
UNION
Select 'Cloth','Cloth',NULL,1, 1,0, 1, GETDATE(), NULL, NULL

GO

INSERT INTO Category 
Select 'Rado','Rado',1,1, 1,0, 1, GETDATE(), NULL, NULL
UNION
Select 'Casio','Casio',1,1,1, 0, 1, GETDATE(), NULL, NULL
UNION
Select 'Adidas','Adidas',2,1,1, 0, 1, GETDATE(), NULL, NULL
UNION
Select 'Nike','Nike',2,1,1, 0, 1, GETDATE(), NULL, NULL

GO

Create Table Product
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CategoryId int NOT NULL,
SubCategoryId int NOT NULL,
Name nvarchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
Price decimal(20,2) NOT NULL default(0),
NoOfStock int NOT NULL default(0),
HasOffer bit NOT NULL DEFAULT(0),
IsFeaturedProduct bit NOT NULL DEFAULT(0),
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);
GO

--INSERT INTO Product 
--Select 1,'Product 1','Product 1','100.00',1,1, 0, 1, GETDATE(), NULL, NULL
--UNION
--Select 2,'Product 2','Product 2','100.00',1,1, 0, 1, GETDATE(), NULL, NULL
--UNION
--Select 1,'Product 3','Product 3','100.00',0,1, 0, 1, GETDATE(), NULL, NULL
--UNION
--Select 3,'Product 4','Product 4','100.00',0,1, 0, 1, GETDATE(), NULL, NULL


GO

Create Table Coupon
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
CouponCode nvarchar(10) NOT NULL,
Discount DECIMAL(10,2) NOT NULL default(0),
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);
GO





Create Table Customer
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserId int NOT NULL,
FirstName nvarchar(200) NULL,
LastName nvarchar(200) NULL,
Address1 nvarchar(500) NULL,
Address2 nvarchar(500) NULL,
Address3 nvarchar(500) NULL,
City nvarchar(200) NULL,
Pincode nvarchar(50) NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL
);

GO

INSERT INTO Customer 
Select 1,'First Name','Last Name', 'Address 1', 'Address 2', 'Address 3', 'City', '400001',1, 0, 1, GETDATE(), NULL, NULL

GO






Create Table CustomerOrder
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CustomerId int not null,
ProductId int not null,
Unit int not null default(0),
UnitAmount decimal(20,2) NOT NULL default(0.00),
CouponCode  varchar(20) NULL,
Discount decimal(20,2) NOT NULL default(0.00),
AmountPaid decimal(20,2) NOT NULL default(0.00),
CartGUID varchar(200) NOT NULL,
PaymodeMode varchar(200) NOT NULL,
PaymentStatus varchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL

);

GO


Create Table OrderTracking
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CartGUID varchar(200) NOT NULL,
TransitStatus varchar(200) NOT NULL,
Description nvarchar(MAX) NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL

);

GO

Create Table Newsletter
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
EmailId varchar(500) not null,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL,
LastUpdatedBy int NULL ,
LastUpdatedOn datetime NULL

);

GO

Create Table Feedback
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200) NOT NULL,
Subject nvarchar(200) NULL,
Message nvarchar(MAX) NULL,
IsActive bit NOT NULL DEFAULT(1),
IsDeleted bit NOT NULL DEFAULT(0),
CreatedBy int NOT NULL DEFAULT(1),
CreatedOn datetime default(GETDATE()) NOT NULL
);

GO