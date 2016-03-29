using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPD.DAL.Events;
using TPD.DTO.Events;

namespace TPD.Presentation.Controllers
{
    public class HomeController : Controller
    {
        IEventUOW _eventUOW;

        public HomeController(IEventUOW eventUOW)
        {
            _eventUOW = eventUOW;
        }

        #region Main page
        public ActionResult Index()
        {
            IEnumerable<SpeakerPreviewDTO> speakers = _eventUOW.SpeakersRepository.GetAllSpeakers();
            return View(speakers);
        }

        [ChildActionOnly]
        public ActionResult ComingSoon(int number = 5)
        {
            IDictionary<ProgrammComingSoonDTO, int> comingSoonProgramms = _eventUOW.ProgrammsRepository.GetComingSoon(number);
            return View(comingSoonProgramms);
        }

        [ChildActionOnly]
        public ActionResult TopSpeakers(int number = 10)
        {
            IEnumerable<SpeakerPreviewDTO> topSpeakers = _eventUOW.SpeakersRepository.GetTopSpeakers(number);
            return View(topSpeakers);
        }

        #endregion

        #region Data generator
        public async Task<ActionResult> GenerateSpeakers(int number = 0)
        {
            string content;
            string[] positions = new string[] {
                "CEO", "Developer", "QA", "Financial Director", "Technical Lead", "Engineer", "Frontend developer", "Designer", "CTO"
            };
            Random rand = new Random();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://api.randomuser.me/?results=" + number);
                content = await response.Content.ReadAsStringAsync();
            }
            var jReponseToken = JObject.Parse(content);
            foreach (JToken jUserToken in (JArray)jReponseToken["results"])
            {
                var dbUser = new DAL.Speaker();
                dbUser.Firstname = jUserToken["user"]["name"].Value<string>("first");
                dbUser.Lastname = jUserToken["user"]["name"].Value<string>("last");
                dbUser.Position = positions[rand.Next(0, positions.Length - 1)];
                dbUser.Phone = jUserToken["user"].Value<string>("phone");
                dbUser.Email = jUserToken["user"].Value<string>("email");
                dbUser.ImageUrl = jUserToken["user"]["picture"].Value<string>("large");
                _eventUOW.SpeakersRepository.Create(dbUser);
            }
            _eventUOW.Commit();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> GenerateQrCode()
        {
            Random rand = new Random();
            byte[] qrCode = new byte[1024 * 256];
            rand.NextBytes(qrCode);
            _eventUOW.SpeakersRepository.SetQrCode(qrCode);
            return View();
        }

        #endregion

        #region Bonus pages
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
    }
}