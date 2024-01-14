namespace RS_Security_Center
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tSB_RetrieveAll = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelSystemusersCopyTo = new System.Windows.Forms.Label();
            this.listBoxRolesCopyTo = new System.Windows.Forms.ListBox();
            this.listBoxSystemusersCopyTo = new System.Windows.Forms.ListBox();
            this.buttonDisassociate = new System.Windows.Forms.Button();
            this.labelRolesCopyTo = new System.Windows.Forms.Label();
            this.labelRoles = new System.Windows.Forms.Label();
            this.buttonSynchronize = new System.Windows.Forms.Button();
            this.labelSystemusers = new System.Windows.Forms.Label();
            this.listBoxSystemusers = new System.Windows.Forms.ListBox();
            this.buttonAssociate = new System.Windows.Forms.Button();
            this.listBoxRoles = new System.Windows.Forms.ListBox();
            this.txtBoxSystemusersSearch = new System.Windows.Forms.TextBox();
            this.lblSystemuserSearch = new System.Windows.Forms.Label();
            this.txtBoxSystemusersCopyToSearch = new System.Windows.Forms.TextBox();
            this.lblSystemusersCopyToSearch = new System.Windows.Forms.Label();
            this.checkBoxInactive = new System.Windows.Forms.CheckBox();
            this.checkBoxSystemuser = new System.Windows.Forms.CheckBox();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_RetrieveAll,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1848, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tSB_RetrieveAll
            // 
            this.tSB_RetrieveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tSB_RetrieveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_RetrieveAll.Name = "tSB_RetrieveAll";
            this.tSB_RetrieveAll.Size = new System.Drawing.Size(103, 29);
            this.tSB_RetrieveAll.Text = "Retrieve All";
            this.tSB_RetrieveAll.ToolTipText = "Systemusers and roles";
            this.tSB_RetrieveAll.Click += new System.EventHandler(this.tSB_RetrieveAll_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // labelSystemusersCopyTo
            // 
            this.labelSystemusersCopyTo.AutoSize = true;
            this.labelSystemusersCopyTo.Location = new System.Drawing.Point(947, 70);
            this.labelSystemusersCopyTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSystemusersCopyTo.Name = "labelSystemusersCopyTo";
            this.labelSystemusersCopyTo.Size = new System.Drawing.Size(101, 20);
            this.labelSystemusersCopyTo.TabIndex = 21;
            this.labelSystemusersCopyTo.Text = "Systemusers";
            // 
            // listBoxRolesCopyTo
            // 
            this.listBoxRolesCopyTo.FormattingEnabled = true;
            this.listBoxRolesCopyTo.ItemHeight = 20;
            this.listBoxRolesCopyTo.Location = new System.Drawing.Point(1306, 92);
            this.listBoxRolesCopyTo.Name = "listBoxRolesCopyTo";
            this.listBoxRolesCopyTo.ScrollAlwaysVisible = true;
            this.listBoxRolesCopyTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxRolesCopyTo.Size = new System.Drawing.Size(350, 1104);
            this.listBoxRolesCopyTo.Sorted = true;
            this.listBoxRolesCopyTo.TabIndex = 22;
            // 
            // listBoxSystemusersCopyTo
            // 
            this.listBoxSystemusersCopyTo.FormattingEnabled = true;
            this.listBoxSystemusersCopyTo.ItemHeight = 20;
            this.listBoxSystemusersCopyTo.Location = new System.Drawing.Point(950, 92);
            this.listBoxSystemusersCopyTo.Name = "listBoxSystemusersCopyTo";
            this.listBoxSystemusersCopyTo.ScrollAlwaysVisible = true;
            this.listBoxSystemusersCopyTo.Size = new System.Drawing.Size(350, 1104);
            this.listBoxSystemusersCopyTo.Sorted = true;
            this.listBoxSystemusersCopyTo.TabIndex = 20;
            this.listBoxSystemusersCopyTo.Tag = "";
            this.listBoxSystemusersCopyTo.Click += new System.EventHandler(this.ListBoxSystemusersCopyTo_Click);
            // 
            // buttonDisassociate
            // 
            this.buttonDisassociate.Location = new System.Drawing.Point(729, 187);
            this.buttonDisassociate.Name = "buttonDisassociate";
            this.buttonDisassociate.Size = new System.Drawing.Size(215, 36);
            this.buttonDisassociate.TabIndex = 25;
            this.buttonDisassociate.Text = "Disassociate Role(s) ->";
            this.buttonDisassociate.UseVisualStyleBackColor = true;
            this.buttonDisassociate.Click += new System.EventHandler(this.buttonDisassociate_Click);
            // 
            // labelRolesCopyTo
            // 
            this.labelRolesCopyTo.AutoSize = true;
            this.labelRolesCopyTo.Location = new System.Drawing.Point(1303, 70);
            this.labelRolesCopyTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRolesCopyTo.Name = "labelRolesCopyTo";
            this.labelRolesCopyTo.Size = new System.Drawing.Size(50, 20);
            this.labelRolesCopyTo.TabIndex = 23;
            this.labelRolesCopyTo.Text = "Roles";
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Location = new System.Drawing.Point(370, 69);
            this.labelRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(50, 20);
            this.labelRoles.TabIndex = 19;
            this.labelRoles.Text = "Roles";
            // 
            // buttonSynchronize
            // 
            this.buttonSynchronize.Location = new System.Drawing.Point(729, 61);
            this.buttonSynchronize.Name = "buttonSynchronize";
            this.buttonSynchronize.Size = new System.Drawing.Size(215, 36);
            this.buttonSynchronize.TabIndex = 24;
            this.buttonSynchronize.Text = "-- Synchronize Roles -->";
            this.buttonSynchronize.UseVisualStyleBackColor = true;
            this.buttonSynchronize.Click += new System.EventHandler(this.buttonSynchronize_Click);
            // 
            // labelSystemusers
            // 
            this.labelSystemusers.AutoSize = true;
            this.labelSystemusers.Location = new System.Drawing.Point(13, 69);
            this.labelSystemusers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSystemusers.Name = "labelSystemusers";
            this.labelSystemusers.Size = new System.Drawing.Size(101, 20);
            this.labelSystemusers.TabIndex = 18;
            this.labelSystemusers.Text = "Systemusers";
            // 
            // listBoxSystemusers
            // 
            this.listBoxSystemusers.FormattingEnabled = true;
            this.listBoxSystemusers.ItemHeight = 20;
            this.listBoxSystemusers.Location = new System.Drawing.Point(17, 92);
            this.listBoxSystemusers.Name = "listBoxSystemusers";
            this.listBoxSystemusers.ScrollAlwaysVisible = true;
            this.listBoxSystemusers.Size = new System.Drawing.Size(350, 1104);
            this.listBoxSystemusers.Sorted = true;
            this.listBoxSystemusers.TabIndex = 16;
            this.listBoxSystemusers.Tag = "";
            this.listBoxSystemusers.Click += new System.EventHandler(this.ListBoxSystemusers_Click);
            this.listBoxSystemusers.SelectedIndexChanged += new System.EventHandler(this.listBoxSystemusers_SelectedIndexChanged);
            // 
            // buttonAssociate
            // 
            this.buttonAssociate.Location = new System.Drawing.Point(729, 145);
            this.buttonAssociate.Name = "buttonAssociate";
            this.buttonAssociate.Size = new System.Drawing.Size(215, 36);
            this.buttonAssociate.TabIndex = 26;
            this.buttonAssociate.Text = "-- Associate Role(s) ->";
            this.buttonAssociate.UseVisualStyleBackColor = true;
            this.buttonAssociate.Click += new System.EventHandler(this.buttonAssociate_Click);
            // 
            // listBoxRoles
            // 
            this.listBoxRoles.FormattingEnabled = true;
            this.listBoxRoles.ItemHeight = 20;
            this.listBoxRoles.Location = new System.Drawing.Point(373, 92);
            this.listBoxRoles.Name = "listBoxRoles";
            this.listBoxRoles.ScrollAlwaysVisible = true;
            this.listBoxRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxRoles.Size = new System.Drawing.Size(350, 1104);
            this.listBoxRoles.Sorted = true;
            this.listBoxRoles.TabIndex = 17;
            // 
            // txtBoxSystemusersSearch
            // 
            this.txtBoxSystemusersSearch.Location = new System.Drawing.Point(84, 34);
            this.txtBoxSystemusersSearch.Name = "txtBoxSystemusersSearch";
            this.txtBoxSystemusersSearch.Size = new System.Drawing.Size(283, 26);
            this.txtBoxSystemusersSearch.TabIndex = 27;
            this.txtBoxSystemusersSearch.TextChanged += new System.EventHandler(this.txtBoxSystemusersSearch_TextChanged);
            // 
            // lblSystemuserSearch
            // 
            this.lblSystemuserSearch.Location = new System.Drawing.Point(13, 37);
            this.lblSystemuserSearch.Name = "lblSystemuserSearch";
            this.lblSystemuserSearch.Size = new System.Drawing.Size(68, 26);
            this.lblSystemuserSearch.TabIndex = 0;
            this.lblSystemuserSearch.Text = "Search:";
            // 
            // txtBoxSystemusersCopyToSearch
            // 
            this.txtBoxSystemusersCopyToSearch.Location = new System.Drawing.Point(1017, 37);
            this.txtBoxSystemusersCopyToSearch.Name = "txtBoxSystemusersCopyToSearch";
            this.txtBoxSystemusersCopyToSearch.Size = new System.Drawing.Size(283, 26);
            this.txtBoxSystemusersCopyToSearch.TabIndex = 29;
            this.txtBoxSystemusersCopyToSearch.TextChanged += new System.EventHandler(this.txtBoxSystemusersCopyToSearch_TextChanged);
            // 
            // lblSystemusersCopyToSearch
            // 
            this.lblSystemusersCopyToSearch.Location = new System.Drawing.Point(946, 40);
            this.lblSystemusersCopyToSearch.Name = "lblSystemusersCopyToSearch";
            this.lblSystemusersCopyToSearch.Size = new System.Drawing.Size(68, 26);
            this.lblSystemusersCopyToSearch.TabIndex = 28;
            this.lblSystemusersCopyToSearch.Text = "Search:";
            // 
            // checkBoxInactive
            // 
            this.checkBoxInactive.AutoSize = true;
            this.checkBoxInactive.Location = new System.Drawing.Point(729, 274);
            this.checkBoxInactive.Name = "checkBoxInactive";
            this.checkBoxInactive.Size = new System.Drawing.Size(138, 24);
            this.checkBoxInactive.TabIndex = 30;
            this.checkBoxInactive.Text = "Show disabled";
            this.checkBoxInactive.UseVisualStyleBackColor = true;
            this.checkBoxInactive.CheckedChanged += new System.EventHandler(this.checkBoxInactive_CheckedChanged);
            // 
            // checkBoxSystemuser
            // 
            this.checkBoxSystemuser.AutoSize = true;
            this.checkBoxSystemuser.Location = new System.Drawing.Point(729, 304);
            this.checkBoxSystemuser.Name = "checkBoxSystemuser";
            this.checkBoxSystemuser.Size = new System.Drawing.Size(163, 24);
            this.checkBoxSystemuser.TabIndex = 31;
            this.checkBoxSystemuser.Text = "Show Systemuser";
            this.checkBoxSystemuser.UseVisualStyleBackColor = true;
            this.checkBoxSystemuser.Visible = false;
            this.checkBoxSystemuser.CheckedChanged += new System.EventHandler(this.checkBoxSystemuser_CheckedChanged);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxSystemuser);
            this.Controls.Add(this.checkBoxInactive);
            this.Controls.Add(this.lblSystemusersCopyToSearch);
            this.Controls.Add(this.txtBoxSystemusersCopyToSearch);
            this.Controls.Add(this.lblSystemuserSearch);
            this.Controls.Add(this.txtBoxSystemusersSearch);
            this.Controls.Add(this.listBoxRoles);
            this.Controls.Add(this.buttonAssociate);
            this.Controls.Add(this.listBoxSystemusers);
            this.Controls.Add(this.buttonDisassociate);
            this.Controls.Add(this.labelSystemusers);
            this.Controls.Add(this.buttonSynchronize);
            this.Controls.Add(this.labelRoles);
            this.Controls.Add(this.labelRolesCopyTo);
            this.Controls.Add(this.listBoxSystemusersCopyTo);
            this.Controls.Add(this.listBoxRolesCopyTo);
            this.Controls.Add(this.labelSystemusersCopyTo);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1848, 1226);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tSB_RetrieveAll;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Label labelSystemusersCopyTo;
        private System.Windows.Forms.ListBox listBoxRolesCopyTo;
        private System.Windows.Forms.ListBox listBoxSystemusersCopyTo;
        private System.Windows.Forms.Button buttonDisassociate;
        private System.Windows.Forms.Label labelRolesCopyTo;
        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button buttonSynchronize;
        private System.Windows.Forms.Label labelSystemusers;
        private System.Windows.Forms.ListBox listBoxSystemusers;
        private System.Windows.Forms.Button buttonAssociate;
        private System.Windows.Forms.ListBox listBoxRoles;
        private System.Windows.Forms.TextBox txtBoxSystemusersSearch;
        private System.Windows.Forms.Label lblSystemuserSearch;
        private System.Windows.Forms.TextBox txtBoxSystemusersCopyToSearch;
        private System.Windows.Forms.Label lblSystemusersCopyToSearch;
        private System.Windows.Forms.CheckBox checkBoxInactive;
        private System.Windows.Forms.CheckBox checkBoxSystemuser;
    }
}
