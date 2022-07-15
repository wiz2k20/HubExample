using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newchat.Services;

using newchat.Controllers;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace newchat.Hubs
{
    public class Global {
        public static int conta = 10;
    }

    [HubName("tarefaclass")]
    public class tarefa : Hub
    {
        //public Iumatask _umatask { get; set; }

        [HubMethodName("retornastatus")]
        public void retornaTarefa()
        {
            taskagoraOne();
        }

        // stackoverflow.com/questions/4783865/how-do-i-abort-cancel-tpl-tasks
        public void taskagoraOne()
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            
            var task = Task.Factory.StartNew(() =>
            {
                Debug.WriteLine("task init");

                while (true)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Global.conta = i;
                        Clients.All.progresso(Global.conta);
                        Thread.Sleep(1000);
                    }
                    Clients.All.finalizada();
                    break;

                    if (ct.IsCancellationRequested)
                    {
                        Debug.WriteLine("task canceled");
                        Clients.All.cancelada();
                        break;
                    }
                } // while

                Debug.WriteLine("task end");
            }, ct);

            //var tmp = task.Status.ToString();

            //if (tmp == "Running")
            //{
            //    ts.Cancel();
            //}
            //task.Start();
        }


        public void taskagoraOnebkp()
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;

            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++) {
                    Global.conta = i;
                    Clients.All.progresso(Global.conta);
                    Thread.Sleep(1000);
                }

                Clients.All.finalizada();

            }, ct);
        }
    }
}