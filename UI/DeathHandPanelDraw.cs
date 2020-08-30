using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;

namespace PissAndShit.UI
{
    class DeathHandPanelDraw : UIState
    {
        public DraggablePanel BackgroundPanel;
        public UIPanel NPCBackgroundPanel;
        public static bool DeathHandPanelVisible;
        public UIDrawNPC NPCImage;
        public override void OnInitialize()
        {
        	BackgroundPanel = new DraggablePanel();
			BackgroundPanel.SetPadding(0);
			BackgroundPanel.Left.Set(400f, 0f);
			BackgroundPanel.Top.Set(100f, 0f);
			BackgroundPanel.Width.Set(600f, 0f);
			BackgroundPanel.Height.Set(400f, 0f);
            BackgroundPanel.BackgroundColor = new Color(73, 94, 171);

            NPCBackgroundPanel = new UIPanel();
			NPCBackgroundPanel.SetPadding(0);
			NPCBackgroundPanel.Left.Set(10f, 0f);
			NPCBackgroundPanel.Top.Set(60f, 0f);
			NPCBackgroundPanel.Width.Set(280f, 0f);
			NPCBackgroundPanel.Height.Set(330f, 0f);
            NPCBackgroundPanel.BackgroundColor = new Color(50, 58, 119);

            BackgroundPanel.Append(NPCBackgroundPanel);

            NPCImage = new UIDrawNPC(new Vector2(0, 0));

            NPCImage.Left.Set(240f, 0f);
            NPCImage.Top.Set(20f, 0f);

            NPCBackgroundPanel.Append(NPCImage);

            Texture2D buttonKillTexture = ModContent.GetTexture("PissAndShit/UI/DeathHandKillButton");
			UIHoverImageButton killButton = new UIHoverImageButton(buttonKillTexture, "Kill NPC");
			killButton.Left.Set(10, 0f);
			killButton.Top.Set(10, 0f);
			killButton.Width.Set(40, 0f);
			killButton.Height.Set(40, 0f);
			killButton.OnClick += new MouseEvent(KillButtonClicked);
            BackgroundPanel.Append(killButton);

            Texture2D buttonDamageTexture = ModContent.GetTexture("PissAndShit/UI/DeathHandDamageButton");
			UIHoverImageButton damageButton = new UIHoverImageButton(buttonDamageTexture, "Damage NPC");
			damageButton.Left.Set(60, 0f);
		    damageButton.Top.Set(10, 0f);
			damageButton.Width.Set(40, 0f);
			damageButton.Height.Set(40, 0f);
			damageButton.OnClick += new MouseEvent(DamageButtonClicked);
            BackgroundPanel.Append(damageButton);

            Append(BackgroundPanel);
            
        }
        
        private void KillButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            NPC npc = Main.npc[PaSWorld.deathHandNPCIdentifier];
            npc.dontTakeDamage = false;
            npc.life = 1;
            npc.StrikeNPCNoInteraction(777, 0f, 0);
        }

        private void DamageButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Player player = Main.player[Main.myPlayer];
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " got stuck in a custom UI box."), 1.0, 0);
        }
    }
}