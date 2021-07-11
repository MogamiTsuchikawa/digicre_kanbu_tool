namespace OneDriveSlideUploader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectCheckBtn = new System.Windows.Forms.Button();
            this.connectStatusLabel = new System.Windows.Forms.Label();
            this.resultWindowOpenBtn = new System.Windows.Forms.Button();
            this.slideListView = new System.Windows.Forms.ListView();
            this.fileName = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(121, 6);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(372, 31);
            this.pathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "対象PATH";
            // 
            // connectCheckBtn
            // 
            this.connectCheckBtn.Location = new System.Drawing.Point(499, 4);
            this.connectCheckBtn.Name = "connectCheckBtn";
            this.connectCheckBtn.Size = new System.Drawing.Size(112, 34);
            this.connectCheckBtn.TabIndex = 2;
            this.connectCheckBtn.Text = "確認";
            this.connectCheckBtn.UseVisualStyleBackColor = true;
            this.connectCheckBtn.Click += new System.EventHandler(this.connectCheckBtn_Click);
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.AutoSize = true;
            this.connectStatusLabel.Location = new System.Drawing.Point(644, 9);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(66, 25);
            this.connectStatusLabel.TabIndex = 3;
            this.connectStatusLabel.Text = "未接続";
            // 
            // resultWindowOpenBtn
            // 
            this.resultWindowOpenBtn.Location = new System.Drawing.Point(621, 404);
            this.resultWindowOpenBtn.Name = "resultWindowOpenBtn";
            this.resultWindowOpenBtn.Size = new System.Drawing.Size(112, 34);
            this.resultWindowOpenBtn.TabIndex = 5;
            this.resultWindowOpenBtn.Text = "結果表示";
            this.resultWindowOpenBtn.UseVisualStyleBackColor = true;
            // 
            // slideListView
            // 
            this.slideListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.status});
            this.slideListView.FullRowSelect = true;
            this.slideListView.GridLines = true;
            this.slideListView.HideSelection = false;
            this.slideListView.Location = new System.Drawing.Point(29, 43);
            this.slideListView.Name = "slideListView";
            this.slideListView.Size = new System.Drawing.Size(747, 355);
            this.slideListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.slideListView.TabIndex = 6;
            this.slideListView.UseCompatibleStateImageBehavior = false;
            this.slideListView.View = System.Windows.Forms.View.Details;
            // 
            // fileName
            // 
            this.fileName.Text = "対象ファイル名";
            this.fileName.Width = 600;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.slideListView);
            this.Controls.Add(this.resultWindowOpenBtn);
            this.Controls.Add(this.connectStatusLabel);
            this.Controls.Add(this.connectCheckBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Name = "Form1";
            this.Text = "スライドアップローダー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectCheckBtn;
        private System.Windows.Forms.Label connectStatusLabel;
        private System.Windows.Forms.Button resultWindowOpenBtn;
        private System.Windows.Forms.ListView slideListView;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader status;
    }
}

