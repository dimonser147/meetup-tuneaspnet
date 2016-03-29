CREATE TABLE [dbo].[SpeakersToProgramms]
(
	[SpeakerId] INT NOT NULL,
	[ProgrammId] INT NOT NULL,
	CONSTRAINT [PK_SpeakersToProgramms] PRIMARY KEY ([SpeakerId], [ProgrammId]),
	constraint [FK_SpeakersToProgramms_TO_Speakers] foreign key ([SpeakerId]) references [Speakers] ([Id]) on delete cascade,
	constraint [FK_SpeakersToProgramms_TO_Programms] foreign key ([ProgrammId]) references [Programms] ([Id]) on delete cascade
)
