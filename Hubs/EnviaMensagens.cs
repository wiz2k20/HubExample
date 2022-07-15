using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newchat.Hubs
{
    [HubName("enviahohoho")]
    public class EnviaMensagens : Hub
    {
        
        [HubMethodName("sendhohoho")]
        public void SendNow(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}