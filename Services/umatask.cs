using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace newchat.Services
{
    public class GlobalService
    {
        public static int conta;
    }

    public class umatask : Iumatask
    {
        public void taskagora()
        {
            var init = Task.Factory.StartNew(() => 
            {
                for (int i = 0; i < 50; i++) {
                    GlobalService.conta += i;
                    Thread.Sleep(2000);
                }

            });
            init.Start();

        }

        public int retornaGlobal()
        {
            return 63;
        }
    }
}