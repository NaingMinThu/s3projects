using HealthDeclaration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static HealthDeclaration.Models.MyEnum;

namespace HealthDeclaration.Controllers
{
    public class TemplatesController : Controller
    {
        public IActionResult Template()
        {
            var enum_FieldType = from field_type e in Enum.GetValues(typeof(field_type))
                               select new
                               {
                                   ID = (int)e,
                                   Name = MyEnum.GetDescriptionFromEnum(e)
                               };
            ViewBag.Enum_FieldType = new SelectList(enum_FieldType, "ID", "Name");
            return View();
        }
        public IActionResult TemplateList()
        {
            return View();
        }
    }
}
