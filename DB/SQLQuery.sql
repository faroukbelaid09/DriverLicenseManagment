
CREATE PROCEDURE GetUsers
As
Begin

    SET NOCOUNT ON;

    select Users.*, FullName = People.FirstName+People.LastName from Users 
    inner join People on Users.PersonID = People.PersonID
End