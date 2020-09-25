using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace PissAndShit
{
    public class PaSConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(false)]
        [Label("Disable zombie speaking enchant table")]
        [Tooltip("Removes zombies having the chance to make horrid screeching noises")]
        public bool disableZombieScreech;
        [DefaultValue(false)]
        [Label("Disable boss1 music in endlesser mode")]
        [Tooltip("Disables the track 'Boss1' from constantly playing while endlesser mode is active")]
        public bool disableBossOneMusic;
    }
}
