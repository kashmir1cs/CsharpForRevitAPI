/*
 * 참조 추가 : ReviAPI.dll, RevitAPIUI.dll
 * 
 * 
 * 
 * 
 * 
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace LearnTheRevitAPI
{
	public partial class ThisApplication
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
		public void Simpdialouge()
		{
			TaskDialog.Show("대화창", "Revit TaskDialog.Show");
		}
	}
}
