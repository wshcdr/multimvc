﻿using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class ResourceDetail
    {
        partial void Resource_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Resource);
        }

        partial void Resource_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Resource);
        }

        partial void ResourceDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Resource);
        }
    }
}