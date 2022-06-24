/*
 * Revit API 활용하기 
 * 참조 추가 : ReviAPI.dll, RevitAPIUI.dll
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
		public void SelectdElements()
		{
			UIDocument uidoc = this.ActiveUIDocument; // 활성화된 RVT파일 선택 
			Document doc = uidoc.Document; //REVIT DB선택
			ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds(); //선택된 객체의 ID 추출
			
			string s = "";
			
			foreach (ElementId id in selectedIds) 
			{
				Element e = doc.GetElement(id); //id로 element 찾기
				s += e.Name + Environment.NewLine; // Element 명 + 줄바꿈 
			}
			
			
			TaskDialog.Show("Elements", selectedIds.Count + "ea" +"\n" +s); //Macro 실행 전 선택되어 있던 Element 정보 표시
		
		}
}
