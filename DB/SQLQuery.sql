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