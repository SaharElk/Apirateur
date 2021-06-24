CREATE PROCEDURE [dbo].[SP_AuthUser]
	@Email NVARCHAR(384),
	@Password NVARCHAR(20)
AS
BEGIN
	SELECT [Id], LastName, FirstName, Email, IsAdmin
	FROM [User] 
	WHERE Email = @Email
	AND Password = HASHBYTES('SHA2_512', dbo.SF_GetPreSalt() + @Password + dbo.SF_GetPostSalt());
	
	RETURN 0;
END
