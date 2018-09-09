namespace WindowsFormsApp {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.openPresenterButton = new System.Windows.Forms.Button();
            this.createUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openPresenterButton
            // 
            this.openPresenterButton.Location = new System.Drawing.Point(12, 12);
            this.openPresenterButton.Name = "openPresenterButton";
            this.openPresenterButton.Size = new System.Drawing.Size(112, 23);
            this.openPresenterButton.TabIndex = 0;
            this.openPresenterButton.Text = "Open Presenter";
            this.openPresenterButton.UseVisualStyleBackColor = true;
            this.openPresenterButton.Click += new System.EventHandler(this.openPresenterButton_Click);
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(130, 12);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(112, 23);
            this.createUserButton.TabIndex = 1;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 45);
            this.Controls.Add(this.createUserButton);
            this.Controls.Add(this.openPresenterButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openPresenterButton;
        private System.Windows.Forms.Button createUserButton;
    }
}

