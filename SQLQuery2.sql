CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT        IDENTITY (1, 1) NOT NULL,
    [UserId]           INT        NOT NULL,
    [OperationClaimId] INT NOT NULL ,
   CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_OperationClaim] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_User_OperationClaims] FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([Id])
);
