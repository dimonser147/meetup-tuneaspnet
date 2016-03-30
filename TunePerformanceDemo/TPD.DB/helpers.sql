-- update images
 --picture: {
 --       large: "http://api.randomuser.me/portraits/women/39.jpg",
 --       medium: "http://api.randomuser.me/portraits/med/women/39.jpg",
 --       thumbnail: "http://api.randomuser.me/portraits/thumb/women/39.jpg",
 --     },

-- set thumb image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/men', 'portlaits/thumb/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/women', 'portlaits/thumb/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/med/men', 'portlaits/thumb/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/med/women', 'portlaits/thumb/women')
-- set med image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/men', 'portlaits/med/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/women', 'portlaits/med/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/thumb/men', 'portlaits/med/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/thumb/women', 'portlaits/med/women')
-- set large image
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/med/men', 'portlaits/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/med/women', 'portlaits/women')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/thumb/men', 'portlaits/men')
update [Speakers] set [ImageUrl] = REPLACE([ImageUrl], 'portlaits/thumb/women', 'portlaits/women')