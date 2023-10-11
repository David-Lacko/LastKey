using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LastKey.Backend
{
    public class LoadPassword
    {
        Sha256 sha256 = new Sha256();
        public bool LoadMPassword(string password)
        {
            string sha = sha256.sha256(password);
            string text = File.ReadAllText("Backend/Password.txt");
            
            if (sha == text)
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, string> LoadPasswords(string MPassword)
        {
            string json = File.ReadAllText("Backend/Password.json");


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                List<Passwords> passwords = JsonConvert.DeserializeObject<List<Passwords>>(json);

                foreach (Passwords password in passwords)
                {
                    try
                    {
                        dictionary.Add(password.Name, StringCipher.Decrypt(password.PasswordKey, MPassword));
                    }
                    catch (ArgumentException) { }

                }

                return dictionary;
            }
            catch (NullReferenceException)
            {
                return dictionary;
            }
        }
        private class Passwords
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("passwordKey")]
            public string PasswordKey { get; set; }
        }
    }
}
