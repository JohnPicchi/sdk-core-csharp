﻿/*
 * Copyright 2016 MasterCard International.
 *
 * Redistribution and use in source and binary forms, with or without modification, are 
 * permitted provided that the following conditions are met:
 *
 * Redistributions of source code must retain the above copyright notice, this list of 
 * conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright notice, this list of 
 * conditions and the following disclaimer in the documentation and/or other materials 
 * provided with the distribution.
 * Neither the name of the MasterCard International Incorporated nor the names of its 
 * contributors may be used to endorse or promote products derived from this software 
 * without specific prior written permission.
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
 * SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER 
 * IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
 * IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 *
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;


using MasterCard.Core;
using MasterCard.Core.Exceptions;
using MasterCard.Core.Model;
using MasterCard.Core.Security.OAuth;
using MasterCard.Core.Security.MDES;



namespace TestMasterCard
{


	[TestFixture ()]
	public class JSONEchoTest
	{

		[SetUp]
		public void setup ()
		{
            ApiConfig.SetDebug (true);
            ApiConfig.SetSandbox(true);
            var path = MasterCard.Core.Util.GetCurrenyAssemblyPath();

            //Console.WriteLine("path:: " + path);

            var authentication = new OAuthAuthentication ("L5BsiPgaF-O3qA36znUATgQXwJB6MRoMSdhjd7wt50c97279!50596e52466e3966546d434b7354584c4975693238513d3d", path+"\\Test\\mcapi_sandbox_key.p12", "test", "password");
            ApiConfig.SetAuthentication (authentication);

            var interceptor = new MDESCryptography(path+ "\\Test\\mastercard_public.crt", path+ "\\Test\\mastercard_private.pem");
            ApiConfig.AddCryptographyInterceptor (interceptor);
		}


        
            
            
            
            
            
            
                        

        [Test ()]
        public void test_utf_8()
        {
            RequestMap parameters = new RequestMap();
            parameters.Add("JSONEcho.string", "мảŝťễřÇāŕď Ľẵвš ạאָđ мãśţēяĈẫřđ ĀקÏ ŕồçҝş...");



            JSONEcho response = JSONEcho.Create(parameters);

            String bodyJson = (String) response.Get("body");
            RequestMap response2 = new RequestMap(bodyJson);

            Assert.AreEqual("мảŝťễřÇāŕď Ľẵвš ạאָđ мãśţēяĈẫřđ ĀקÏ ŕồçҝş...", response2.Get("JSONEcho.string"));
            

        }
        
            
        

    }
}
