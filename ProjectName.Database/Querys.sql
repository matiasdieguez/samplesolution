SELECT * FROM dbo.Users

INSERT INTO Users (Username, [Password], CreationDate, UserType)
VALUES ('sa', 'Pericles1976',  GETDATE(), 0);

update users set [Password] = '12345' where id = 1