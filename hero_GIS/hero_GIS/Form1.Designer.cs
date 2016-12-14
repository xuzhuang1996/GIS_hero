namespace hero_GIS
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("图层");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.区编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.full_extent = new System.Windows.Forms.Button();
            this.zuobiao = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图层ToolStripMenuItem,
            this.新建图层ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // 添加图层ToolStripMenuItem
            // 
            this.添加图层ToolStripMenuItem.Name = "添加图层ToolStripMenuItem";
            this.添加图层ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加图层ToolStripMenuItem.Text = "添加图层";
            this.添加图层ToolStripMenuItem.Click += new System.EventHandler(this.添加图层ToolStripMenuItem_Click);
            // 
            // 新建图层ToolStripMenuItem
            // 
            this.新建图层ToolStripMenuItem.Name = "新建图层ToolStripMenuItem";
            this.新建图层ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新建图层ToolStripMenuItem.Text = "新建图层";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.重命名ToolStripMenuItem.Text = "关闭所有图层";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.点编辑ToolStripMenuItem,
            this.线编辑ToolStripMenuItem,
            this.区编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 点编辑ToolStripMenuItem
            // 
            this.点编辑ToolStripMenuItem.Name = "点编辑ToolStripMenuItem";
            this.点编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.点编辑ToolStripMenuItem.Text = "点编辑";
            // 
            // 线编辑ToolStripMenuItem
            // 
            this.线编辑ToolStripMenuItem.Name = "线编辑ToolStripMenuItem";
            this.线编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.线编辑ToolStripMenuItem.Text = "线编辑";
            // 
            // 区编辑ToolStripMenuItem
            // 
            this.区编辑ToolStripMenuItem.Name = "区编辑ToolStripMenuItem";
            this.区编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.区编辑ToolStripMenuItem.Text = "区编辑";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目录树";
            // 
            // treeView
            // 
            this.treeView.CheckBoxes = true;
            this.treeView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.Location = new System.Drawing.Point(14, 86);
            this.treeView.Name = "treeView";
            treeNode2.ContextMenuStrip = this.contextMenuStrip1;
            treeNode2.Name = "节点1";
            treeNode2.Text = "图层";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView.Size = new System.Drawing.Size(122, 338);
            this.treeView.TabIndex = 2;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(195, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 424);
            this.panel1.TabIndex = 3;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除ToolStripMenuItem,
            this.打开属性表ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(137, 48);
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(59, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 31);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // full_extent
            // 
            this.full_extent.BackColor = System.Drawing.SystemColors.Window;
            this.full_extent.Image = ((System.Drawing.Image)(resources.GetObject("full_extent.Image")));
            this.full_extent.Location = new System.Drawing.Point(91, 28);
            this.full_extent.Name = "full_extent";
            this.full_extent.Size = new System.Drawing.Size(26, 31);
            this.full_extent.TabIndex = 5;
            this.full_extent.UseVisualStyleBackColor = false;
            this.full_extent.Click += new System.EventHandler(this.full_extent_Click);
            // 
            // zuobiao
            // 
            this.zuobiao.AutoSize = true;
            this.zuobiao.Location = new System.Drawing.Point(686, 492);
            this.zuobiao.Name = "zuobiao";
            this.zuobiao.Size = new System.Drawing.Size(53, 12);
            this.zuobiao.TabIndex = 6;
            this.zuobiao.Text = "当前坐标";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(859, 521);
            this.Controls.Add(this.zuobiao);
            this.Controls.Add(this.full_extent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 区编辑ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button full_extent;
        private System.Windows.Forms.Label zuobiao;
    }
}

