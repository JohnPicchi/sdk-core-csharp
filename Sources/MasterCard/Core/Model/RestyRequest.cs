﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using MasterCard.Core.Security;

namespace MasterCard.Core.Model
{
    public class RestyRequest : RestRequest
    {
        public Uri AbsoluteUrl { get; set; }
        public Uri BaseUrl { get; set; }

        public bool HasBody { get; private set; }
        public CryptographyInterceptor interceptor { get; set; }

        public RestyRequest(Uri url, Method method) : base(url,method)
        {
        }

        public new RestyRequest AddJsonBody(object obj) {
            HasBody = true;
            return (RestyRequest) base.AddJsonBody(obj);
        }

    }
}
