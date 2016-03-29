CREATE TABLE [dbo].[SpeakerLikes]
(
	[LikeId] [bigint] not null identity(1,1),
	[SpeakerId] [int] NOT NULL,
	[OccuredAt] [date] NOT NULL, 
    CONSTRAINT [PK_SpeakerLikes] PRIMARY KEY ([LikeId]),
	constraint [FK_SpeakerLikes_TO_Speakers] foreign key ([SpeakerId]) references [Speakers] ([Id]) on delete cascade
)