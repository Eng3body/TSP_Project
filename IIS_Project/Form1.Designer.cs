namespace IIS_Project
{
    partial class TSP_Main_Screen
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
            btn_Calculate = new Button();
            btn_reset = new Button();
            cbxAlgorithms = new ComboBox();
            SuspendLayout();
            // 
            // btn_Calculate
            // 
            btn_Calculate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Calculate.Location = new Point(912, 535);
            btn_Calculate.Name = "btn_Calculate";
            btn_Calculate.Size = new Size(146, 47);
            btn_Calculate.TabIndex = 0;
            btn_Calculate.Text = "Calculate";
            btn_Calculate.UseVisualStyleBackColor = true;
            btn_Calculate.Click += btnCalculate_Click;
            // 
            // btn_reset
            // 
            btn_reset.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_reset.Location = new Point(760, 535);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(146, 47);
            btn_reset.TabIndex = 1;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btnReset_Click;
            // 
            // cbxAlgorithms
            // 
            cbxAlgorithms.AutoCompleteCustomSource.AddRange(new string[] { "No Algo", "Brute Force", "Nearest Neighbors", "DP(Held Karp)" });
            cbxAlgorithms.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbxAlgorithms.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxAlgorithms.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbxAlgorithms.ForeColor = Color.Black;
            cbxAlgorithms.FormattingEnabled = true;
            cbxAlgorithms.Items.AddRange(new object[] { "No Algo", "Brute Force", "Nearest Neighbors", "DP(Held Karp)" });
            cbxAlgorithms.Location = new Point(12, 549);
            cbxAlgorithms.Name = "cbxAlgorithms";
            cbxAlgorithms.Size = new Size(232, 33);
            cbxAlgorithms.TabIndex = 1;
            cbxAlgorithms.Tag = "";
            // 
            // TSP_Main_Screen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1070, 594);
            Controls.Add(cbxAlgorithms);
            Controls.Add(btn_reset);
            Controls.Add(btn_Calculate);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TSP_Main_Screen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TSP";
            TransparencyKey = Color.Transparent;
            MouseClick += Form1_MouseClick;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Calculate;
        private Button btn_reset;
        private ComboBox cbxAlgorithms;
    }
}
