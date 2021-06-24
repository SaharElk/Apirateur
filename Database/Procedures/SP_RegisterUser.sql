CREATE PROCEDURE [dbo].[SP_RegisterUser]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(384),
	@Password NVARCHAR(20)
AS
BEGIN
	INSERT INTO [User] (LastName, FirstName, Email, Password) VALUES 
	(@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.SF_GetPreSalt() + @Password + dbo.SF_GetPostSalt()));

	if(SCOPE_IDENTITY() = 1)
		Update [User] Set IsAdmin = 1 WHERE Id = 1;

	RETURN 0;
END
