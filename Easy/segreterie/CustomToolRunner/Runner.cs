/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

﻿using Microsoft.VisualStudio.VCProjectEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomToolRunner
{
	class Runner
	{
	}

	//public static VCProjectItem FindSolutionItemByName(DTE dte, string name, bool recursive) {
	//	ProjectItem projectItem = null;
	//	foreach (Project project in dte.Solution.Projects) {
	//		projectItem = FindProjectItemInProject(project, name, recursive);

	//		if (projectItem != null) {
	//			break;
	//		}
	//	}
	//	return projectItem;
	//}

	//public static ProjectItem FindProjectItemInProject(Project project, string name, bool recursive) {
	//	ProjectItem projectItem = null;

	//	if (project.Kind != Constants.vsProjectKindSolutionItems) {
	//		if (project.ProjectItems != null && project.ProjectItems.Count > 0) {
	//			projectItem = DteHelper.FindItemByName(project.ProjectItems, name, recursive);
	//		}
	//	} else {
	//		// if solution folder, one of its ProjectItems might be a real project
	//		foreach (ProjectItem item in project.ProjectItems) {
	//			Project realProject = item.Object as Project;

	//			if (realProject != null) {
	//				projectItem = FindProjectItemInProject(realProject, name, recursive);

	//				if (projectItem != null) {

	//					VSProjectItem vsProjectItem = projectItem.Object as VSProjectItem;
	//					if (vsProjectItem != null) {
	//						vsProjectItem.RunCustomTool();
	//					}
	//				}
	//			}
	//		}
	//	}

	//	return projectItem;
	//}
}
