/*
 * Revit API 활용하기 
 * 참조 추가 : ReviAPI.dll, RevitAPIUI.dll
 *선택된 면의 Area 표시하기 
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
		public void selectFace()
		{
			UIDocument uidoc = this.ActiveUIDocument; // 활성화된 RVT파일 선택 
			Document doc = uidoc.Document; //REVIT DB선택
			
			Reference myRef =  uidoc.Selection.PickObject(ObjectType.Face);
			
			
			//Environment.NewLine ="\n"
			Element e = doc.GetElement(myRef);
			GeometryObject getmObj= e.GetGeometryObjectFromReference(myRef);
			
			Face face = getmObj as Face; //형변환 casting
			
			double faceArea = face.Area*92903;
			
			//선택된 객체 관련 정보 표시
//			TaskDialog.Show( "Element Information", e.Name + Environment.NewLine + e.Id + "\n" +
//			               e.DesignOption.Name);
			
//			string designOptionName="<none>";
//			
//			if (e.DesignOption.Name ==null)
//			{
//				designOptionName = e.DesignOption.Name;
//				
//			}
			
			TaskDialog.Show( "Element Information", e.Name + Environment.NewLine + e.Id + "\n" + faceArea);
			
		}
	}
}
