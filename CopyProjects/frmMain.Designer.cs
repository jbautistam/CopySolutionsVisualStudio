namespace CopyProjects
{
	partial class frmMain
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
		if (disposing && (components != null))
		{
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fnSolution = new Bau.Controls.Files.TextBoxSelectFile();
			this.pthTarget = new Bau.Controls.Files.TextBoxSelectPath();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Solución:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Destino:";
			// 
			// fnSolution
			// 
			this.fnSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fnSolution.BackColorEdit = System.Drawing.SystemColors.Window;
			this.fnSolution.FileName = "D:\\Trabajo\\Projects\\trunk\\Net\\Negocio\\Clientes\\GrupoBC\\ProcesoNotasSimples\\Solici" +
    "tudNotasSimples_2010.sln";
			this.fnSolution.Filter = "Archivos de solución (*.sln)|*.sln|Todos los archivos|*.*";
			this.fnSolution.Location = new System.Drawing.Point(80, 16);
			this.fnSolution.Margin = new System.Windows.Forms.Padding(0);
			this.fnSolution.MaximumSize = new System.Drawing.Size(10000, 20);
			this.fnSolution.MinimumSize = new System.Drawing.Size(200, 20);
			this.fnSolution.Name = "fnSolution";
			this.fnSolution.Size = new System.Drawing.Size(440, 20);
			this.fnSolution.TabIndex = 1;
			this.fnSolution.Type = Bau.Controls.Files.TextBoxSelectFile.FileSelectType.Load;
			// 
			// pthTarget
			// 
			this.pthTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pthTarget.Location = new System.Drawing.Point(80, 39);
			this.pthTarget.Margin = new System.Windows.Forms.Padding(0);
			this.pthTarget.MaximumSize = new System.Drawing.Size(10000, 20);
			this.pthTarget.MinimumSize = new System.Drawing.Size(200, 20);
			this.pthTarget.Name = "pthTarget";
			this.pthTarget.PathName = "D:\\Usuarios\\jbm1.LM22344P\\Downloads\\Test";
			this.pthTarget.Size = new System.Drawing.Size(440, 20);
			this.pthTarget.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Log:";
			// 
			// txtLog
			// 
			this.txtLog.AcceptsReturn = true;
			this.txtLog.AcceptsTab = true;
			this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLog.Location = new System.Drawing.Point(15, 94);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(504, 236);
			this.txtLog.TabIndex = 3;
			// 
			// cmdCopy
			// 
			this.cmdCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCopy.Location = new System.Drawing.Point(439, 337);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(75, 23);
			this.cmdCopy.TabIndex = 4;
			this.cmdCopy.Text = "Copiar";
			this.cmdCopy.UseVisualStyleBackColor = true;
			this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 371);
			this.Controls.Add(this.cmdCopy);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.pthTarget);
			this.Controls.Add(this.fnSolution);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Bau.Controls.Files.TextBoxSelectFile fnSolution;
		private Bau.Controls.Files.TextBoxSelectPath pthTarget;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Button cmdCopy;
	}
}

