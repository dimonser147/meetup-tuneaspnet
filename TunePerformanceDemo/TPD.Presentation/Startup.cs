﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPD.Presentation.Startup))]
namespace TPD.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
