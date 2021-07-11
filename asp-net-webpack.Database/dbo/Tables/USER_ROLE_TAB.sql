﻿CREATE TABLE [dbo].[USER_ROLE_TAB] (
    [UserId] BIGINT NOT NULL,
    [RoleId] BIGINT NOT NULL,
    CONSTRAINT [PK_USER_ROLE_TAB] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_USER_ROLE_TAB_ROLE_TAB] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[ROLE_TAB] ([RoleId]),
    CONSTRAINT [FK_USER_ROLE_TAB_USER_TAB] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USER_TAB] ([UserId])
);

