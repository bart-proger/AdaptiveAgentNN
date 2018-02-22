namespace AdaptiveAgent3
{
	partial class Form1
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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panelView = new System.Windows.Forms.Panel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.btnReset = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslTickCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslEyeContact = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslCollision = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslEyePerCol = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnNextStep = new System.Windows.Forms.Button();
			this.nudTick = new System.Windows.Forms.NumericUpDown();
			this.lblTick = new System.Windows.Forms.Label();
			this.tvKB = new System.Windows.Forms.TreeView();
			this.cbUpdateTree = new System.Windows.Forms.CheckBox();
			this.btnUpdateTree = new System.Windows.Forms.Button();
			this.btnExpCol = new System.Windows.Forms.Button();
			this.btnResetAgent = new System.Windows.Forms.Button();
			this.btnClearMap = new System.Windows.Forms.Button();
			this.btnPlus = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.lblSitCount = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnEvoReset = new System.Windows.Forms.Button();
			this.btnShowBests = new System.Windows.Forms.Button();
			this.btnEvoStop = new System.Windows.Forms.Button();
			this.btnEvoStart = new System.Windows.Forms.Button();
			this.nudMutation = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.nudBests = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nudPopulation = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTick)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMutation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBests)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPopulation)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelView
			// 
			this.panelView.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelView.Location = new System.Drawing.Point(12, 12);
			this.panelView.Name = "panelView";
			this.panelView.Size = new System.Drawing.Size(723, 674);
			this.panelView.TabIndex = 0;
			this.panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.panelView_Paint);
			this.panelView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelView_MouseClick);
			// 
			// timer
			// 
			this.timer.Interval = 40;
			this.timer.Tag = "";
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(741, 12);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(93, 23);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "Новая карта";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(10, 19);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Старт";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(10, 48);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Стоп";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTickCount,
            this.tsslEyeContact,
            this.tsslCollision,
            this.tsslEyePerCol});
			this.statusStrip1.Location = new System.Drawing.Point(0, 699);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1171, 24);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslTickCount
			// 
			this.tsslTickCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslTickCount.Name = "tsslTickCount";
			this.tsslTickCount.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.tsslTickCount.Size = new System.Drawing.Size(143, 19);
			this.tsslTickCount.Text = "Прошло тактов: 00000";
			this.tsslTickCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tsslEyeContact
			// 
			this.tsslEyeContact.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslEyeContact.Name = "tsslEyeContact";
			this.tsslEyeContact.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.tsslEyeContact.Size = new System.Drawing.Size(101, 19);
			this.tsslEyeContact.Text = "Встречь: 00000";
			this.tsslEyeContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tsslCollision
			// 
			this.tsslCollision.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslCollision.Name = "tsslCollision";
			this.tsslCollision.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.tsslCollision.Size = new System.Drawing.Size(137, 19);
			this.tsslCollision.Text = "Столкновений: 00000";
			this.tsslCollision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tsslEyePerCol
			// 
			this.tsslEyePerCol.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslEyePerCol.Name = "tsslEyePerCol";
			this.tsslEyePerCol.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.tsslEyePerCol.Size = new System.Drawing.Size(108, 19);
			this.tsslEyePerCol.Text = "ст./вс. = 0.00000";
			this.tsslEyePerCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnNextStep
			// 
			this.btnNextStep.Location = new System.Drawing.Point(92, 19);
			this.btnNextStep.Name = "btnNextStep";
			this.btnNextStep.Size = new System.Drawing.Size(75, 23);
			this.btnNextStep.TabIndex = 5;
			this.btnNextStep.Text = "След. шаг";
			this.btnNextStep.UseVisualStyleBackColor = true;
			this.btnNextStep.Click += new System.EventHandler(this.timer_Tick);
			// 
			// nudTick
			// 
			this.nudTick.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudTick.Location = new System.Drawing.Point(157, 51);
			this.nudTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTick.Name = "nudTick";
			this.nudTick.Size = new System.Drawing.Size(58, 20);
			this.nudTick.TabIndex = 6;
			this.nudTick.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.nudTick.ValueChanged += new System.EventHandler(this.nudTick_ValueChanged);
			// 
			// lblTick
			// 
			this.lblTick.AutoSize = true;
			this.lblTick.Location = new System.Drawing.Point(93, 53);
			this.lblTick.Name = "lblTick";
			this.lblTick.Size = new System.Drawing.Size(58, 13);
			this.lblTick.TabIndex = 7;
			this.lblTick.Text = "Задержка";
			// 
			// tvKB
			// 
			this.tvKB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tvKB.Indent = 12;
			this.tvKB.Location = new System.Drawing.Point(967, 41);
			this.tvKB.Name = "tvKB";
			this.tvKB.Size = new System.Drawing.Size(192, 645);
			this.tvKB.TabIndex = 8;
			this.tvKB.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvKB_AfterExpand);
			// 
			// cbUpdateTree
			// 
			this.cbUpdateTree.AutoSize = true;
			this.cbUpdateTree.Location = new System.Drawing.Point(851, 655);
			this.cbUpdateTree.Name = "cbUpdateTree";
			this.cbUpdateTree.Size = new System.Drawing.Size(110, 17);
			this.cbUpdateTree.TabIndex = 9;
			this.cbUpdateTree.Text = "Автообновление";
			this.cbUpdateTree.UseVisualStyleBackColor = true;
			// 
			// btnUpdateTree
			// 
			this.btnUpdateTree.Location = new System.Drawing.Point(759, 651);
			this.btnUpdateTree.Name = "btnUpdateTree";
			this.btnUpdateTree.Size = new System.Drawing.Size(75, 23);
			this.btnUpdateTree.TabIndex = 10;
			this.btnUpdateTree.Text = "Обновить";
			this.btnUpdateTree.UseVisualStyleBackColor = true;
			this.btnUpdateTree.Click += new System.EventHandler(this.btnUpdateTree_Click);
			// 
			// btnExpCol
			// 
			this.btnExpCol.AutoSize = true;
			this.btnExpCol.Location = new System.Drawing.Point(823, 622);
			this.btnExpCol.Name = "btnExpCol";
			this.btnExpCol.Size = new System.Drawing.Size(138, 23);
			this.btnExpCol.TabIndex = 11;
			this.btnExpCol.Text = "Свернуть / Развернуть";
			this.btnExpCol.UseVisualStyleBackColor = true;
			this.btnExpCol.Click += new System.EventHandler(this.btnExpCol_Click);
			// 
			// btnResetAgent
			// 
			this.btnResetAgent.Location = new System.Drawing.Point(851, 12);
			this.btnResetAgent.Name = "btnResetAgent";
			this.btnResetAgent.Size = new System.Drawing.Size(95, 23);
			this.btnResetAgent.TabIndex = 12;
			this.btnResetAgent.Text = "Новый агент";
			this.btnResetAgent.UseVisualStyleBackColor = true;
			this.btnResetAgent.Click += new System.EventHandler(this.btnResetAgent_Click);
			// 
			// btnClearMap
			// 
			this.btnClearMap.Location = new System.Drawing.Point(741, 41);
			this.btnClearMap.Name = "btnClearMap";
			this.btnClearMap.Size = new System.Drawing.Size(93, 23);
			this.btnClearMap.TabIndex = 13;
			this.btnClearMap.Text = "Очистить";
			this.btnClearMap.UseVisualStyleBackColor = true;
			this.btnClearMap.Click += new System.EventHandler(this.btnClearMap_Click);
			// 
			// btnPlus
			// 
			this.btnPlus.AutoSize = true;
			this.btnPlus.Location = new System.Drawing.Point(10, 91);
			this.btnPlus.Name = "btnPlus";
			this.btnPlus.Size = new System.Drawing.Size(104, 23);
			this.btnPlus.TabIndex = 14;
			this.btnPlus.Text = "+10 000 шагов";
			this.btnPlus.UseVisualStyleBackColor = true;
			this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(10, 120);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 15;
			this.button1.Text = "+100 000 шагов";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblSitCount
			// 
			this.lblSitCount.AutoSize = true;
			this.lblSitCount.Location = new System.Drawing.Point(967, 12);
			this.lblSitCount.Name = "lblSitCount";
			this.lblSitCount.Size = new System.Drawing.Size(81, 13);
			this.lblSitCount.TabIndex = 16;
			this.lblSitCount.Text = "Образов: 0000";
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.Location = new System.Drawing.Point(10, 149);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(105, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "+1 000 000 шагов";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnEvoReset);
			this.groupBox1.Controls.Add(this.btnShowBests);
			this.groupBox1.Controls.Add(this.btnEvoStop);
			this.groupBox1.Controls.Add(this.btnEvoStart);
			this.groupBox1.Controls.Add(this.nudMutation);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nudBests);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.nudPopulation);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(744, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(217, 225);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Эволюция";
			// 
			// btnEvoReset
			// 
			this.btnEvoReset.Location = new System.Drawing.Point(131, 150);
			this.btnEvoReset.Name = "btnEvoReset";
			this.btnEvoReset.Size = new System.Drawing.Size(75, 23);
			this.btnEvoReset.TabIndex = 10;
			this.btnEvoReset.Text = "Сброс";
			this.btnEvoReset.UseVisualStyleBackColor = true;
			this.btnEvoReset.Click += new System.EventHandler(this.btnEvoReset_Click);
			// 
			// btnShowBests
			// 
			this.btnShowBests.Location = new System.Drawing.Point(10, 185);
			this.btnShowBests.Name = "btnShowBests";
			this.btnShowBests.Size = new System.Drawing.Size(104, 23);
			this.btnShowBests.TabIndex = 9;
			this.btnShowBests.Text = "Показать лучших";
			this.btnShowBests.UseVisualStyleBackColor = true;
			this.btnShowBests.Click += new System.EventHandler(this.btnShowBests_Click);
			// 
			// btnEvoStop
			// 
			this.btnEvoStop.Location = new System.Drawing.Point(113, 109);
			this.btnEvoStop.Name = "btnEvoStop";
			this.btnEvoStop.Size = new System.Drawing.Size(93, 23);
			this.btnEvoStop.TabIndex = 8;
			this.btnEvoStop.Text = "Остановить";
			this.btnEvoStop.UseVisualStyleBackColor = true;
			// 
			// btnEvoStart
			// 
			this.btnEvoStart.Location = new System.Drawing.Point(10, 109);
			this.btnEvoStart.Name = "btnEvoStart";
			this.btnEvoStart.Size = new System.Drawing.Size(93, 23);
			this.btnEvoStart.TabIndex = 7;
			this.btnEvoStart.Text = "Начать";
			this.btnEvoStart.UseVisualStyleBackColor = true;
			this.btnEvoStart.Click += new System.EventHandler(this.btnEvoStart_Click);
			// 
			// nudMutation
			// 
			this.nudMutation.DecimalPlaces = 2;
			this.nudMutation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.nudMutation.Location = new System.Drawing.Point(107, 72);
			this.nudMutation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMutation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.nudMutation.Name = "nudMutation";
			this.nudMutation.Size = new System.Drawing.Size(95, 20);
			this.nudMutation.TabIndex = 6;
			this.nudMutation.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Мутация";
			// 
			// nudBests
			// 
			this.nudBests.DecimalPlaces = 2;
			this.nudBests.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
			this.nudBests.Location = new System.Drawing.Point(107, 46);
			this.nudBests.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudBests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.nudBests.Name = "nudBests";
			this.nudBests.Size = new System.Drawing.Size(95, 20);
			this.nudBests.TabIndex = 4;
			this.nudBests.Value = new decimal(new int[] {
            10,
            0,
            0,
            131072});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Лучших";
			// 
			// nudPopulation
			// 
			this.nudPopulation.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudPopulation.Location = new System.Drawing.Point(107, 20);
			this.nudPopulation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudPopulation.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudPopulation.Name = "nudPopulation";
			this.nudPopulation.Size = new System.Drawing.Size(95, 20);
			this.nudPopulation.TabIndex = 2;
			this.nudPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Популяция";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnNextStep);
			this.groupBox2.Controls.Add(this.btnStart);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.btnStop);
			this.groupBox2.Controls.Add(this.nudTick);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.lblTick);
			this.groupBox2.Controls.Add(this.btnPlus);
			this.groupBox2.Location = new System.Drawing.Point(744, 333);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(217, 187);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Симуляция";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1171, 723);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblSitCount);
			this.Controls.Add(this.btnClearMap);
			this.Controls.Add(this.btnResetAgent);
			this.Controls.Add(this.btnExpCol);
			this.Controls.Add(this.btnUpdateTree);
			this.Controls.Add(this.cbUpdateTree);
			this.Controls.Add(this.tvKB);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.panelView);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Adaptive Agent";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTick)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMutation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBests)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPopulation)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelView;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsslTickCount;
		private System.Windows.Forms.ToolStripStatusLabel tsslEyeContact;
		private System.Windows.Forms.Button btnNextStep;
		private System.Windows.Forms.NumericUpDown nudTick;
		private System.Windows.Forms.Label lblTick;
		private System.Windows.Forms.ToolStripStatusLabel tsslCollision;
		private System.Windows.Forms.TreeView tvKB;
		private System.Windows.Forms.CheckBox cbUpdateTree;
		private System.Windows.Forms.Button btnUpdateTree;
		private System.Windows.Forms.Button btnExpCol;
		private System.Windows.Forms.Button btnResetAgent;
		private System.Windows.Forms.Button btnClearMap;
		private System.Windows.Forms.ToolStripStatusLabel tsslEyePerCol;
		private System.Windows.Forms.Button btnPlus;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblSitCount;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnShowBests;
		private System.Windows.Forms.Button btnEvoStop;
		private System.Windows.Forms.Button btnEvoStart;
		private System.Windows.Forms.NumericUpDown nudMutation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudBests;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudPopulation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnEvoReset;

	}
}

