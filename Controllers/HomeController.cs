using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using newchat.Services;
using newchat;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
//using newchat.

namespace newchat.Controllers
{
    public class Global
    {
        public static int conta;
    }
    public class HomeController : Controller
    {
        //[DefaultDependency]
        public Iumatask _umatask { get; set; }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Tarefa()
        {
            taskagoraOne();

            return View();
        }

        public void taskagoraOne()
        {
            // stackoverflow.com/questions/4783865/how-do-i-abort-cancel-tpl-tasks

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            //var init = Task.Factory.StartNew(() =>
            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    for (int i = 0; i < 50; i++) {
                        Global.conta += i;
                        Thread.Sleep(2000);
                    }

                    if (ct.IsCancellationRequested) {
                        // another thread decided to cancel
                        Debug.WriteLine("task canceled");
                        break;
                    }

                } // while
            }, ct);

            var tmp = task.Status.ToString();

            //if (tmp == "Running")
            //{
            //    ts.Cancel();
            //}

            //task.Start();

        }
        public int retornaGlobal()
        {
            return 63;
        }

    }
}