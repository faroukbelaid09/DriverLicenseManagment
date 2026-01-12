-- Get users without password
CREATE PROCEDURE GetUsers
AS
BEGIN
    SELECT Users.UserID, Users.PersonID, UserName, FullName = People.FirstName+People.LastName, Users.IsActive
    FROM Users
    inner JOIN People ON Users.PersonID = People.PersonID
END

-- Get user for authentication
CREATE PROCEDURE GetUserForAuthentication
    @UserName NVARCHAR(100)
AS
BEGIN
    SELECT UserID, UserName, Password, IsActive
    FROM Users
    WHERE UserName = @UserName
END