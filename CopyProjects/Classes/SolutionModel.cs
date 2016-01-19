using System;
using System.IO;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibHelper.Files;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace CopyProjects.Classes
{
	/// <summary>
	///		Clase con los datos de una solución
	/// </summary>
	public class SolutionModel
	{
		public SolutionModel(string strFileName, string strPathTarget)
		{ FileName = strFileName;
			PathTarget = strPathTarget;
			Projects = new ProjectModelCollection();
		}

		/// <summary>
		///		Carga los datos de una solución
		/// </summary>
		public void Load()
		{ List<string> objColLines = LoadLines(); 

				// Recorre el texto de la solución
					foreach (string strLine in objColLines)
						ParseLine(strLine.TrimIgnoreNull());
		}

		/// <summary>
		///		Carga las líneas de un archivo
		/// </summary>
		private List<string> LoadLines()
		{ List<string> objColLines = new List<string>();
			string strContent = HelperFiles.LoadTextFile(FileName);

				// Carga el archivo y lo separa en líneas
					if (!strContent.IsEmpty())
						objColLines = strContent.SplitByString("\n");
				// Devuelve las líneas del archivo
					return objColLines;
		}

		/// <summary>
		///		Interpreta una línea
		/// </summary>
		/// <remarks>
		///		Las líneas son de tipo:
		///		Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "LibCosmosManager.ExportImport", "CosmosManager\Libraries\LibCosmosManager.ExportImport\LibCosmosManager.ExportImport.csproj", "{47175CC1-6DB1-453A-A37B-D77C4497BE19}"
		/// </remarks>
		private void ParseLine(string strLine)
		{ if (!strLine.IsEmpty() && strLine.StartsWithIgnoreNull("Project"))
				{ string [] arrStrParts = strLine.Split('=');

						if (arrStrParts.Length == 2)
							{ string [] arrStrProject = arrStrParts[1].Split(',');

									if (arrStrProject.Length >= 2 && !arrStrProject[0].IsEmpty() && !arrStrProject[1].IsEmpty())
										Projects.Add(this,
																 arrStrProject[0].Replace("\"", "").TrimIgnoreNull(),
																 arrStrProject[1].Replace("\"", "").TrimIgnoreNull());
							}
				}
		}

		/// <summary>
		///		Copia los archivos de la solución en el directorio destino
		/// </summary>
		public void Copy()
		{	// Elimina el directorio destino
				HelperFiles.KillPath(PathTarget);
			// Copia los proyectos
				CopyProjects();
			// Cambia las referencias de los proyectos
				ChangeReferences();
			// Graba la solución
				SaveSolution();
		}

		/// <summary>
		///		Graba la solución
		/// </summary>
		private void SaveSolution()
		{ string strSolution = HelperFiles.LoadTextFile(FileName);

				// Modifica los directorios de proyectos
					foreach (ProjectModel objProject in Projects)
						if (objProject.MustCopy)
							strSolution = strSolution.Replace("\"" + objProject.FileNameRelativeSource + "\"", 
																								"\"" + objProject.SolutionFileNameTarget + "\"");
				// Graba la solución
					HelperFiles.SaveTextFile(Path.Combine(PathTarget, Path.GetFileName(FileName)), strSolution);
		}

		/// <summary>
		///		Copia los proyectos
		/// </summary>
		private void CopyProjects()
		{ // Copia los proyectos
				foreach (ProjectModel objProject in Projects)
					if (objProject.MustCopy)
						{ string [] arrStrPaths = Directory.GetDirectories(objProject.PathSource);

								// Crea el directorio
									HelperFiles.MakePath(objProject.PathTarget);
								// Copia los subdirectorios (excepto bin y temp)
									foreach (string strPath in arrStrPaths)
										if (!strPath.EndsWith("\\bin\\Release", StringComparison.CurrentCultureIgnoreCase) && 
												!strPath.EndsWith("\\obj", StringComparison.CurrentCultureIgnoreCase) && 
												!strPath.EndsWith("\\temp", StringComparison.CurrentCultureIgnoreCase))
											{ string strPathTarget = Path.Combine(objProject.PathTarget, Path.GetFileName(strPath));
												
													// Crea el directorio
														HelperFiles.MakePath(strPathTarget);
													// Copia el directorio
														HelperFiles.CopyPath(strPath, strPathTarget);
											}
								// Copia los archivos raíz
									arrStrPaths = Directory.GetFiles(objProject.PathSource);
									foreach (string strPath in arrStrPaths)
										HelperFiles.CopyFile(strPath, Path.Combine(objProject.PathTarget, Path.GetFileName(strPath)));
						}
		}

		/// <summary>
		///		Cambia las referencias de los proyectos
		/// </summary>
		private void ChangeReferences()
		{ foreach (ProjectModel objProject in Projects)
				if (objProject.MustCopy)
					{ MLFile objMLFile = new XMLParser().Load(objProject.FullFileNameTarget);
						string strContent = HelperFiles.LoadTextFile(objProject.FullFileNameTarget);

							// Cambia los nodos de referencia del proyecto
								foreach (MLNode objMLNode in objMLFile.Nodes)
									if (objMLNode.Name == "Project")
										foreach (MLNode objMLGroup in objMLNode.Nodes)
											if (objMLGroup.Name == "ItemGroup")
												foreach (MLNode objMLItem in objMLGroup.Nodes)
													if (objMLItem.Name == "ProjectReference")
														{ string strReference = objMLItem.Attributes["Include"].Value;
															ProjectModel objProjectTarget = Projects.SearchByProjectName(Path.GetFileName(strReference));

																if (objProjectTarget != null)
																	strContent = strContent.Replace("\"" + strReference + "\"",
																																	"\"..\\" + objProjectTarget.SolutionFileNameTarget + "\"");
														}
							// Graba el archivo de proyecto
								HelperFiles.SaveTextFile(objProject.FullFileNameTarget, strContent);
					}
		}

		/// <summary>
		///		Nombre de archivo
		/// </summary>
		public string FileName { get; private set; }

		/// <summary>
		///		Directorio destino
		/// </summary>
		public string PathTarget { get; private set; }

		/// <summary>
		///		Proyectos
		/// </summary>
		public ProjectModelCollection Projects { get; private set; }
	}
}
