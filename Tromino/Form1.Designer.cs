namespace Tromino
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.nudOrderOfGrid = new System.Windows.Forms.NumericUpDown();
            this.lblOrderOfGrid = new System.Windows.Forms.Label();
            this.lblSizeOfGridTile = new System.Windows.Forms.Label();
            this.nudSizeOfGridTile = new System.Windows.Forms.NumericUpDown();
            this.btnDrawGrid = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblAutori = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderOfGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeOfGridTile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(2, 41);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1349, 809);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
            // 
            // nudOrderOfGrid
            // 
            this.nudOrderOfGrid.Location = new System.Drawing.Point(107, 7);
            this.nudOrderOfGrid.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrderOfGrid.Name = "nudOrderOfGrid";
            this.nudOrderOfGrid.Size = new System.Drawing.Size(49, 22);
            this.nudOrderOfGrid.TabIndex = 1;
            this.nudOrderOfGrid.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblOrderOfGrid
            // 
            this.lblOrderOfGrid.AutoSize = true;
            this.lblOrderOfGrid.Location = new System.Drawing.Point(12, 9);
            this.lblOrderOfGrid.Name = "lblOrderOfGrid";
            this.lblOrderOfGrid.Size = new System.Drawing.Size(89, 17);
            this.lblOrderOfGrid.TabIndex = 0;
            this.lblOrderOfGrid.Text = "Order of grid";
            // 
            // lblSizeOfGridTile
            // 
            this.lblSizeOfGridTile.AutoSize = true;
            this.lblSizeOfGridTile.Location = new System.Drawing.Point(162, 10);
            this.lblSizeOfGridTile.Name = "lblSizeOfGridTile";
            this.lblSizeOfGridTile.Size = new System.Drawing.Size(101, 17);
            this.lblSizeOfGridTile.TabIndex = 0;
            this.lblSizeOfGridTile.Text = "Size of grid tile";
            // 
            // nudSizeOfGridTile
            // 
            this.nudSizeOfGridTile.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSizeOfGridTile.Location = new System.Drawing.Point(269, 8);
            this.nudSizeOfGridTile.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSizeOfGridTile.Name = "nudSizeOfGridTile";
            this.nudSizeOfGridTile.Size = new System.Drawing.Size(67, 22);
            this.nudSizeOfGridTile.TabIndex = 0;
            this.nudSizeOfGridTile.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnDrawGrid
            // 
            this.btnDrawGrid.Location = new System.Drawing.Point(351, 7);
            this.btnDrawGrid.Name = "btnDrawGrid";
            this.btnDrawGrid.Size = new System.Drawing.Size(93, 23);
            this.btnDrawGrid.TabIndex = 2;
            this.btnDrawGrid.Text = "Draw Grid";
            this.btnDrawGrid.UseVisualStyleBackColor = true;
            this.btnDrawGrid.Click += new System.EventHandler(this.btnDrawGrid_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(450, 10);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(223, 18);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = "Start Tromino by clicking on grid!";
            this.lblInstruction.Visible = false;
            // 
            // lblAutori
            // 
            this.lblAutori.AutoSize = true;
            this.lblAutori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutori.Location = new System.Drawing.Point(839, 12);
            this.lblAutori.Name = "lblAutori";
            this.lblAutori.Size = new System.Drawing.Size(217, 18);
            this.lblAutori.TabIndex = 4;
            this.lblAutori.Text = "Vita Hasani - Master, FIEK 2017";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 853);
            this.Controls.Add(this.lblAutori);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnDrawGrid);
            this.Controls.Add(this.nudSizeOfGridTile);
            this.Controls.Add(this.lblSizeOfGridTile);
            this.Controls.Add(this.lblOrderOfGrid);
            this.Controls.Add(this.nudOrderOfGrid);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Tromino";
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderOfGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeOfGridTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.NumericUpDown nudOrderOfGrid;
        private System.Windows.Forms.Label lblOrderOfGrid;
        private System.Windows.Forms.Label lblSizeOfGridTile;
        private System.Windows.Forms.NumericUpDown nudSizeOfGridTile;
        private System.Windows.Forms.Button btnDrawGrid;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblAutori;
    }
}

