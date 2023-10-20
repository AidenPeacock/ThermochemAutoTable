namespace Thermochem
{
    partial class Form1
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
            this.btnCalc = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Var1 = new System.Windows.Forms.Label();
            this.Var2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.State = new System.Windows.Forms.Label();
            this.VarEnter1 = new System.Windows.Forms.TextBox();
            this.VarEnter2 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.VarEnter3 = new System.Windows.Forms.TextBox();
            this.quality = new System.Windows.Forms.Label();
            this.VarContainer1 = new System.Windows.Forms.FlowLayoutPanel();
            this.VarContainer2 = new System.Windows.Forms.FlowLayoutPanel();
            this.outputTemp = new System.Windows.Forms.TextBox();
            this.outputPress = new System.Windows.Forms.TextBox();
            this.outputIntEng = new System.Windows.Forms.TextBox();
            this.outputEnthalpy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputIntEngGas = new System.Windows.Forms.Label();
            this.outputIntEngLiq = new System.Windows.Forms.Label();
            this.outputSpecVol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputState = new System.Windows.Forms.TextBox();
            this.resultpanel = new System.Windows.Forms.Panel();
            this.VarContainer1.SuspendLayout();
            this.VarContainer2.SuspendLayout();
            this.resultpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(338, 214);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(99, 28);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "Calculate!";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Temperature (Celcius)",
            "Pressure (kPa)"});
            this.comboBox1.Location = new System.Drawing.Point(3, 2);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Temperature (Celcius)",
            "Pressure (kPa)",
            "Specific Volume (m^3/kg)",
            "Internal Energy (kJ/kg)",
            "Enthalpy (kJ/kg)",
            "Unknown"});
            this.comboBox2.Location = new System.Drawing.Point(3, 2);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(210, 24);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Var1
            // 
            this.Var1.AutoSize = true;
            this.Var1.Location = new System.Drawing.Point(93, 60);
            this.Var1.Name = "Var1";
            this.Var1.Size = new System.Drawing.Size(68, 16);
            this.Var1.TabIndex = 3;
            this.Var1.Text = "Variable 1";
            this.Var1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Var2
            // 
            this.Var2.AutoSize = true;
            this.Var2.Location = new System.Drawing.Point(314, 60);
            this.Var2.Name = "Var2";
            this.Var2.Size = new System.Drawing.Size(68, 16);
            this.Var2.TabIndex = 4;
            this.Var2.Text = "Variable 2";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Saturated Vapour",
            "Saturated Mixture",
            "Saturated Liquid",
            "Superheated Vapour",
            "Subcooled Liquid",
            "Unknown"});
            this.comboBox3.Location = new System.Drawing.Point(481, 81);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(160, 24);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Location = new System.Drawing.Point(524, 60);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(79, 16);
            this.State.TabIndex = 6;
            this.State.Text = "State of fluid";
            // 
            // VarEnter1
            // 
            this.VarEnter1.Location = new System.Drawing.Point(3, 30);
            this.VarEnter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VarEnter1.Name = "VarEnter1";
            this.VarEnter1.Size = new System.Drawing.Size(210, 22);
            this.VarEnter1.TabIndex = 7;
            // 
            // VarEnter2
            // 
            this.VarEnter2.Location = new System.Drawing.Point(3, 30);
            this.VarEnter2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VarEnter2.Name = "VarEnter2";
            this.VarEnter2.Size = new System.Drawing.Size(210, 22);
            this.VarEnter2.TabIndex = 8;
            // 
            // VarEnter3
            // 
            this.VarEnter3.Location = new System.Drawing.Point(647, 81);
            this.VarEnter3.Name = "VarEnter3";
            this.VarEnter3.Size = new System.Drawing.Size(121, 22);
            this.VarEnter3.TabIndex = 9;
            // 
            // quality
            // 
            this.quality.AutoSize = true;
            this.quality.Location = new System.Drawing.Point(693, 60);
            this.quality.Name = "quality";
            this.quality.Size = new System.Drawing.Size(30, 16);
            this.quality.TabIndex = 10;
            this.quality.Text = "N/A";
            this.quality.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // VarContainer1
            // 
            this.VarContainer1.Controls.Add(this.comboBox1);
            this.VarContainer1.Controls.Add(this.VarEnter1);
            this.VarContainer1.Location = new System.Drawing.Point(19, 81);
            this.VarContainer1.Name = "VarContainer1";
            this.VarContainer1.Size = new System.Drawing.Size(221, 60);
            this.VarContainer1.TabIndex = 11;
            // 
            // VarContainer2
            // 
            this.VarContainer2.Controls.Add(this.comboBox2);
            this.VarContainer2.Controls.Add(this.VarEnter2);
            this.VarContainer2.Location = new System.Drawing.Point(246, 81);
            this.VarContainer2.Name = "VarContainer2";
            this.VarContainer2.Size = new System.Drawing.Size(221, 60);
            this.VarContainer2.TabIndex = 12;
            // 
            // outputTemp
            // 
            this.outputTemp.Location = new System.Drawing.Point(3, 56);
            this.outputTemp.Name = "outputTemp";
            this.outputTemp.Size = new System.Drawing.Size(100, 22);
            this.outputTemp.TabIndex = 13;
            this.outputTemp.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // outputPress
            // 
            this.outputPress.Location = new System.Drawing.Point(130, 56);
            this.outputPress.Name = "outputPress";
            this.outputPress.Size = new System.Drawing.Size(100, 22);
            this.outputPress.TabIndex = 14;
            // 
            // outputIntEng
            // 
            this.outputIntEng.Location = new System.Drawing.Point(410, 56);
            this.outputIntEng.Name = "outputIntEng";
            this.outputIntEng.Size = new System.Drawing.Size(100, 22);
            this.outputIntEng.TabIndex = 17;
            // 
            // outputEnthalpy
            // 
            this.outputEnthalpy.Location = new System.Drawing.Point(550, 56);
            this.outputEnthalpy.Name = "outputEnthalpy";
            this.outputEnthalpy.Size = new System.Drawing.Size(100, 22);
            this.outputEnthalpy.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Pressure";
            // 
            // outputIntEngGas
            // 
            this.outputIntEngGas.AutoSize = true;
            this.outputIntEngGas.Location = new System.Drawing.Point(561, 37);
            this.outputIntEngGas.Name = "outputIntEngGas";
            this.outputIntEngGas.Size = new System.Drawing.Size(59, 16);
            this.outputIntEngGas.TabIndex = 27;
            this.outputIntEngGas.Text = "Enthalpy";
            // 
            // outputIntEngLiq
            // 
            this.outputIntEngLiq.AutoSize = true;
            this.outputIntEngLiq.Location = new System.Drawing.Point(407, 37);
            this.outputIntEngLiq.Name = "outputIntEngLiq";
            this.outputIntEngLiq.Size = new System.Drawing.Size(96, 16);
            this.outputIntEngLiq.TabIndex = 28;
            this.outputIntEngLiq.Text = "Internal Energy";
            // 
            // outputSpecVol
            // 
            this.outputSpecVol.Location = new System.Drawing.Point(270, 56);
            this.outputSpecVol.Name = "outputSpecVol";
            this.outputSpecVol.Size = new System.Drawing.Size(100, 22);
            this.outputSpecVol.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Specific Volume";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(744, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "State";
            // 
            // outputState
            // 
            this.outputState.Location = new System.Drawing.Point(693, 56);
            this.outputState.Name = "outputState";
            this.outputState.Size = new System.Drawing.Size(139, 22);
            this.outputState.TabIndex = 32;
            // 
            // resultpanel
            // 
            this.resultpanel.Controls.Add(this.label4);
            this.resultpanel.Controls.Add(this.outputState);
            this.resultpanel.Controls.Add(this.label3);
            this.resultpanel.Controls.Add(this.outputSpecVol);
            this.resultpanel.Controls.Add(this.outputIntEngLiq);
            this.resultpanel.Controls.Add(this.outputIntEngGas);
            this.resultpanel.Controls.Add(this.label2);
            this.resultpanel.Controls.Add(this.label1);
            this.resultpanel.Controls.Add(this.outputEnthalpy);
            this.resultpanel.Controls.Add(this.outputIntEng);
            this.resultpanel.Controls.Add(this.outputPress);
            this.resultpanel.Controls.Add(this.outputTemp);
            this.resultpanel.Location = new System.Drawing.Point(12, 315);
            this.resultpanel.Name = "resultpanel";
            this.resultpanel.Size = new System.Drawing.Size(844, 106);
            this.resultpanel.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 450);
            this.Controls.Add(this.resultpanel);
            this.Controls.Add(this.VarContainer2);
            this.Controls.Add(this.VarContainer1);
            this.Controls.Add(this.quality);
            this.Controls.Add(this.VarEnter3);
            this.Controls.Add(this.State);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.Var2);
            this.Controls.Add(this.Var1);
            this.Controls.Add(this.btnCalc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.VarContainer1.ResumeLayout(false);
            this.VarContainer1.PerformLayout();
            this.VarContainer2.ResumeLayout(false);
            this.VarContainer2.PerformLayout();
            this.resultpanel.ResumeLayout(false);
            this.resultpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Var1;
        private System.Windows.Forms.Label Var2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.TextBox VarEnter1;
        private System.Windows.Forms.TextBox VarEnter2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox VarEnter3;
        private System.Windows.Forms.Label quality;
        private System.Windows.Forms.FlowLayoutPanel VarContainer1;
        private System.Windows.Forms.FlowLayoutPanel VarContainer2;
        private System.Windows.Forms.TextBox outputTemp;
        private System.Windows.Forms.TextBox outputPress;
        private System.Windows.Forms.TextBox outputIntEng;
        private System.Windows.Forms.TextBox outputEnthalpy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label outputIntEngGas;
        private System.Windows.Forms.Label outputIntEngLiq;
        private System.Windows.Forms.TextBox outputSpecVol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputState;
        private System.Windows.Forms.Panel resultpanel;
    }
}

