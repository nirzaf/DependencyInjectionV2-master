USE personalblog;
GO

CREATE TABLE POSTS
(
 Id UniqueIdentifier not null primary key,
 PostDateTime DateTime not null default(getdate()),
 Title varchar(max) not null,
 Content varchar(max) not null
)

GO

CREATE PROC CREATE_POST
	@Id UniqueIdentifier,
	@PostDateTime DateTime,
	@Title varchar(max),
	@Content varchar(max)
AS
	INSERT INTO POSTS (Id, PostDateTime, Title, Content)
	VALUES (@Id, @PostDateTime, @Title, @Content)
Go

CREATE PROC GET_ALL
AS
	SELECT Id, PostDateTime, Title, Content
	From Posts

GO