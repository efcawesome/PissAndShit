using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace PissAndShit.NPCs.Bosses
{
    public class DeathItself : ModNPC
    {

	private int DeathPhase = 0;
	private int DeathAttkCounter1 = 0;
	private int DeathAttkCounter2 = 0;
	private int DeathRocketShootOffset = 0;
	private int DeathRocketShootOffset2 = 0;
	private int DeathRocketsShot = 0;
	
	public override void SetStaticDefaults()
	{
	    DisplayName.SetDefault("Death Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish");
	    //Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
	}
	
	public override void SetDefaults()
	{
	    npc.width = 40;
	    npc.height = 40;
	    npc.damage = 400;
	    npc.defense = 70;
	    npc.lifeMax = 220000;
	    npc.HitSound = SoundID.NPCHit1;
	    npc.DeathSound = SoundID.NPCDeath2;
	    npc.value = 6000000f;
	    npc.knockBackResist = 0f;
	    npc.boss = true;
	    npc.lavaImmune = true;
	    npc.noTileCollide = true;
	    npc.noGravity = true;
	    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/LastDance");
            musicPriority = MusicPriority.BossHigh;
	    for (int i = 1; i < 1000; i++)
	    {
		npc.ai[0] = 0;
	    }
	}
	
	public override void AI()
	{
	    Player player = Main.player[Main.myPlayer];
	    
	    switch ((int)npc.ai[0])
	    {
		case 0:
		    npc.ai[1]++;
		    if (npc.ai[1] == 30)
		    {
			DeathRocketShootOffset = -10;
			for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
			{
			    Projectile.NewProjectile(npc.position, new Vector2(14, -DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
			DeathAttkCounter1 = DeathAttkCounter1 + 1;
		    }
		    if (npc.ai[1] == 60)
		    {
			DeathRocketShootOffset = -10;
			for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
			{
			    Projectile.NewProjectile(npc.position, new Vector2(-14, DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
			DeathAttkCounter1 = DeathAttkCounter1 + 1;
			npc.ai[1] = 0;
		    }
		    if (DeathAttkCounter1 == 4)
		    {
			DeathRocketsShot = 0;
			DeathRocketShootOffset = 0;
			npc.ai[0]++;
		    }
		    break;
		    
		case 1:
		    if (DeathAttkCounter2 = 1)
			break;
		    DeathAttkCounter1 = 0;
		    //DeathRocketsShot = 0;
		    for (DeathRocketShootOffset2 = 0; DeathRocketShootOffset2 < 800; DeathRocketShootOffset2 = DeathRocketShootOffset2 + 20)
		    {
			if (DeathRocketsShot >= 200)
			{
			    DeathAttkCounter2 = 1;
			    npc.ai[0] = 0;
			}
			Projectile.NewProjectile(new Vector2(npc.position.X - 400 + DeathRocketShootOffset2 * 6, npc.position.Y - 800), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			DeathRocketsShot = DeathRocketsShot + 1;
		    }
		    break;
	    }
	}
    }	
}
