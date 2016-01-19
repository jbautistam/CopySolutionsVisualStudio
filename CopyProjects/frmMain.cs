using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using CopyProjects.Classes;

namespace CopyProjects
{
	/// <summary>
	///		Formulario principal para la copia de soluciones
	/// </summary>
	public partial class frmMain : Form
	{
		public frmMain()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ if (!Properties.Settings.Default.SolutionSource.IsEmpty())
				fnSolution.FileName = Properties.Settings.Default.SolutionSource;
			if (!Properties.Settings.Default.PathTarget.IsEmpty())
				pthTarget.PathName = Properties.Settings.Default.PathTarget;
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (fnSolution.FileName.IsEmpty() || !System.IO.File.Exists(fnSolution.FileName))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca un nombre de solución");
					else if (pthTarget.PathName.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el directorio de destino");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Copia los proyectos de una solución
		/// </summary>
		private void CopySolution()
		{ if (ValidateData())
				{ SolutionModel objSolution = new SolutionModel(fnSolution.FileName, pthTarget.PathName);

						// Carga los proyectos
							objSolution.Load();
						// Log
							AddLog("Proyectos cargados");
							foreach (ProjectModel objProject in objSolution.Projects)
								{ AddLog(objProject.Name + " --> " + objProject.FileNameRelativeSource);
									AddLog("         " + objProject.FullFileNameSource + " --> " + objProject.PathTarget);
								}
						// Copia los proyectos
							objSolution.Copy();
						// Graba la configuración
							SaveConfiguration();
						// Muestra un mensaje al usuario
							Bau.Controls.Forms.Helper.ShowMessage(this, "Copia terminada");
				}
		}

		/// <summary>
		///		Graba la configuración
		/// </summary>
		private void SaveConfiguration()
		{ // Asigna las propiedades
				Properties.Settings.Default.SolutionSource = fnSolution.FileName;
				Properties.Settings.Default.PathTarget = pthTarget.PathName;
			// Graba la configuración
				Properties.Settings.Default.Save();
		}

		/// <summary>
		///		Añade una línea al log
		/// </summary>
		private void AddLog(string strMessage)
		{ txtLog.AppendText(strMessage + Environment.NewLine);
		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{ CopySolution();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{ InitForm();
		}
	}
}
