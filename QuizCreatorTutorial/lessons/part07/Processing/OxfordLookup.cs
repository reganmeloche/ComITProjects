using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuizCreator.Part7
{
    public class OxfordLookup : ILookupAWord
    {
        private readonly string _url;
        private readonly string _appId;
        private readonly string _appKey;
        private readonly string _languageCode;

        public OxfordLookup(string url, string appId, string appKey, string languageCode) {
            _url = url;
            _appId = appId;
            _appKey = appKey;
            _languageCode = languageCode;
        }

        public CoreWord Lookup(string word) {
            var result = new CoreWord(word);

            try {
                string fullUrl = $"{_url}{_languageCode}/{word}?fields=definitions&strictMatch=false";
                var webRequest = WebRequest.Create(fullUrl);
                if (webRequest != null) {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("app_id", _appId);
                    webRequest.Headers.Add("app_key", _appKey);

                    using (Stream s = webRequest.GetResponse().GetResponseStream()) {
                        using (StreamReader sr = new StreamReader(s)) {
                            var jsonResponse = sr.ReadToEnd();
                            var jsonObject = JObject.Parse(jsonResponse);
                            string wordType = (string)jsonObject["results"][0]["lexicalEntries"][0]["lexicalCategory"]["id"];
                            result.WordType = wordType;
                        }
                    }
                }
            } catch (Exception ex) {
                // Console.WriteLine(ex.ToString());
            }
            return result;
        }

    }
}