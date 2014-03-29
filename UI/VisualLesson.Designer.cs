namespace Susie
{
    partial class VisualLesson
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.topLabel = new System.Windows.Forms.Label();
            this.bottomLabel = new System.Windows.Forms.Label();
            this.middleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Location = new System.Drawing.Point(-1, 3);
            this.topLabel.Margin = new System.Windows.Forms.Padding(0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(35, 13);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "label1";
            // 
            // bottomLabel
            // 
            this.bottomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomLabel.AutoSize = true;
            this.bottomLabel.Location = new System.Drawing.Point(-1, 16);
            this.bottomLabel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomLabel.Name = "bottomLabel";
            this.bottomLabel.Size = new System.Drawing.Size(35, 13);
            this.bottomLabel.TabIndex = 1;
            this.bottomLabel.Text = "label2";
            // 
            // middleLabel
            // 
            this.middleLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.middleLabel.AutoSize = true;
            this.middleLabel.Location = new System.Drawing.Point(100, 16);
            this.middleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.middleLabel.Name = "middleLabel";
            this.middleLabel.Size = new System.Drawing.Size(35, 13);
            this.middleLabel.TabIndex = 2;
            this.middleLabel.Text = "label1";
            // 
            // VisualLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.middleLabel);
            this.Controls.Add(this.bottomLabel);
            this.Controls.Add(this.topLabel);
            this.Name = "VisualLesson";
            this.Size = new System.Drawing.Size(142, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label bottomLabel;
        private System.Windows.Forms.Label middleLabel;
    }
}
