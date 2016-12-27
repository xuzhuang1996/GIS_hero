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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("图层");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.区编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.要素编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.full_extent = new System.Windows.Forms.Button();
            this.zuobiao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
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
            this.新建图层ToolStripMenuItem.Click += new System.EventHandler(this.新建图层ToolStripMenuItem_Click);
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
            this.点编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入点ToolStripMenuItem});
            this.点编辑ToolStripMenuItem.Name = "点编辑ToolStripMenuItem";
            this.点编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.点编辑ToolStripMenuItem.Text = "点编辑";
            // 
            // 输入点ToolStripMenuItem
            // 
            this.输入点ToolStripMenuItem.Enabled = false;
            this.输入点ToolStripMenuItem.Name = "输入点ToolStripMenuItem";
            this.输入点ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.输入点ToolStripMenuItem.Text = "输入点";
            this.输入点ToolStripMenuItem.Click += new System.EventHandler(this.输入点ToolStripMenuItem_Click);
            // 
            // 线编辑ToolStripMenuItem
            // 
            this.线编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入线ToolStripMenuItem});
            this.线编辑ToolStripMenuItem.Name = "线编辑ToolStripMenuItem";
            this.线编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.线编辑ToolStripMenuItem.Text = "线编辑";
            // 
            // 输入线ToolStripMenuItem
            // 
            this.输入线ToolStripMenuItem.Enabled = false;
            this.输入线ToolStripMenuItem.Name = "输入线ToolStripMenuItem";
            this.输入线ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.输入线ToolStripMenuItem.Text = "输入线";
            this.输入线ToolStripMenuItem.Click += new System.EventHandler(this.输入线ToolStripMenuItem_Click);
            // 
            // 区编辑ToolStripMenuItem
            // 
            this.区编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入区ToolStripMenuItem});
            this.区编辑ToolStripMenuItem.Name = "区编辑ToolStripMenuItem";
            this.区编辑ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.区编辑ToolStripMenuItem.Text = "区编辑";
            this.区编辑ToolStripMenuItem.Click += new System.EventHandler(this.区编辑ToolStripMenuItem_Click);
            // 
            // 输入区ToolStripMenuItem
            // 
            this.输入区ToolStripMenuItem.Enabled = false;
            this.输入区ToolStripMenuItem.Name = "输入区ToolStripMenuItem";
            this.输入区ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.输入区ToolStripMenuItem.Text = "输入区";
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
            treeNode1.ContextMenuStrip = this.contextMenuStrip1;
            treeNode1.Name = "节点1";
            treeNode1.Text = "图层";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.Size = new System.Drawing.Size(122, 399);
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
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除ToolStripMenuItem,
            this.打开属性表ToolStripMenuItem,
            this.属性ToolStripMenuItem,
            this.要素编辑ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(137, 92);
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
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            // 
            // 要素编辑ToolStripMenuItem
            // 
            this.要素编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem,
            this.结束编辑ToolStripMenuItem});
            this.要素编辑ToolStripMenuItem.Name = "要素编辑ToolStripMenuItem";
            this.要素编辑ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.要素编辑ToolStripMenuItem.Text = "要素编辑";
            // 
            // 开始编辑ToolStripMenuItem
            // 
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始编辑ToolStripMenuItem.Text = "开始编辑";
            this.开始编辑ToolStripMenuItem.Click += new System.EventHandler(this.开始编辑ToolStripMenuItem_Click);
            // 
            // 结束编辑ToolStripMenuItem
            // 
            this.结束编辑ToolStripMenuItem.Name = "结束编辑ToolStripMenuItem";
            this.结束编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结束编辑ToolStripMenuItem.Text = "结束编辑";
            this.结束编辑ToolStripMenuItem.Click += new System.EventHandler(this.结束编辑ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(25, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 31);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // full_extent
            // 
            this.full_extent.BackColor = System.Drawing.SystemColors.Window;
            this.full_extent.Image = ((System.Drawing.Image)(resources.GetObject("full_extent.Image")));
            this.full_extent.Location = new System.Drawing.Point(57, 28);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "实际";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(89, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 31);
            this.button2.TabIndex = 8;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(121, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 31);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(153, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 31);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Window;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(185, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 31);
            this.button5.TabIndex = 10;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(859, 521);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem 输入点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入区ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 要素编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束编辑ToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

