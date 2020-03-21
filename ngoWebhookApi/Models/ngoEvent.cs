using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngoWebhookApi.Models
{

    public class ngoEvent
    {

        public string id { get; private set; }
        public string eventName { get; set; }
        public Order order { get; set; }

        public ngoEvent()
        {

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            id = secondsSinceEpoch.ToString();

        }

    }

    public struct Order
    {

        public string orderReference { get; set; }
        public string outletId { get; set; }
        public DateTime updateDatetime { get; set; }
        public string state { get; set; }
        public Amount amount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public AuthResponse authResponse { get; set; }
        public SavedCard savedCard { get; set; }

    }

    public struct Amount
    {

        public string currencyCode { get; set; }
        public int value { get; set; }

    }

    public struct PaymentMethod
    {

        public string expiry { get; set; }
        public string cardholderName { get; set; }
        public string name { get; set; }
        public string pan { get; set; }
        public string cvv { get; set; }

    }

    public struct AuthResponse
    {

        public string authorizationCode { get; set; }
        public bool success { get; set; }
        public string resultCode { get; set; }
        public string resultMessage { get; set; }
        public string rrn { get; set; }

    }

    public struct SavedCard
    {

        public string maskedPan { get; set; }
        public string expiry { get; set; }
        public string cardholderName { get; set; }
        public string scheme { get; set; }
        public string cardToken { get; set; }
        public bool recaptureCsc { get; set; }

    }

}
