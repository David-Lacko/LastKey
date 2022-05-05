using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LastKey.Backend
{
    public class SavePassword
    {
        Sha256 sha256 = new Sha256();

        public void SaveMPassword(string password)
        {
            System.IO.File.WriteAllText("Backend/Password.txt", sha256.sha256(password));

        }


        public void SavePasswords(Dictionary<string, string> passwords, string Mpassword)
        {
            List<Passwords> passwordList = new List<Passwords>();
            foreach (KeyValuePair<string, string> password in passwords)
            {
                Passwords pass = new Passwords();

                pass.Name = password.Key;
                pass.PasswordKey = StringCipher.Encrypt(password.Value, Mpassword);
                passwordList.Add(pass);
            }
            string json = JsonConvert.SerializeObject(passwordList);
            string path = "Backend/Password.json";
            File.WriteAllText(path, json);

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
