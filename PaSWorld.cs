using Terraria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using PissAndShit.NPCs;

namespace PissAndShit
{
    class PaSWorld : ModWorld
    {
        public static bool downedGodSlime = false;
        public static bool downedGrandDad = false;
        public static bool downedYoungDuke = false;
        public static bool downedBoozeshrume = false;
        public static bool downedHive = false;
        public static bool endlessModeSave = false;

        public override void Initialize()
        {
            downedGodSlime = false;
            downedGrandDad = false;
            downedYoungDuke = false;
            downedBoozeshrume = false;
            downedHive = false;
            endlessModeSave = false;
        }

        public override TagCompound Save()
        {
            var Downed = new List<string>();
            if (downedGodSlime) Downed.Add("godSlime");
            if (downedGrandDad) Downed.Add("grandDad");
            if (downedYoungDuke) Downed.Add("youngDuke");
            if (downedBoozeshrume) Downed.Add("boozeshrume");
            if (downedHive) Downed.Add("hive");
            var Modes = new List<string>();
            if (endlessModeSave) Modes.Add("endlessModeSave");
                 
            return new TagCompound
            {
                {
                    "Version", 0
                },
                {
                    "Downed", Downed

                },
                {
                    "Modes", Modes
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            var Downed = tag.GetList<string>("Downed");
            downedGodSlime = Downed.Contains("godSlime");
            downedGrandDad = Downed.Contains("grandDad");
            downedYoungDuke = Downed.Contains("youngDuke");
            downedBoozeshrume = Downed.Contains("boozeshrume");
            downedHive = Downed.Contains("hive");
            var Modes = tag.GetList<string>("Modes");
            endlessModeSave = Modes.Contains("endlessModeSave");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedGodSlime = flags[0];
                downedGrandDad = flags[1];
                downedYoungDuke = flags[2];
                downedBoozeshrume = flags[3];
                downedHive = flags[4];
                BitsByte flags1 = reader.ReadByte();
                endlessModeSave = flags1[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedGodSlime;
            flags[1] = downedGrandDad;
            flags[2] = downedYoungDuke;
            flags[3] = downedBoozeshrume;
            flags[4] = downedHive;

            BitsByte flags1 = new BitsByte();
            flags1[0] = endlessModeSave;

            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedGodSlime = flags[0];
            downedGrandDad = flags[1];
            downedYoungDuke = flags[2];
            downedBoozeshrume = flags[3];
            downedHive = flags[4];

            BitsByte flags1 = reader.ReadByte();
            endlessModeSave = flags1[0];
        }
    }
}
