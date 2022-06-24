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
		public void findElements()
		{
			UIDocument uidoc = this.ActiveUIDocument; // 활성화된 RVT파일 선택 
			Document doc = uidoc.Document; //REVIT DB선택
//			string elemInfo = ""; //variable for element name
//			// int wallCount = new FilteredElementCollector(doc).OfClass(typeof(Wall)).Count(); //wall의 개수 찾기 
//			
//			// FilteredElementCollector(doc).OfClass(typeof(MEPSystem)).Count(); //MEP System  숫자
//			foreach (Element e in new FilteredElementCollector(doc).OfClass(typeof(Wall)))
//			{
//				elemInfo += "Wall Info : " + e.Name + Environment.NewLine;
//			}
//			
//			TaskDialog.Show("elements-wall",elemInfo);
//			
//			elemInfo = "";
//			foreach (Element e in new FilteredElementCollector(doc)
//			         				.OfClass(typeof(FamilyInstance))
//			         				.OfCategory(BuiltInCategory.OST_Doors))
//			{
//				elemInfo += "Door Info : "+e.Name + Environment.NewLine;
//			}
//			
//			TaskDialog.Show("elements-doors",elemInfo);
			
//			// family 관련 정보 추출하기
//
//
//			
//			string Info = "";
//			foreach (Element e in new FilteredElementCollector(doc)
//			         				.OfClass(typeof(FamilyInstance))
//			         				.OfCategory(BuiltInCategory.OST_Doors))
//			{
//				FamilyInstance fi = e as FamilyInstance;
//				FamilySymbol fs = fi.Symbol; 
//				Family family = fs.Family;
//				Info += family.Name + " : " + fs.Name + " : "+ fi.Name + "\n";
//			}
//			
//			TaskDialog.Show("elements-doors",Info);
			
			// using category filter
			string Info = "";
			ElementCategoryFilter doorFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);
			ElementCategoryFilter windowFilter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
			LogicalOrFilter orFilter = new LogicalOrFilter(doorFilter,windowFilter); //or filter (OR condition)
			
			// ElementMulticategoryFilter 활용 
			IList<BuiltInCategory> categoryList = new List<BuiltInCategory>();
			//IList 객체에 category 추가 
			
			categoryList.Add(BuiltInCategory.OST_Doors);
			categoryList.Add(BuiltInCategory.OST_Windows);
			ElementMulticategoryFilter multiFilter = new ElementMulticategoryFilter(categoryList);
			
			foreach (Element e in new FilteredElementCollector(doc)
			         				.OfClass(typeof(FamilyInstance))
			         				.WherePasses(orFilter))
			{
				FamilyInstance fi = e as FamilyInstance;
				FamilySymbol fs = fi.Symbol; 
				Family family = fs.Family;
				Info += family.Name + " : " + fs.Name + " : "+ fi.Name + "\n";
			}
			
			TaskDialog.Show("elements-doors & windows by using logical or filter",Info);
			
			
			foreach (Element e in new FilteredElementCollector(doc)
			         				.OfClass(typeof(FamilyInstance))
			         				.WherePasses(multiFilter))
			{
				FamilyInstance fi = e as FamilyInstance;
				FamilySymbol fs = fi.Symbol; 
				Family family = fs.Family;
				Info += family.Name + " : " + fs.Name + " : "+ fi.Name + "\n";
			}
			
			TaskDialog.Show("elements-doors & windows by using multicategoryfilter",Info);
			
			
			
			
			// TaskDialog.Show("elements", wallCount.ToString()); // wall 객체 개수 표시 
			
		}
