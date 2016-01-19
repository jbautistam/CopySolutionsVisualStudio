using System;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;

namespace CopyProjects.Classes
{
	/// <summary>
	///		Colección de <see cref="ProjectModel"/>
	/// </summary>
	public class ProjectModelCollection : List<ProjectModel>
	{
		/// <summary>
		///		Añade un proyecto a la colección
		/// </summary>
		public void Add(SolutionModel objSolution, string strName, string strFileName)
		{ Add(new ProjectModel(objSolution, strName, strFileName));
		}

		/// <summary>
		///		Busca un proyecto por su nombre de archivo
		/// </summary>
		internal ProjectModel SearchByProjectName(string strName)
		{ // Busca el proyecto
				foreach (ProjectModel objProject in this)
					if (System.IO.Path.GetFileName(objProject.FullFileNameSource).EqualsIgnoreCase(strName))
						return objProject;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
