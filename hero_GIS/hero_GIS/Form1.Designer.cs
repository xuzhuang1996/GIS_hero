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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开工程或文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.添加字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出shapefile格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图层ToolStripMenuItem,
            this.新建图层ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // 添加图层ToolStripMenuItem
            // 
            resources.ApplyResources(this.添加图层ToolStripMenuItem, "添加图层ToolStripMenuItem");
            this.添加图层ToolStripMenuItem.Name = "添加图层ToolStripMenuItem";
            this.添加图层ToolStripMenuItem.Click += new System.EventHandler(this.添加图层ToolStripMenuItem_Click);
            // 
            // 新建图层ToolStripMenuItem
            // 
            resources.ApplyResources(this.新建图层ToolStripMenuItem, "新建图层ToolStripMenuItem");
            this.新建图层ToolStripMenuItem.Name = "新建图层ToolStripMenuItem";
            this.新建图层ToolStripMenuItem.Click += new System.EventHandler(this.新建图层ToolStripMenuItem_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            resources.ApplyResources(this.重命名ToolStripMenuItem, "重命名ToolStripMenuItem");
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.点编辑ToolStripMenuItem,
            this.线编辑ToolStripMenuItem,
            this.区编辑ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建工程ToolStripMenuItem,
            this.新建文件ToolStripMenuItem,
            this.打开工程或文件ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            // 
            // 新建工程ToolStripMenuItem
            // 
            resources.ApplyResources(this.新建工程ToolStripMenuItem, "新建工程ToolStripMenuItem");
            this.新建工程ToolStripMenuItem.Name = "新建工程ToolStripMenuItem";
            // 
            // 新建文件ToolStripMenuItem
            // 
            resources.ApplyResources(this.新建文件ToolStripMenuItem, "新建文件ToolStripMenuItem");
            this.新建文件ToolStripMenuItem.Name = "新建文件ToolStripMenuItem";
            // 
            // 打开工程或文件ToolStripMenuItem
            // 
            resources.ApplyResources(this.打开工程或文件ToolStripMenuItem, "打开工程或文件ToolStripMenuItem");
            this.打开工程或文件ToolStripMenuItem.Name = "打开工程或文件ToolStripMenuItem";
            // 
            // 退出系统ToolStripMenuItem
            // 
            resources.ApplyResources(this.退出系统ToolStripMenuItem, "退出系统ToolStripMenuItem");
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            // 
            // 点编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.点编辑ToolStripMenuItem, "点编辑ToolStripMenuItem");
            this.点编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入点ToolStripMenuItem});
            this.点编辑ToolStripMenuItem.Name = "点编辑ToolStripMenuItem";
            // 
            // 输入点ToolStripMenuItem
            // 
            resources.ApplyResources(this.输入点ToolStripMenuItem, "输入点ToolStripMenuItem");
            this.输入点ToolStripMenuItem.Name = "输入点ToolStripMenuItem";
            this.输入点ToolStripMenuItem.Click += new System.EventHandler(this.输入点ToolStripMenuItem_Click);
            // 
            // 线编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.线编辑ToolStripMenuItem, "线编辑ToolStripMenuItem");
            this.线编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入线ToolStripMenuItem});
            this.线编辑ToolStripMenuItem.Name = "线编辑ToolStripMenuItem";
            // 
            // 输入线ToolStripMenuItem
            // 
            resources.ApplyResources(this.输入线ToolStripMenuItem, "输入线ToolStripMenuItem");
            this.输入线ToolStripMenuItem.Name = "输入线ToolStripMenuItem";
            this.输入线ToolStripMenuItem.Click += new System.EventHandler(this.输入线ToolStripMenuItem_Click);
            // 
            // 区编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.区编辑ToolStripMenuItem, "区编辑ToolStripMenuItem");
            this.区编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入区ToolStripMenuItem});
            this.区编辑ToolStripMenuItem.Name = "区编辑ToolStripMenuItem";
            this.区编辑ToolStripMenuItem.Click += new System.EventHandler(this.区编辑ToolStripMenuItem_Click);
            // 
            // 输入区ToolStripMenuItem
            // 
            resources.ApplyResources(this.输入区ToolStripMenuItem, "输入区ToolStripMenuItem");
            this.输入区ToolStripMenuItem.Name = "输入区ToolStripMenuItem";
            this.输入区ToolStripMenuItem.Click += new System.EventHandler(this.输入区ToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // treeView
            // 
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.CheckBoxes = true;
            this.treeView.Name = "treeView";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes")))});
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // contextMenuStrip2
            // 
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除ToolStripMenuItem,
            this.打开属性表ToolStripMenuItem,
            this.属性ToolStripMenuItem,
            this.要素编辑ToolStripMenuItem,
            this.添加字段ToolStripMenuItem,
            this.导出shapefile格式ToolStripMenuItem,
            this.修改颜色ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            // 
            // 移除ToolStripMenuItem
            // 
            resources.ApplyResources(this.移除ToolStripMenuItem, "移除ToolStripMenuItem");
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            resources.ApplyResources(this.打开属性表ToolStripMenuItem, "打开属性表ToolStripMenuItem");
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            // 
            // 属性ToolStripMenuItem
            // 
            resources.ApplyResources(this.属性ToolStripMenuItem, "属性ToolStripMenuItem");
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 要素编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.要素编辑ToolStripMenuItem, "要素编辑ToolStripMenuItem");
            this.要素编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem,
            this.结束编辑ToolStripMenuItem});
            this.要素编辑ToolStripMenuItem.Name = "要素编辑ToolStripMenuItem";
            // 
            // 开始编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.开始编辑ToolStripMenuItem, "开始编辑ToolStripMenuItem");
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Click += new System.EventHandler(this.开始编辑ToolStripMenuItem_Click);
            // 
            // 结束编辑ToolStripMenuItem
            // 
            resources.ApplyResources(this.结束编辑ToolStripMenuItem, "结束编辑ToolStripMenuItem");
            this.结束编辑ToolStripMenuItem.Name = "结束编辑ToolStripMenuItem";
            this.结束编辑ToolStripMenuItem.Click += new System.EventHandler(this.结束编辑ToolStripMenuItem_Click);
            // 
            // 添加字段ToolStripMenuItem
            // 
            resources.ApplyResources(this.添加字段ToolStripMenuItem, "添加字段ToolStripMenuItem");
            this.添加字段ToolStripMenuItem.Name = "添加字段ToolStripMenuItem";
            this.添加字段ToolStripMenuItem.Click += new System.EventHandler(this.添加字段ToolStripMenuItem_Click);
            // 
            // 导出shapefile格式ToolStripMenuItem
            // 
            resources.ApplyResources(this.导出shapefile格式ToolStripMenuItem, "导出shapefile格式ToolStripMenuItem");
            this.导出shapefile格式ToolStripMenuItem.Name = "导出shapefile格式ToolStripMenuItem";
            // 
            // 修改颜色ToolStripMenuItem
            // 
            resources.ApplyResources(this.修改颜色ToolStripMenuItem, "修改颜色ToolStripMenuItem");
            this.修改颜色ToolStripMenuItem.Name = "修改颜色ToolStripMenuItem";
            this.修改颜色ToolStripMenuItem.Click += new System.EventHandler(this.修改颜色ToolStripMenuItem_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // full_extent
            // 
            resources.ApplyResources(this.full_extent, "full_extent");
            this.full_extent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.full_extent.Name = "full_extent";
            this.full_extent.UseVisualStyleBackColor = false;
            this.full_extent.Click += new System.EventHandler(this.full_extent_Click);
            // 
            // zuobiao
            // 
            resources.ApplyResources(this.zuobiao, "zuobiao");
            this.zuobiao.Name = "zuobiao";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
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
        private System.Windows.Forms.ToolStripMenuItem 添加字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开工程或文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出shapefile格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改颜色ToolStripMenuItem;
    }
}

