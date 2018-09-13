namespace fuzzxmlgen
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox_AttrSingleQuote = new System.Windows.Forms.CheckBox();
            this.checkBox_Indent = new System.Windows.Forms.CheckBox();
            this.checkBox_LineBreakBeforeAttr = new System.Windows.Forms.CheckBox();
            this.checkBox_LineBreakBeforeAttr_CR = new System.Windows.Forms.CheckBox();
            this.checkBox_LineBreakBeforeAttr_LF = new System.Windows.Forms.CheckBox();
            this.radioButton_Indent_space = new System.Windows.Forms.RadioButton();
            this.radioButton_Indent_tab = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 140);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(260, 110);
            this.textBox1.TabIndex = 0;
            // 
            // checkBox_AttrSingleQuote
            // 
            this.checkBox_AttrSingleQuote.AutoSize = true;
            this.checkBox_AttrSingleQuote.Location = new System.Drawing.Point(12, 41);
            this.checkBox_AttrSingleQuote.Name = "checkBox_AttrSingleQuote";
            this.checkBox_AttrSingleQuote.Size = new System.Drawing.Size(105, 16);
            this.checkBox_AttrSingleQuote.TabIndex = 1;
            this.checkBox_AttrSingleQuote.Text = "AttrSingleQuote";
            this.checkBox_AttrSingleQuote.UseVisualStyleBackColor = true;
            // 
            // checkBox_Indent
            // 
            this.checkBox_Indent.AutoSize = true;
            this.checkBox_Indent.Location = new System.Drawing.Point(12, 63);
            this.checkBox_Indent.Name = "checkBox_Indent";
            this.checkBox_Indent.Size = new System.Drawing.Size(55, 16);
            this.checkBox_Indent.TabIndex = 2;
            this.checkBox_Indent.Text = "Indent";
            this.checkBox_Indent.UseVisualStyleBackColor = true;
            // 
            // checkBox_LineBreakBeforeAttr
            // 
            this.checkBox_LineBreakBeforeAttr.AutoSize = true;
            this.checkBox_LineBreakBeforeAttr.Location = new System.Drawing.Point(12, 85);
            this.checkBox_LineBreakBeforeAttr.Name = "checkBox_LineBreakBeforeAttr";
            this.checkBox_LineBreakBeforeAttr.Size = new System.Drawing.Size(129, 16);
            this.checkBox_LineBreakBeforeAttr.TabIndex = 3;
            this.checkBox_LineBreakBeforeAttr.Text = "LineBreakBeforeAttr";
            this.checkBox_LineBreakBeforeAttr.UseVisualStyleBackColor = true;
            // 
            // checkBox_LineBreakBeforeAttr_CR
            // 
            this.checkBox_LineBreakBeforeAttr_CR.AutoSize = true;
            this.checkBox_LineBreakBeforeAttr_CR.Location = new System.Drawing.Point(159, 85);
            this.checkBox_LineBreakBeforeAttr_CR.Name = "checkBox_LineBreakBeforeAttr_CR";
            this.checkBox_LineBreakBeforeAttr_CR.Size = new System.Drawing.Size(40, 16);
            this.checkBox_LineBreakBeforeAttr_CR.TabIndex = 4;
            this.checkBox_LineBreakBeforeAttr_CR.Text = "CR";
            this.checkBox_LineBreakBeforeAttr_CR.UseVisualStyleBackColor = true;
            // 
            // checkBox_LineBreakBeforeAttr_LF
            // 
            this.checkBox_LineBreakBeforeAttr_LF.AutoSize = true;
            this.checkBox_LineBreakBeforeAttr_LF.Location = new System.Drawing.Point(215, 85);
            this.checkBox_LineBreakBeforeAttr_LF.Name = "checkBox_LineBreakBeforeAttr_LF";
            this.checkBox_LineBreakBeforeAttr_LF.Size = new System.Drawing.Size(37, 16);
            this.checkBox_LineBreakBeforeAttr_LF.TabIndex = 4;
            this.checkBox_LineBreakBeforeAttr_LF.Text = "LF";
            this.checkBox_LineBreakBeforeAttr_LF.UseVisualStyleBackColor = true;
            // 
            // radioButton_Indent_space
            // 
            this.radioButton_Indent_space.AutoSize = true;
            this.radioButton_Indent_space.Checked = true;
            this.radioButton_Indent_space.Location = new System.Drawing.Point(0, 0);
            this.radioButton_Indent_space.Name = "radioButton_Indent_space";
            this.radioButton_Indent_space.Size = new System.Drawing.Size(53, 16);
            this.radioButton_Indent_space.TabIndex = 0;
            this.radioButton_Indent_space.TabStop = true;
            this.radioButton_Indent_space.Text = "space";
            this.radioButton_Indent_space.UseVisualStyleBackColor = true;
            // 
            // radioButton_Indent_tab
            // 
            this.radioButton_Indent_tab.AutoSize = true;
            this.radioButton_Indent_tab.Location = new System.Drawing.Point(73, 0);
            this.radioButton_Indent_tab.Name = "radioButton_Indent_tab";
            this.radioButton_Indent_tab.Size = new System.Drawing.Size(39, 16);
            this.radioButton_Indent_tab.TabIndex = 0;
            this.radioButton_Indent_tab.TabStop = true;
            this.radioButton_Indent_tab.Text = "tab";
            this.radioButton_Indent_tab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_Indent_tab);
            this.panel1.Controls.Add(this.radioButton_Indent_space);
            this.panel1.Location = new System.Drawing.Point(147, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 16);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox_LineBreakBeforeAttr_LF);
            this.Controls.Add(this.checkBox_LineBreakBeforeAttr_CR);
            this.Controls.Add(this.checkBox_LineBreakBeforeAttr);
            this.Controls.Add(this.checkBox_Indent);
            this.Controls.Add(this.checkBox_AttrSingleQuote);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox_AttrSingleQuote;
        private System.Windows.Forms.CheckBox checkBox_Indent;
        private System.Windows.Forms.CheckBox checkBox_LineBreakBeforeAttr;
        private System.Windows.Forms.CheckBox checkBox_LineBreakBeforeAttr_CR;
        private System.Windows.Forms.CheckBox checkBox_LineBreakBeforeAttr_LF;
        private System.Windows.Forms.RadioButton radioButton_Indent_tab;
        private System.Windows.Forms.RadioButton radioButton_Indent_space;
        private System.Windows.Forms.Panel panel1;
    }
}

