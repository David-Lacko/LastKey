using System;
using System.Text;

namespace LastKey.Backend
{
    public class CreatePassword
    {
        public string GeneratePassword(int length)
        {
            const string quote = "\"";
            const string valid = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~`! @#$%^&*()_-+={[}]|\:;'<,>.?/" + quote;

            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }


            return len(res.ToString());
        }
        public string len(string password)
        {
            int add = 0;

            while ((password.Length + add) % 16 != 0)
            {
                add++;

            }
            string myString = new string(' ', add);
            return password + myString;
        }
    }

}
