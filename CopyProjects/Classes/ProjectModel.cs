using System;
using System.IO;

namespace CopyProjects.Classes
{
	/// <summary>
	///		Clase con los datos de un proyecto
	/// </summary>
	public class ProjectModel
	{
		public ProjectModel(SolutionModel objSolution, string strName, string strFileName)
		{ // Asigna las propiedades
				Name = strName;
				FileNameRelativeSource = strFileName;
			// Asigna el directorio origen
				FullFileNameSource = CombinePaths(Path.GetDirectoryName(objSolution.FileName), FileNameRelativeSource);
			// Asigna el directorio destino
				PathTarget = Path.Combine(objSolution.PathTarget,
																	Path.GetFileNameWithoutExtension(FileNameRelativeSource));
			// Asigna el nombre del archivo destino
				SolutionFileNameTarget = Path.Combine(Path.GetFileName(Path.GetDirectoryName(FileNameRelativeSource)), 
																											 Path.GetFileName(FileNameRelativeSource));
		}

		/// <summary>
		///		Combina dos directorios
		/// </summary>
		private string CombinePaths(string strPathParent, string strFileName)
		{ // Quita los directorios finales mientras el nombre de archivo destino comience por ../
				while (strFileName.StartsWith("../") || strFileName.StartsWith("..\\"))
					{ strPathParent = Path.GetDirectoryName(strPathParent);
						strFileName = strFileName.Substring(3);
					}
			// Combina los directorios
				return Path.Combine(strPathParent, strFileName);
		}

		/// <summary>
		///		Nombre del proyecto
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		///		Nombre de archivo de proyecto relativo
		/// </summary>
		public string FileNameRelativeSource { get; private set; }

		/// <summary>
		///		Directorio origen
		/// </summary>
		public string PathSource 
		{ get { return Path.GetDirectoryName(FullFileNameSource); }
		}

		/// <summary>
		///		Nombre del archivo de proyecto completo
		/// </summary>
		public string FullFileNameSource { get; private set; }

		/// <summary>
		///		Directorio destino
		/// </summary>
		public string PathTarget { get; private set; }

		/// <summary>
		///		Nombre del archivo destino en la solución
		/// </summary>
		public string SolutionFileNameTarget { get; private set; }

		/// <summary>
		///		Nombre completo del archivo destino
		/// </summary>
		public string FullFileNameTarget
		{ get { return System.IO.Path.Combine(PathTarget, Path.GetFileName(SolutionFileNameTarget)); }
		}

		/// <summary>
		///		Indica si se debe procesar el proyecto
		/// </summary>
		public bool MustCopy 
		{ get { return System.IO.File.Exists(FullFileNameSource); }
		}
	}
}
