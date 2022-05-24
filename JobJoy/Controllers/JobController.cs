using Firebase.Auth;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using JobJoy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJoy.Controllers
{
    public class JobController : Controller
    {
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "AIzaSyBjX260O1uOmbOH1lSFObVnzBh0LaWcwvk",
            BasePath = "https://jobjoyusn-default-rtdb.europe-west1.firebasedatabase.app/",
        };

        IFirebaseClient client;
        // GET: Job
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Jobs");

            //Assign firebase response to dynamic object to avoid compole time type checking
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            var list = new List<Job>();
            foreach (var item in data) 
            {
                list.Add(JsonConvert.DeserializeObject<Job>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Job job)
        {
            try
            {
                AddJobToFirebase(job);
                ModelState.AddModelError(string.Empty, "Job published sucsessfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void AddJobToFirebase(Job job)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = job;
            PushResponse response = client.Push("Jobs/", data);
            data.job_category = response.Result.name;
            SetResponse setResponse = client.Set("Jobs/"+data.job_category,data);
        }
    }
}