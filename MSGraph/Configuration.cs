using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGraph
{
    public class Configuration
    {
        //ClientID
        public string ClientID
        {
            get
            {
                return "5a8a6720-011c-457b-b203-bf23dd99c6de";
            }
        }

        //Scope
        public string Scope
        {
            get
            {
                return "user.read";
            }
        }

        //RedirectUri
        public string RedirectUri
        {
            get
            {
                return "https://localhost:44315/callback";
            }
        }

        //GrantType
        public string GrandType
        {
            get
            {
                return "authorization_code";
            }
        }

        //ClientSecret
        public string ClientSecret
        {
            get
            {
                return "5XWhVJU3-jX-BoB8Pq8..60_KZU5mT1k6J";
            }
        }
    }
}
