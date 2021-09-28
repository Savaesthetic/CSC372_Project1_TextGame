namespace CSC372_Project1
{
    partial class TextGame
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
            this.userInput = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(12, 418);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(776, 20);
            this.userInput.TabIndex = 0;
            this.userInput.TextChanged += new System.EventHandler(this.userInput_TextChanged);
            this.userInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userInput_KeyPress);
            // 
            // output
            // 
            this.output.HideSelection = false;
            this.output.Location = new System.Drawing.Point(12, 208);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(776, 204);
            this.output.TabIndex = 1;
            this.output.Text = "";
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // TextGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.output);
            this.Controls.Add(this.userInput);
            this.Name = "TextGame";
            this.Text = "TextGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.RichTextBox output;
    }
}

