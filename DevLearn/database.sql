CREATE TABLE [dbo].[Author] (
    [IdAuthor]  INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([IdAuthor] ASC)
);




CREATE TABLE [dbo].[Items] (
    [IdItem]          INT            IDENTITY (1, 1) NOT NULL,
    [ItemInformation] NVARCHAR (MAX) NULL,
    [RightVariant]    INT            NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([IdItem] ASC)
);




CREATE TABLE [dbo].[Lectures] (
    [IdLecture]      INT           IDENTITY (1, 1) NOT NULL,
    [AuthorIdAuthor] INT           NOT NULL,
    [AddedDate]      DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Lectures] PRIMARY KEY CLUSTERED ([IdLecture] ASC),
    CONSTRAINT [FK_Lectures_Author_AuthorIdAuthor] FOREIGN KEY ([AuthorIdAuthor]) REFERENCES [dbo].[Author] ([IdAuthor]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Lectures_AuthorIdAuthor]
    ON [dbo].[Lectures]([AuthorIdAuthor] ASC);





CREATE TABLE [dbo].[Slide] (
    [IdSlide]          INT            IDENTITY (1, 1) NOT NULL,
    [Information]      NVARCHAR (MAX) NOT NULL,
    [LectureIdLecture] INT            NULL,
    CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED ([IdSlide] ASC),
    CONSTRAINT [FK_Slide_Lectures_LectureIdLecture] FOREIGN KEY ([LectureIdLecture]) REFERENCES [dbo].[Lectures] ([IdLecture])
);


GO
CREATE NONCLUSTERED INDEX [IX_Slide_LectureIdLecture]
    ON [dbo].[Slide]([LectureIdLecture] ASC);





CREATE TABLE [dbo].[Variant] (
    [IdVariant]          INT            IDENTITY (1, 1) NOT NULL,
    [VariantInformation] NVARCHAR (MAX) NULL,
    [ItemIdItem]         INT            NULL,
    CONSTRAINT [PK_Variant] PRIMARY KEY CLUSTERED ([IdVariant] ASC),
    CONSTRAINT [FK_Variant_Items_ItemIdItem] FOREIGN KEY ([ItemIdItem]) REFERENCES [dbo].[Items] ([IdItem])
);


GO
CREATE NONCLUSTERED INDEX [IX_Variant_ItemIdItem]
    ON [dbo].[Variant]([ItemIdItem] ASC);

