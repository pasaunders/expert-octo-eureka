using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [HttpGet]
        [Route("artists")]
        public JsonResult Artists()
        {
            return Json(allArtists);
        }

        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult NameSearch(string name)
        {
            return Json(allArtists.Where( artist => artist.ArtistName == name));
        }

        [HttpGet]
        [Route("artists/realname/{name}")]
        public JsonResult RealSearch(string name)
        {
            return Json(allArtists.Where( artist => artist.RealName == name));
        }

        [HttpGet]
        [Route("artists/hometown/{town}")]
        public JsonResult TownSearch(string town)
        {
            return Json(allArtists.Where( artist => artist.Hometown == town));
        }

        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult IdSearch(int id)
        {
            return Json(allArtists.Where( artist => artist.GroupId == id));
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
    }
}