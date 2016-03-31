using DevTrends.MvcDonutCaching;
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
using TPD.Presentation.Uitilities;

namespace TPD.Presentation.Controllers
{
    public class HomeController : Controller
    {
        IEventUOW _eventUOW;

        const int MaxTopSpeakers = 10;
        const int MaxComingSoonProgramms = 5;

        public HomeController(IEventUOW eventUOW)
        {
            _eventUOW = eventUOW;
        }

        #region Main page
        //[OutputCache(CacheProfile = "FiveMinutes")]
        //[CompressContent]
        //[DonutOutputCache(CacheProfile = "FiveMinutes")]        
        public async Task<ActionResult> Index(bool useAsync = false)
        {
            IEnumerable<SpeakerPreviewDTO> speakers;
            IDictionary<ProgrammComingSoonDTO, int> comingSoonProgramms;
            IEnumerable<SpeakerPreviewDTO> topSpeakers;
            if (useAsync)
            {
                speakers = await _eventUOW.SpeakersRepository.GetAllSpeakersAsync();
                topSpeakers = await _eventUOW.SpeakersRepository.GetTopSpeakersAsync(MaxTopSpeakers);
                comingSoonProgramms = await _eventUOW.ProgrammsRepository.GetComingSoonAsync(MaxComingSoonProgramms);
            }
            else
            {
                speakers = _eventUOW.SpeakersRepository.GetAllSpeakers();
                topSpeakers = _eventUOW.SpeakersRepository.GetTopSpeakers(MaxTopSpeakers);
                comingSoonProgramms = _eventUOW.ProgrammsRepository.GetComingSoon(MaxComingSoonProgramms);
            }
            ViewBag.UseAsync = useAsync;
            ViewBag.TopSpeakers = topSpeakers;
            ViewBag.ComingSoonProgramms = comingSoonProgramms;
            //Response.SetCookie(new HttpCookie("cache-killer", "ha ha ha ha"));
            return View(speakers);
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

        public async Task<ActionResult> GenerateQrCode(bool useAsync = false)
        {
            Random rand = new Random();
            byte[] qrCode = new byte[1024 * 256];
            rand.NextBytes(qrCode);
            if (useAsync)
                await _eventUOW.SpeakersRepository.SetQrCodeAsync(qrCode);
            else
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