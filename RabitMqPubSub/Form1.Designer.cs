namespace RabitMqPubSub
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnSendDirect = new System.Windows.Forms.Button();
            this.cbTopic = new System.Windows.Forms.ComboBox();
            this.lbMarquee = new System.Windows.Forms.Label();
            this.trMargueeMessaage = new System.Windows.Forms.Timer(this.components);
            this.btnSendFanout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(101, 14);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(122, 21);
            this.tbMessage.TabIndex = 0;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 65);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(292, 220);
            this.tbOutput.TabIndex = 1;
            // 
            // btnSendDirect
            // 
            this.btnSendDirect.Location = new System.Drawing.Point(229, 12);
            this.btnSendDirect.Name = "btnSendDirect";
            this.btnSendDirect.Size = new System.Drawing.Size(75, 23);
            this.btnSendDirect.TabIndex = 2;
            this.btnSendDirect.Text = "SendDirect";
            this.btnSendDirect.UseVisualStyleBackColor = true;
            this.btnSendDirect.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbTopic
            // 
            this.cbTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopic.Font = new System.Drawing.Font("新細明體", 10F);
            this.cbTopic.FormattingEnabled = true;
            this.cbTopic.Items.AddRange(new object[] {
            "Message",
            "Title"});
            this.cbTopic.Location = new System.Drawing.Point(12, 14);
            this.cbTopic.Name = "cbTopic";
            this.cbTopic.Size = new System.Drawing.Size(83, 21);
            this.cbTopic.TabIndex = 3;
            // 
            // lbMarquee
            // 
            this.lbMarquee.AutoSize = true;
            this.lbMarquee.Location = new System.Drawing.Point(14, 44);
            this.lbMarquee.Name = "lbMarquee";
            this.lbMarquee.Size = new System.Drawing.Size(47, 12);
            this.lbMarquee.TabIndex = 4;
            this.lbMarquee.Text = "Marquee";
            // 
            // trMargueeMessaage
            // 
            this.trMargueeMessaage.Interval = 1;
            this.trMargueeMessaage.Tick += new System.EventHandler(this.trMargueeMessaage_Tick);
            // 
            // btnSendFanout
            // 
            this.btnSendFanout.Location = new System.Drawing.Point(229, 33);
            this.btnSendFanout.Name = "btnSendFanout";
            this.btnSendFanout.Size = new System.Drawing.Size(75, 23);
            this.btnSendFanout.TabIndex = 5;
            this.btnSendFanout.Text = "SendFanout";
            this.btnSendFanout.UseVisualStyleBackColor = true;
            this.btnSendFanout.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 297);
            this.Controls.Add(this.btnSendFanout);
            this.Controls.Add(this.lbMarquee);
            this.Controls.Add(this.cbTopic);
            this.Controls.Add(this.btnSendDirect);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnSendDirect;
        private System.Windows.Forms.ComboBox cbTopic;
        private System.Windows.Forms.Label lbMarquee;
        private System.Windows.Forms.Timer trMargueeMessaage;
        private System.Windows.Forms.Button btnSendFanout;
    }
}

