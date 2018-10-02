using System;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using WebAspCoreDapper.Interfaces;

namespace WebAspCoreDapper.Services
{
    public class ContactService : IContactService
    {
        public string GetRandomString(Int32 minLen, Int32 maxLen, Int32 seed)
        {
            int minL = (int)minLen;
            int maxL = (int)maxLen;

            if (minL <= 0 || minL > maxL)
            { return new string(string.Empty); }
            else
            {
                var sd = (int)seed;
                var r = new Random();
                if (sd != 0)
                {
                    r = new Random(sd);
                }

                var i = r.Next(minL, maxL + 1);
                byte[] rnd = new byte[i];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetNonZeroBytes(rnd);
                    string rs = Convert.ToBase64String(rnd);
                    rs = rs.Substring(0, i);
                    return new string(rs);
                }
            }
        } //fn_random_string


        public SqlString GetRandomPattern(SqlString pat, SqlInt32 seed)
        {
            string pattern = pat.ToString();
            if (pattern == string.Empty)
            { return new SqlString(string.Empty); }
            else
            {
                string CharList = "abcdefghijklmnopqrstvvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string NumList = "0123456789";
                char[] clA = CharList.ToCharArray();
                char[] nlA = NumList.ToCharArray();
                int sd = (int)seed;
                Random rnd = new Random();
                if (sd != 0)
                {
                    rnd = new Random(sd);
                }

                StringBuilder sb = new StringBuilder(pattern.Length);

                char[] a = pattern.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    switch (a[i])
                    {
                        case '@':
                            sb.Append(clA[rnd.Next(0, CharList.Length)]);
                            break;
                        case '!':
                            sb.Append(nlA[rnd.Next(0, NumList.Length)]);
                            break;
                        default:
                            sb.Append(a[i]);
                            break;
                    }
                }//for
                return new SqlString(sb.ToString());
            }//else
        } // fn_random_pattern

        public DateTime GetRandomDateTime()
        {
            return DateTime.Now.AddDays(new Random().Next(1000));
        }

    }
}
