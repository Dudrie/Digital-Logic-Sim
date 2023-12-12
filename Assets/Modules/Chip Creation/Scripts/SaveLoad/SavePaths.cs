using System.IO;
using UnityEngine;

namespace DLS.ChipCreation
{
	public static class SavePaths
	{
		const string MajorVersionName = "V1";
		public static string AllData => GenerateAllDataPath();

		// Path to save folder for all projects
		public static string ProjectsPath => Path.Combine(AllData, MajorVersionName, "Projects");
		public static string DeletedProjectsPath => Path.Combine(AllData, MajorVersionName, "Deleted Projects");

		// Path to save folder for a specific project
		public static string ProjectPath(string projectName) => Path.Combine(ProjectsPath, projectName);
		public static string DeletedProjectPath(string projectName) => Path.Combine(DeletedProjectsPath, projectName);

		// Gets path to project's chip data save folder
		public static string ChipsPath(string projectName) => Path.Combine(ProjectPath(projectName), "Chips");

		// Gets path to project's deleted chips back-up folder
		public static string DeletedChipsPath(string projectName) => Path.Combine(ProjectPath(projectName), "Deleted Chips");

		public static void EnsureDirectoryExists(string directoryPath)
		{
			Directory.CreateDirectory(directoryPath);
		}

		static string GenerateAllDataPath()
		{
			if (Directory.Exists(Path.GetFullPath("H:")))
			{
				return Path.Combine("H:", "DigitalLogicSim");
			}
			else
			{
				return Application.persistentDataPath;
			}
		}
	}
}