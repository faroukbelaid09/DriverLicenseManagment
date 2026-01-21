-- Get users without password
CREATE PROCEDURE GetUsers
AS
BEGIN
    SELECT Users.UserID, Users.PersonID, UserName, FullName = People.FirstName+People.LastName, Users.IsActive
    FROM Users
    inner JOIN People ON Users.PersonID = People.PersonID
END

-- Get User By ID
CREATE PROCEDURE GetUserById
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        UserID,
        Users.PersonID,
        UserName,
        FullName = People.FirstName+People.LastName,
        IsActive
    FROM Users inner JOIN People ON Users.PersonID = People.PersonID
    WHERE UserID = @UserID;
END

-- Get user for authentication
CREATE PROCEDURE GetUserForAuthentication
    @UserName NVARCHAR(100)
AS
BEGIN
    SELECT UserID, Users.PersonID, UserName, Password, IsActive,FullName = People.FirstName+People.LastName
    FROM Users inner JOIN People ON Users.PersonID = People.PersonID
    WHERE UserName = @UserName
END

-- Add user
CREATE PROCEDURE AddUser
    @PersonID int,
    @UserName varchar(100),
    @Password varchar(255),
    @IsActive bit

As
Begin
    SET NOCOUNT ON;

    Insert into Users (PersonID, UserName, Password, IsActive)
                            Values(@PersonID, @UserName, @Password, @IsActive);
    
    SELECT SCOPE_IDENTITY() AS UserID;
End

CREATE PROCEDURE UserNameExists
    @UserName NVARCHAR(100)
As
Begin

    SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM Users WHERE UserName = @UserName)
        SELECT 1 AS [Exists]  -- Returns 1 if exists
    ELSE
        SELECT 0 AS [Exists]  -- Returns 0 if not exists

End

-- update user
CREATE PROCEDURE UpdateUser
    @UserID INT,
    @UserName VARCHAR(100),
    @IsActive BIT
AS
BEGIN
    UPDATE Users 
    SET UserName = @UserName, 
        IsActive = @IsActive
    WHERE UserID = @UserID;
    
    SELECT @@ROWCOUNT AS RowsAffected;
END


CREATE PROCEDURE DeleteUser
    @UserID int
As
Begin
    Delete from Users where UserID = @UserID;

    SELECT @@ROWCOUNT AS RowsAffected;
End

------ People ------

-- Get Person By ID
CREATE PROCEDURE GetPersonById
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    select People.*,Countries.CountryName from People 
    inner join Countries on People.NationalityCountryID = Countries.CountryID 
    where People.PersonID = @PersonID
END

-- Get Person By NationaNo
CREATE PROCEDURE GetPersonByNationalNo
    @NationalNo varchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    select People.*,Countries.CountryName from People 
    inner join Countries on People.NationalityCountryID = Countries.CountryID 
    where People.NationalNo = @NationalNo
END

--- Get person by country name ---
CREATE PROCEDURE GetPersonCountryName
    @CountryID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    Select * from Countries where CountryID = @CountryID
END


-- Get People
CREATE PROCEDURE GetPeople
AS
BEGIN
    select People.*,CountryName from People inner join Countries on People.NationalityCountryID = Countries.CountryID
END

-- Add person
CREATE PROCEDURE AddPerson
    @NationalNo varchar(20),
    @FirstName varchar(20),
    @LastName varchar(20),
    @DateOfBirth datetime,
    @Gendor int,
    @Address varchar(500),
    @Email varchar(100),
    @Phone varchar(20),
    @NationalityCountryID int,
    @ImagePath varchar(250)

As
Begin
    SET NOCOUNT ON;

    Insert into People (NationalNo, FirstName, LastName, DateOfBirth, Gendor, Address, Email, Phone, NationalityCountryID, ImagePath)
    Values(@NationalNo, @FirstName, @LastName, @DateOfBirth, @Gendor, @Address, @Email, @Phone, @NationalityCountryID, @ImagePath);
    
    SELECT SCOPE_IDENTITY() AS PersonID;
End

-- update person
CREATE PROCEDURE UpdatePerson
    @PersonID int,
    @NationalNo varchar(20),
    @FirstName varchar(20),
    @LastName varchar(20),
    @DateOfBirth datetime,
    @Gendor int,
    @Address varchar(500),
    @Email varchar(100),
    @Phone varchar(20),
    @NationalityCountryID int,
    @ImagePath varchar(250)
AS
BEGIN
    Update People 
    Set NationalNo = @NationalNo, FirstName = @FirstName, LastName = @LastName,
    Gendor = @Gendor, NationalityCountryID = @NationalityCountryID, Email = @Email,
    Phone=@Phone, Address=@Address,DateOfBirth=@DateOfBirth, ImagePath=@ImagePath
    Where PersonID = @PersonID
    
    SELECT @@ROWCOUNT AS RowsAffected;
END


--- Delete person
CREATE PROCEDURE DeletePerson
    @PersonID int
As
Begin
    Delete from People where PersonID = @PersonID;

    SELECT @@ROWCOUNT AS RowsAffected;
End



--- Create driver ---
CREATE PROCEDURE AddDriver
    @PersonID int,
    @CreatedByUserID int,
    @CreatedDate datetime

As
Begin
    SET NOCOUNT ON;

    Insert into Drivers (PersonID, CreatedByUserID, CreatedDate)
    Values(@PersonID, @CreatedByUserID, @CreatedDate);
    
    SELECT SCOPE_IDENTITY();
End


--- Find driver by person id ---
CREATE PROCEDURE FindDriver
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    select * from Drivers where PersonID = @PersonID
END


CREATE PROCEDURE FindDriverByID
    @DriverID INT
AS
BEGIN
    SET NOCOUNT ON;

    select * from Drivers where DriverID = @DriverID 
End

--- Get Driver ID ---
CREATE PROCEDURE GetDriverId
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    select DriverID from Drivers where PersonID = @PersonID
END

--- Get all drivers ---
CREATE PROCEDURE GetDrivers

AS
BEGIN
    select Drivers.*, DriverName = People.FirstName+People.LastName, 
    CreatedBy = Users.UserName from Drivers inner join People on 
    Drivers.PersonID = People.PersonID inner join users on 
    Drivers.CreatedByUserID = Users.UserID
END



--- Get all application types ---
CREATE PROCEDURE GetAllApplicationTypes

AS
BEGIN
    select * from ApplicationTypes
END


--- update application type ---

CREATE PROCEDURE UpdateApplicationType
    @AppID int,
    @AppTitle varchar(150),
    @AppFees int
AS
BEGIN
    Update ApplicationTypes 
    Set ApplicationTypeTitle = @AppTitle, ApplicationFees = @AppFees
    Where ApplicationTypeID = @AppID
    
    SELECT @@ROWCOUNT AS RowsAffected;
END

--- Get application type by id ---

CREATE PROCEDURE GetApplicationTypeById
    @AppTypeID INT
AS
BEGIN
    SET NOCOUNT ON;

    select * from ApplicationTypes where ApplicationTypeID =@AppTypeID
End