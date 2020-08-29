// usings - thing that tModLoader will check for things. whenever you call something like Math(), tmod checks each one of these for Math() before giving up.
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

// namespace - should be the same as the folder structure. this boss's files are in PissAndShit/NPCs/Bosses, so we set namespace to the same.
// tmod will try to load a sprite from here + the internal name. if it doesn't find one, it gives up and spits an error.
// ex. this ModNPC is named PaSTemplateBoss and the namespace is PissAndShit.NPCs.Bosses.
// tModLoader will check for image files (not GIFs - animation will be added later) named PaSTemplateBoss in the namespace (in this case, PissAndShit.NPCs.Bosses).
namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead] // load boss minimap icon, keep this here!
    public class PaSExampleBoss : ModNPC // internal name : class
    {
	// keep these as private, nothing should need to access them that's outside of this ModNPC
	// if something does, change the name to something that will not be taken and replace private with public
	// ex. private int phase to public int TemplateBossPhase
	// these values do nothing on their own. we use them later in AI() to dictate things
	private int phase = 0; // what phase the boss is on
	private int attacktimer = 0; // an int which we will count up using attacktimer++; to time attacks
	private bool spin = true; // should the boss spin?

	// defaults which will never change
	// only certain values should go here
        public override void SetStaticDefaults()
        {
	    // name used in-game
            DisplayName.SetDefault("A Template Boss");
	    
	    // amount of frames that the game checks for vertically. this is why we ask for spritesheets
	    // tmod uses this in conjunction with the npc's width and height to determine each frame
	    // ex. if we had a 100 width 200 height image with this set to 2 as it is here, tmod will use 100px of the height as a frame, which lets us have two frames
	    // frames have to be manually animated, see FindFrame
	    Main.npcFrameCount[npc.type] = 2;

        }
	
	// defaults which can change
	// same as above, only certain values should go here
        public override void SetDefaults()
        {
            // width and height of a single animation frame
	    npc.width = 100;
            npc.height = 100;
	    
	    // how much damage it does on contact
	    // will be doubled in expert if you don't override scaling (shown below)
            npc.damage = 50;
	    
	    // percent chance to resist knockback, ranging from 0 = 0% to 1 = 100%
	    // use point values to specify things in-between, remember to keep the f after it to indicate it's a float, a value which takes decimals
            npc.knockBackResist = 1f;

	    // specify that the ModNPC is a boss
            npc.boss = true;

	    // ModNPC's max health, health can never go above this
	    // will be doubled in expert if you don't override scaling (shown below)
            npc.lifeMax = 10000;
	    
	    // ModNPC's defense, reduce amount of damage taken by 50% of this? (75% in expert maybe?)
            npc.defense = 10;

	    // does the NPC go through tiles? true = yes, false = no
            npc.noTileCollide = true;

	    // sets amount of money dropped on death
	    // in order: plat, gold, silver, copper
	    // this example drops 1 gold
            npc.value = Item.buyPrice(0, 1, 0, 0);

	    // the pre-made AI style to use
	    // we set it to -1 so we can have our own AIStyle
            npc.aiStyle = -1;

	    // hit and death sounds, sounds to be made when hit and on death
            npc.HitSound = SoundID.NPCHit1; // zombie sounds
            npc.DeathSound = SoundID.NPCDeath1; // zombie sounds

	    // does the NPC get hurt by lava? true = no, false = yes
            npc.lavaImmune = true;
	    
	    // get the music to play when this NPC is alive
	    // in this case we use Boozeshrume's Staying As a 1.14, which is located at Sounds/Music/Staying_As_a_1.14, using the PissAndShit folder as a base
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Staying_As_a_1.14");

	    // multiple music tracks are playing at once, which one should we play to the player?
	    // this dictates what should be played if multiple tracks are attempting to play
            musicPriority = MusicPriority.BossHigh;

	    // boss treasure bag item
	    // in this case we use Boozeshrume's treasure bag
            bossBag = ModContent.ItemType<Items.BossBags.BoozeshrumeBag>();
        }

	// AI, code to run every frame. dictates everything about movement, attacks, etc
        public override void AI()
        {
	    // is ModNPC's life below half of its max life?
            if (npc.life < npc.lifeMax / 2)
            {
		// if so, set phase to 1.
                phase = 1;
            }

	    // target closest player
            npc.TargetClosest(true);
	    
	    // change the direction the boss is facing to the direction it's moving in
            npc.spriteDirection = npc.direction;

	    // define the player value of type Player as the currently targeted player
            Player player = Main.player[npc.target];

	    // define the moveTo value of type Vector2 to the position currently targeted player's center minus the position of the ModNPC's center
            Vector2 moveTo = player.Center - npc.Center;

	    // normalize the value (TODO: What does this mean???)
            moveTo.Normalize();

	    // multiply the moveTo value by five, change five to how fast you want the NPC to move
            moveTo = moveTo * 5;

	    // set npc's velocity to the moveTo value, making the npc move in that direction at that speed
            npc.velocity = moveTo;

	    // is the value spin set to true?
            if (spin)
            {
		// if so, make NPC spin by setting rotation.
                npc.rotation += npc.velocity.X * 0.1f;
            }

	    // increment attacktimer by 1 every in-game frame
	    attacktimer++;
	    
	    // start a case switch. case switches are awesome!
	    // think of a case switch as an advanced if-else.
	    // this switch handles phase.
            switch((int)phase)
	    {
		// are we on phase 0 (half health or above)?
		case 0:
		    // if so, don't spin (see the above if (spin).
		    spin = false;
		    // count up attacktimer.
		    
		    if (attacktimer > 60) // if attacktimer is greater than 60
		    {
			// shoot a projectile, in this case a splosionator rocket which hurts the player out of the direction the modnpc is facing
			/*
			  Projectile.NewProjectile(new Vector2(npc.Center, // position to shoot from
			                                       new Vector2(npc.direction, 0), // speed and rotation to shoot at (vector2, x = direction npc is facing, y = 0)
							       ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), // projectile to shoot
							       40, // damage to deal
							       0f, // knockback to deal (keep the f)
							       Main.myPlayer, // owner (keep it as Main.myPlayer)
							       0f, // projectile.ai[0] value to set for the projectile
							       0f); // projectile.ai[1] value to set for the projectile
			*/
			// condensed version of above
			Projectile.NewProjectile(npc.Center, new Vector2(npc.direction, 0), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 40, 0f, Main.myPlayer, 0f, 0f);
			attacktimer = 0; // set attacktimer to 0
		    }
		    // break. this is nessecary at the end of every case.
		    break;
		// are we on phase 1 (1 health below half or below)?
		case 1:
		    // if so, spin (see the above if (spin)).
		    spin = true;
		    // shoot projectiles in both directions
		    if (attacktimer > 60) // if attacktimer is greater than 60
		    {
			// shoot projectiles in both directions
			Projectile.NewProjectile(npc.Center, new Vector2(-1, 0), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 40, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.Center, new Vector2(1, 0), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 40, 0f, Main.myPlayer, 0f, 0f);
			// set attacktimer to zero
			attacktimer = 0;
		    }
		    // break, same as above
		    break;
	    }
        }

	// NPCLoot, handles NPC loot after it dies.
        public override void NPCLoot()
        {

	    if (!Main.expertMode) // if not in expert mode...
	    {
		// make a value called bossWeapon which is a random value of either 0 or 1.
		int bossWeapon = Main.rand.Next(2);
		// start a case switch of bossWeapon.
		switch((int)bossWeapon)
		{
		    // is bossWeapon 0?
		    case 0:
			// if so, drop Boozeshrume's Beer Bow.
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Weapons.BeerBow>());
			break;
		    // is bossWeapon 1?
		    case 1:
			// if so, drop Boozeshrume's Beer Book.
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Weapons.BeerBook>());
			break;
		}
	    }
	    else // if in expert mode...
	    {
		npc.DropBossBags(); // drop boozeshrume bag (see bossBag variable in SetDefaults).
	    }
	}

	// FindFrame, used for animating sprite frames
	public override void FindFrame(int frameHeight)
        {
	    // increment animation frame counter every in-game frame. is it greater than two?
            if (++npc.frameCounter > 2)
            {
		// if so, set it to zero
                npc.frameCounter = 0;
		// update the frame we're using
                npc.frame.Y += frameHeight;
		// is the frame we're using greater or equal to 2 multiplied by the height of the frame?
                if (npc.frame.Y >= 2 * frameHeight)
                {
		    // if so, set frame we're on to frame zero.
                    npc.frame.Y = 0;
                }
            }
        }
    }
}
