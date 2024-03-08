
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using FirmaRemotaAruba.UniCtArubaSignServiceReference;
using System;
using System.Net;
using System.ServiceModel;

namespace FirmaRemotaAruba
{
    public static class SignService
    {
        static string certID = "AS0";
        static string typeHSM = "COSIGN";
        static string typeOtpAuth = "IK1";
        static string signAttr = "LT";
        
        public static Byte[] signFile(Byte[] byteStream, string username, string password, string otp, string signType, out string error)
        {
            error = "";

            // ==========================================
            // Client
            // ==========================================
            ArubaSignServiceClient client = new ArubaSignServiceClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            BasicHttpBinding binding = (BasicHttpBinding)client.Endpoint.Binding;
            binding.MaxReceivedMessageSize = 1048576 * 100;

            // ==========================================
            // Posizione e attributi
            // ==========================================
            pdfSignApparence apparence = new pdfSignApparence() { leftx = 50, lefty = 50, rightx = 50, righty = 50, page = 1 };
            dictionarySignedAttributes attributes = new dictionarySignedAttributes() { t = signAttr };

            auth auth = new auth()
            {
                typeHSM = typeHSM,
                typeOtpAuth = typeOtpAuth,
                user = username,
                userPWD = password,
                otpPwd = otp
            };

            signRequestV2 signRequest = new signRequestV2()
            {
                certID = certID,
                transport = typeTransport.BYNARYNET,
                identity = auth,
                binaryinput = byteStream,
                requiredmark = true
            };

            // ==========================================
            // Signature PAdES_pdf
            // ==========================================
            if (signType == "P")
            {
                signReturnV2 signReturn = client.pdfsignatureV2(signRequest, apparence, pdfProfile.BASIC, password, attributes);
                if (signReturn.status == "OK")
                    return signReturn.binaryoutput;
                else
                    error = signReturn.description;
            }
            // ==========================================
            // Signature CAdES_p7m
            // ==========================================
            else
            {
                signReturnV2 signReturn = client.pkcs7signV2(signRequest, false, true);
                if (signReturn.status == "OK")
                    return signReturn.binaryoutput;
                else
                    error = signReturn.description;
            }

            return null;
        }
    }
}
