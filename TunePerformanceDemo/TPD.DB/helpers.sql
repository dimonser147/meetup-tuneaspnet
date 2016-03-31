-- update images
 --picture: {
 --       large: "http://api.randomuser.me/portraits/women/39.jpg",
 --       medium: "http://api.randomuser.me/portraits/med/women/39.jpg",
 --       thumbnail: "http://api.randomuser.me/portraits/thumb/women/39.jpg",
 --     },

-- set thumb image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/men', 'portraits/thumb/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/women', 'portraits/thumb/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/med/men', 'portraits/thumb/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/med/women', 'portraits/thumb/women')
-- set med image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/men', 'portraits/med/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/women', 'portraits/med/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/thumb/men', 'portraits/med/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/thumb/women', 'portraits/med/women')
-- set large image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/med/men', 'portraits/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/med/women', 'portraits/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/thumb/men', 'portraits/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portraits/thumb/women', 'portraits/women')
-- index
CREATE NONCLUSTERED INDEX [IX_SPEAKERS_TOPSPEAKERS]
ON [Speakers] ([Position])
include ([Id], [Firstname], [Lastname], [ImageUrl])
WITH(ONLINE=ON);
-- On Azure SQL Database, you must use the ONLINE=ON option in order to reduce locking and the transaction log size. 
-- Furthermore, this option will greatly reduce your chances of getting a timeout.