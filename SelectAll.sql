USE CompanyDB

SELECT * FROM Companies
SELECT * FROM ContactPerson
SELECT * FROM Note
SELECT * FROM Roles
SELECT * FROM Trade
SELECT Users.firstName, Users.lastName, Roles.roleName
FROM Users
JOIN Roles ON Roles.roleID = Users.role_id