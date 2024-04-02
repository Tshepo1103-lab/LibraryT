using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace LibraryT.Services.Notifications
{
    public class Notification
    {
        public static void SendMessage(string cell, string msg)
        {
            //API keys
            string accountId = "AC0066c7badbaba39e3655cd80ed196139";
            string authToken = "e7e07a2fefe0e485d5b833266ca55d65";

            TwilioClient.Init(accountId, authToken);//initialise the service in the code


            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber("+13343264453"),
                to: new Twilio.Types.PhoneNumber(cell)
            );
        }
    }
}
