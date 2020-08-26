using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace PissAndShit
{
    public class PaSWorld : ModWorld
    {
        public static bool downedGodSlime = false;
        public static bool downedGrandDad = false;
        public static bool downedYoungDuke = false;
        public static bool downedBoozeshrume = false;
        public static bool downedVendingMachine = false;
        public static bool downedDeathHimself = false;
        public static bool downedHive = false;
        public static bool endlessModeSave = false;
        public static bool endlesserModeSave = false;

        public override void Initialize()
        {
            downedGodSlime = false;
            downedGrandDad = false;
            downedYoungDuke = false;
            downedBoozeshrume = false;
            downedVendingMachine = false;
            downedDeathHimself = false;
            downedHive = false;
            endlessModeSave = false;
            endlesserModeSave = false;
        }

        public override TagCompound Save()
        {
            List<string> Downed = new List<string>();
            List<string> Modes = new List<string>();

            if (downedGodSlime)
            {
                Downed.Add("godSlime");
            }

            if (downedGrandDad)
            {
                Downed.Add("grandDad");
            }

            if (downedYoungDuke)
            {
                Downed.Add("youngDuke");
            }

            if (downedBoozeshrume)
            {
                Downed.Add("boozeshrume");
            }

            if (downedVendingMachine)
            {
                Downed.Add("vendingMachine");
            }

            if (downedDeathHimself)
            {
                Downed.Add("deathHimself");
            }

            if (downedHive)
            {
                Downed.Add("hive");
            }

            if (endlessModeSave)
            {
                Modes.Add("endlessModeSave");
            }

            if (endlesserModeSave)
            {
                Modes.Add("endlesserModeSave");
            }

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
            IList<string> Downed = tag.GetList<string>("Downed");
            IList<string> Modes = tag.GetList<string>("Modes");

            downedGodSlime = Downed.Contains("godSlime");
            downedGrandDad = Downed.Contains("grandDad");
            downedYoungDuke = Downed.Contains("youngDuke");
            downedBoozeshrume = Downed.Contains("boozeshrume");
            downedVendingMachine = Downed.Contains("vendingMachine");
            downedDeathHimself = Downed.Contains("deathHimself");
            downedHive = Downed.Contains("hive");
            endlessModeSave = Modes.Contains("endlessModeSave");
            endlesserModeSave = Modes.Contains("endlesserModeSave");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();

            if (loadVersion == 0)
            {
                BitsByte downedFlags0 = reader.ReadByte();
                BitsByte miscFlags0 = reader.ReadByte();

                downedGodSlime = downedFlags0[0];
                downedGrandDad = downedFlags0[1];
                downedYoungDuke = downedFlags0[2];
                downedBoozeshrume = downedFlags0[3];
                downedHive = downedFlags0[4];
                downedVendingMachine = downedFlags0[5];
                downedDeathHimself = downedFlags0[6];
                endlessModeSave = miscFlags0[0];
                endlesserModeSave = miscFlags0[1];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte downedFlags0 = new BitsByte();
            BitsByte miscFlags0 = new BitsByte();

            downedFlags0[0] = downedGodSlime;
            downedFlags0[1] = downedGrandDad;
            downedFlags0[2] = downedYoungDuke;
            downedFlags0[3] = downedBoozeshrume;
            downedFlags0[4] = downedHive;
            downedFlags0[5] = downedVendingMachine;
            downedFlags0[6] = downedDeathHimself;
            miscFlags0[0] = endlessModeSave;
            miscFlags0[1] = endlesserModeSave;

            writer.Write(downedFlags0);
            writer.Write(miscFlags0);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte downedFlags0 = reader.ReadByte();
            BitsByte miscFlags0 = reader.ReadByte();

            downedGodSlime = downedFlags0[0];
            downedGrandDad = downedFlags0[1];
            downedYoungDuke = downedFlags0[2];
            downedBoozeshrume = downedFlags0[3];
            downedHive = downedFlags0[4];
            endlessModeSave = miscFlags0[0];
            endlesserModeSave = miscFlags0[0];
        }
        public override void PostUpdate()
        {
            AGLobalNPC.hardDifficulty = endlessModeSave;
            AGLobalNPC.endlesserModeBool = endlesserModeSave;
        }
    }
}
