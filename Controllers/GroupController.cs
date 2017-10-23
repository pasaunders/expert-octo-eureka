using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet]
        [Route("groups")]
        public JsonResult AllGroups()
        {
            return Json(allGroups);
        }

        [HttpGet]
        [Route("groups/name/{name}")]
        public JsonResult NameSearch(string name) {
            return Json(allGroups.Where(group => group.GroupName == name));
        }

        [HttpGet]
        [Route("groups/id/{id}")]
        public JsonResult IdSearch(int id)
        {
            return Json(allGroups.Where(group => group.Id == id));
        }
    }
}