using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CHBB.Utility
{
    public static class Utilities
    {
        private const string ACCESS_KEY_ID = "LTAIjHhnzqDnCW3y";
        private const string ACCESS_KEY_SECRET = "PmfzM84GzCU6fPZjtDGABJKZGLEkDO";
        private const string API_VERSION = "2017-03-21";
        private const string SIGNATURE_VERSION = "1.0";

        public static string GenerateOpenAPIURL(string domain, string httpMethod, Dictionary<string, string> privateParams)
        {
            string cqsString = GenerateQueryString(privateParams);

            string stringToSign = httpMethod + "&" + HttpUtility.UrlEncode("/") + "&" + HttpUtility.UrlEncode(cqsString);

            string signature = HmacSHA1Signature(ACCESS_KEY_SECRET, stringToSign);

            return domain + "?" + cqsString + "&" + HttpUtility.UrlEncode("Signature") + "=" + HttpUtility.UrlEncode(signature);
        }

        private static string GenerateQueryString(Dictionary<string, string> privateParams)
        {
            var result = string.Empty;
            // Attach parameters:
            var publicParams = GeneratePublicParameters();
            var combinedParams = publicParams.Union(privateParams);

            foreach (var item in combinedParams)
            {
                result += item.Key + "=" + item.Value + "&";
            }

            result = result.Substring(0, result.Length - 1);

            return HttpUtility.UrlEncode(result);
        }

        private static Dictionary<string, string> GeneratePublicParameters()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("Format", "JSON");
            result.Add("Version", API_VERSION);
            result.Add("AccessKeyId", ACCESS_KEY_ID);
            // result += "Signature=JSON&";
            result.Add("SignatureMethod", "HMAC-SHA1");
            result.Add("Timestamp", String.Format("{0:s}", DateTime.Now) + "Z");
            result.Add("SignatureVersion", SIGNATURE_VERSION);
            result.Add("SignatureNonce", Guid.NewGuid().ToString());

            return result;
        }

        private static string HmacSHA1Signature(string accessKeySecret, string stringToSign)
        {
            //string key = accessKeySecret + "&";

            //Encoding encode = Encoding.GetEncoding("utf-8");
            //byte[] byteData = encode.GetBytes(stringToSign);
            //byte[] byteKey = encode.GetBytes(key);
            //HMACSHA1 hmac = new HMACSHA1(byteKey);
            //CryptoStream cs = new CryptoStream(Stream.Null, hmac, CryptoStreamMode.Write);
            //cs.Write(byteData, 0, byteData.Length);
            //cs.Close();
            //return Convert.ToBase64String(hmac.Hash);

            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(accessKeySecret);
            byte[] messageBytes = encoding.GetBytes(stringToSign);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
