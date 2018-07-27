namespace RpgEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mapDisplay = new RpgEditor.Map.MapDisplay();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.tabLayers = new System.Windows.Forms.TabPage();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.tabChests = new System.Windows.Forms.TabPage();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.levelToolStripMenuItem,
            this.tilesetToolStripMenuItem,
            this.mapLayerToolStripMenuItem,
            this.classesToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.chestsToolStripMenuItem,
            this.skillsToolStripMenuItem,
            this.charactersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.openGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // openGameToolStripMenuItem
            // 
            this.openGameToolStripMenuItem.Name = "openGameToolStripMenuItem";
            this.openGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openGameToolStripMenuItem.Text = "&Open Game";
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveGameToolStripMenuItem.Text = "&Save Game";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitGameToolStripMenuItem
            // 
            this.exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            this.exitGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitGameToolStripMenuItem.Text = "E&xit Game";
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Enabled = false;
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.classesToolStripMenuItem.Text = "&Classes";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponToolStripMenuItem,
            this.armorToolStripMenuItem,
            this.shieldToolStripMenuItem});
            this.itemsToolStripMenuItem.Enabled = false;
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "&Items";
            // 
            // weaponToolStripMenuItem
            // 
            this.weaponToolStripMenuItem.Name = "weaponToolStripMenuItem";
            this.weaponToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.weaponToolStripMenuItem.Text = "&Weapon";
            // 
            // armorToolStripMenuItem
            // 
            this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
            this.armorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.armorToolStripMenuItem.Text = "&Armor";
            // 
            // shieldToolStripMenuItem
            // 
            this.shieldToolStripMenuItem.Name = "shieldToolStripMenuItem";
            this.shieldToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shieldToolStripMenuItem.Text = "&Shield";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.Enabled = false;
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.keysToolStripMenuItem.Text = "&Keys";
            // 
            // chestsToolStripMenuItem
            // 
            this.chestsToolStripMenuItem.Enabled = false;
            this.chestsToolStripMenuItem.Name = "chestsToolStripMenuItem";
            this.chestsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.chestsToolStripMenuItem.Text = "C&hests";
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Enabled = false;
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.skillsToolStripMenuItem.Text = "&Skills";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLevelToolStripMenuItem,
            this.openLevelToolStripMenuItem,
            this.saveLevelToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.levelToolStripMenuItem.Enabled = false;
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // newLevelToolStripMenuItem
            // 
            this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
            this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newLevelToolStripMenuItem.Text = "&New Level";
            // 
            // openLevelToolStripMenuItem
            // 
            this.openLevelToolStripMenuItem.Name = "openLevelToolStripMenuItem";
            this.openLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openLevelToolStripMenuItem.Text = "&Open Level";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveLevelToolStripMenuItem.Text = "&Save Level";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetToolStripMenuItem,
            this.openTilesetToolStripMenuItem,
            this.saveTilesetToolStripMenuItem,
            this.removeTilesetToolStripMenuItem});
            this.tilesetToolStripMenuItem.Enabled = false;
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tilesetToolStripMenuItem.Text = "&Tileset";
            // 
            // newTilesetToolStripMenuItem
            // 
            this.newTilesetToolStripMenuItem.Name = "newTilesetToolStripMenuItem";
            this.newTilesetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTilesetToolStripMenuItem.Text = "&New Tileset";
            // 
            // openTilesetToolStripMenuItem
            // 
            this.openTilesetToolStripMenuItem.Name = "openTilesetToolStripMenuItem";
            this.openTilesetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openTilesetToolStripMenuItem.Text = "&Open Tileset";
            // 
            // saveTilesetToolStripMenuItem
            // 
            this.saveTilesetToolStripMenuItem.Name = "saveTilesetToolStripMenuItem";
            this.saveTilesetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveTilesetToolStripMenuItem.Text = "&Save Tileset";
            // 
            // removeTilesetToolStripMenuItem
            // 
            this.removeTilesetToolStripMenuItem.Name = "removeTilesetToolStripMenuItem";
            this.removeTilesetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeTilesetToolStripMenuItem.Text = "&Remove Tileset";
            // 
            // mapLayerToolStripMenuItem
            // 
            this.mapLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerToolStripMenuItem,
            this.openLayerToolStripMenuItem,
            this.saveLayerToolStripMenuItem});
            this.mapLayerToolStripMenuItem.Enabled = false;
            this.mapLayerToolStripMenuItem.Name = "mapLayerToolStripMenuItem";
            this.mapLayerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.mapLayerToolStripMenuItem.Text = "&Map Layer";
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newLayerToolStripMenuItem.Text = "&New Layer";
            // 
            // openLayerToolStripMenuItem
            // 
            this.openLayerToolStripMenuItem.Name = "openLayerToolStripMenuItem";
            this.openLayerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openLayerToolStripMenuItem.Text = "&Open Layer";
            // 
            // saveLayerToolStripMenuItem
            // 
            this.saveLayerToolStripMenuItem.Name = "saveLayerToolStripMenuItem";
            this.saveLayerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveLayerToolStripMenuItem.Text = "&Save Layer";
            // 
            // charactersToolStripMenuItem
            // 
            this.charactersToolStripMenuItem.Enabled = false;
            this.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            this.charactersToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.charactersToolStripMenuItem.Text = "&Characters";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapDisplay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabProperties);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 657);
            this.splitContainer1.SplitterDistance = 800;
            this.splitContainer1.TabIndex = 2;
            // 
            // mapDisplay
            // 
            this.mapDisplay.BackColor = System.Drawing.Color.Black;
            this.mapDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDisplay.Location = new System.Drawing.Point(0, 0);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(800, 657);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.VSync = false;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.tabTilesets);
            this.tabProperties.Controls.Add(this.tabLayers);
            this.tabProperties.Controls.Add(this.tabCharacters);
            this.tabProperties.Controls.Add(this.tabChests);
            this.tabProperties.Controls.Add(this.tabKeys);
            this.tabProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProperties.Location = new System.Drawing.Point(0, 0);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            this.tabProperties.Size = new System.Drawing.Size(204, 657);
            this.tabProperties.TabIndex = 1;
            // 
            // tabTilesets
            // 
            this.tabTilesets.Location = new System.Drawing.Point(4, 22);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Size = new System.Drawing.Size(196, 631);
            this.tabTilesets.TabIndex = 0;
            this.tabTilesets.Text = "Tiles";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // tabLayers
            // 
            this.tabLayers.Location = new System.Drawing.Point(4, 22);
            this.tabLayers.Name = "tabLayers";
            this.tabLayers.Size = new System.Drawing.Size(196, 631);
            this.tabLayers.TabIndex = 1;
            this.tabLayers.Text = "Map Layers";
            this.tabLayers.UseVisualStyleBackColor = true;
            // 
            // tabCharacters
            // 
            this.tabCharacters.Location = new System.Drawing.Point(4, 22);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Size = new System.Drawing.Size(196, 631);
            this.tabCharacters.TabIndex = 2;
            this.tabCharacters.Text = "Characters";
            this.tabCharacters.UseVisualStyleBackColor = true;
            // 
            // tabChests
            // 
            this.tabChests.Location = new System.Drawing.Point(4, 22);
            this.tabChests.Name = "tabChests";
            this.tabChests.Size = new System.Drawing.Size(196, 631);
            this.tabChests.TabIndex = 3;
            this.tabChests.Text = "Chests";
            this.tabChests.UseVisualStyleBackColor = true;
            // 
            // tabKeys
            // 
            this.tabKeys.Location = new System.Drawing.Point(4, 22);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Size = new System.Drawing.Size(196, 631);
            this.tabKeys.TabIndex = 4;
            this.tabKeys.Text = "Keys";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charactersToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Map.MapDisplay mapDisplay;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.TabPage tabTilesets;
        private System.Windows.Forms.TabPage tabLayers;
        private System.Windows.Forms.TabPage tabCharacters;
        private System.Windows.Forms.TabPage tabChests;
        private System.Windows.Forms.TabPage tabKeys;
    }
}

