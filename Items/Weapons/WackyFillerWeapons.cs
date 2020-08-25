using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

//haha all in one file goes brrrrrr

namespace PissAndShit.Items.Weapons
{
    public class DynamiteSord : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynamite of the Gods");
        }
        public override void SetDefaults()
        {
            item.damage = 1;
            item.melee = true;
            item.width = 56;
            item.height = 56;
            item.noMelee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.rare = -12;
            item.autoReuse = true;
            item.shoot = ProjectileID.Dynamite;
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 19f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numProj = 5;
            float rotation = MathHelper.ToRadians(15);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numProj; i++)
            {
                Vector2 pertSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1))); // * .7f
                Projectile.NewProjectile(position.X, position.Y, pertSpeed.X, pertSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 666);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class TombstoneLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tombstone Launcher");
        }
        public override void SetDefaults()
        {
            item.damage = 1;
            item.ranged = true;
            item.width = 46;
            item.height = 32;
            item.noMelee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.rare = -1;
            item.autoReuse = true;
            item.shoot = ProjectileID.Tombstone;
            item.UseSound = SoundID.Item11;
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Tombstone, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class tortle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Gun");
        }
        public override void SetDefaults()
        {
            item.damage = 51;
            item.ranged = true;
            item.width = 32;
            item.height = 24;
            item.noMelee = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.rare = 7;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("liltortle");
            item.UseSound = SoundID.Item11;
            item.shootSpeed = 24f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Handgun);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    class liltortle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Shell");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.timeLeft = 360;
            projectile.penetrate = 5;
            projectile.tileCollide = true;
            projectile.ranged = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = oldVelocity.X * -1f;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = oldVelocity.Y * -1f;
            }
            return false;
        }
    }
    public class HalfExistingTrident : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Imagine clipping through reality");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 9;
            item.useTime = 9;
            item.shootSpeed = 3.7f;
            item.knockBack = 6.5f;
            item.width = 64;
            item.height = 64;
            item.scale = 0.5f;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(silver: 75);

            item.melee = true;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("HalfExistingTridentProj");
        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 5;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numProj = 5;
            float rotation = MathHelper.ToRadians(35);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numProj; i++)
            {
                Vector2 pertSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1))); // * .7f
                Projectile.NewProjectile(position.X, position.Y, pertSpeed.X, pertSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class HalfExistingTridentProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Half Existing Trident");
        }

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.scale = 0.5f;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        // In here the AI uses this example, to make the code more organized and readable
        // Also showcased in ExampleJavelinProjectile.cs
        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        // It appears that for this AI, only the ai0 field is used!
        public override void AI()
        {
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            Player projOwner = Main.player[projectile.owner];
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 4.7f;
                }
                else // Otherwise, increase the movement factor
                {
                    movementFactor += 7.3f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(158f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(58f);
            }
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 7.4f;
                }
                else // Otherwise, increase the movement factor
                {
                    movementFactor += 3.7f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(185f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(85f);
            }
        }
    }
    public class AncientMonkys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of the Ancient Monkys");
            Tooltip.SetDefault("Monky");
        }
        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.width = 32;
            item.height = 24;
            item.noMelee = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.rare = ItemRarityID.Purple;
            item.autoReuse = true;
            item.mana = 10;
            item.shoot = 532;
            item.UseSound = SoundID.Item8;
            item.shootSpeed = 12f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 370, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 497, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 607, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 700, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 78, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 712, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 669, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 523, damage, knockBack, player.whoAmI);
            return true;
        }
        class MyGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.CultistBoss)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("AncientMonkys"), 1);
                }
            }
        }
    }
}
