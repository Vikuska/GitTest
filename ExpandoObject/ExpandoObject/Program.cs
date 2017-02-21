using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = new System.Dynamic.ExpandoObject();

            obj.ClientIp = "127.0.0.1";
            obj.UserName = "suresh";
            obj.AppUser = "ncmobile";
            obj.AppCredential = "Gd31t6iF1HcS1NNYCK4A9AWnxuR3XDWq20gfTYOde%2bDfWO3vRdiBAQymBrz%2b2ODsepsqyKDgcEHUj0PH0fCJeqBmi3u8EVDpNmNL6Qw8xy0b6ztwnAHV9iMpW1uOtCt2xLUBideOd%2bZNnBHf7g21ck%2fd3FPExJg1xo6SSgZ1tyrvjzRyscxJW3lS4ysutc0GwfeBF412T8pM7TxqItW4FQ%3d%3d";
            obj.KeyVersion = "v1";

            //var res = (IDictionary<string, object>)obj;
            var res = new List<KeyValuePair<string, string>>();

            foreach (var o in obj)
                res.Add(new KeyValuePair<string, string>(o.Key, o.Value));


            var dic = new[]
            {
                new KeyValuePair<string, string>("ClientIp", "127.0.0.1"),
                new KeyValuePair<string, string>("UserName", "suresh"),
                new KeyValuePair<string, string>("AppUser", "ncmobile"),
                new KeyValuePair<string, string>("AppCredential",
                    "Gd31t6iF1HcS1NNYCK4A9AWnxuR3XDWq20gfTYOde%2bDfWO3vRdiBAQymBrz%2b2ODsepsqyKDgcEHUj0PH0fCJeqBmi3u8EVDpNmNL6Qw8xy0b6ztwnAHV9iMpW1uOtCt2xLUBideOd%2bZNnBHf7g21ck%2fd3FPExJg1xo6SSgZ1tyrvjzRyscxJW3lS4ysutc0GwfeBF412T8pM7TxqItW4FQ%3d%3d"),
                new KeyValuePair<string, string>("KeyVersion", "v1")
            };

        }
    }
}
