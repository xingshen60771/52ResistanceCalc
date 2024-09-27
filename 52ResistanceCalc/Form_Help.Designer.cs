namespace _52ResistanceCalc
{
    partial class Form_Help
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("软件介绍");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("如何使用");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("特色功能1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("特色功能2");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("使用方法", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("电阻知识");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("色环含义图");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("知识库", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("常见问题解答");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("特别注意");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("关于");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("帮助文档", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tree_Help = new System.Windows.Forms.TreeView();
            this.web_HelpView = new System.Windows.Forms.WebBrowser();
            this.label_UnPack = new System.Windows.Forms.Label();
            this.progressBar_UnPack = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tree_Help);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.web_HelpView);
            this.splitContainer.Size = new System.Drawing.Size(1262, 913);
            this.splitContainer.SplitterDistance = 278;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.Visible = false;
            // 
            // tree_Help
            // 
            this.tree_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_Help.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tree_Help.Location = new System.Drawing.Point(0, 0);
            this.tree_Help.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tree_Help.Name = "tree_Help";
            treeNode1.Name = "softinfo";
            treeNode1.Text = "软件介绍";
            treeNode2.Name = "HowToUse01";
            treeNode2.Text = "如何使用";
            treeNode3.Name = "HowToUse02";
            treeNode3.Text = "特色功能1";
            treeNode4.Name = "HowToUse03";
            treeNode4.Text = "特色功能2";
            treeNode5.Name = "HowToUse";
            treeNode5.Text = "使用方法";
            treeNode6.Name = "Knowledge01";
            treeNode6.Text = "电阻知识";
            treeNode7.Name = "Knowledge02";
            treeNode7.Tag = "";
            treeNode7.Text = "色环含义图";
            treeNode8.Name = "Knowledge";
            treeNode8.Text = "知识库";
            treeNode9.Name = "FAQ";
            treeNode9.Text = "常见问题解答";
            treeNode10.Name = "attention";
            treeNode10.Text = "特别注意";
            treeNode11.Name = "about";
            treeNode11.Text = "关于";
            treeNode12.Name = "MainHelp";
            treeNode12.Text = "帮助文档";
            this.tree_Help.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.tree_Help.Size = new System.Drawing.Size(278, 913);
            this.tree_Help.TabIndex = 4;
            this.tree_Help.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Help_AfterSelect);
            // 
            // web_HelpView
            // 
            this.web_HelpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_HelpView.Location = new System.Drawing.Point(0, 0);
            this.web_HelpView.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_HelpView.Name = "web_HelpView";
            this.web_HelpView.Size = new System.Drawing.Size(980, 913);
            this.web_HelpView.TabIndex = 0;
            // 
            // label_UnPack
            // 
            this.label_UnPack.Font = new System.Drawing.Font("宋体", 12F);
            this.label_UnPack.ForeColor = System.Drawing.Color.Blue;
            this.label_UnPack.Location = new System.Drawing.Point(0, 0);
            this.label_UnPack.Name = "label_UnPack";
            this.label_UnPack.Size = new System.Drawing.Size(100, 25);
            this.label_UnPack.TabIndex = 1;
            this.label_UnPack.Text = "label1";
            this.label_UnPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar_UnPack
            // 
            this.progressBar_UnPack.Location = new System.Drawing.Point(0, 25);
            this.progressBar_UnPack.Name = "progressBar_UnPack";
            this.progressBar_UnPack.Size = new System.Drawing.Size(100, 23);
            this.progressBar_UnPack.TabIndex = 2;
            // 
            // Form_Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 913);
            this.Controls.Add(this.progressBar_UnPack);
            this.Controls.Add(this.label_UnPack);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Help";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "《吾爱算电阻》帮助文档";
            this.Activated += new System.EventHandler(this.Form_Help_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Help_FormClosed);
            this.Load += new System.EventHandler(this.Form_Help_Load);
            this.SizeChanged += new System.EventHandler(this.Form_Help_SizeChanged);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView tree_Help;
        private System.Windows.Forms.Label label_UnPack;
        private System.Windows.Forms.ProgressBar progressBar_UnPack;
        public System.Windows.Forms.WebBrowser web_HelpView;
    }
}