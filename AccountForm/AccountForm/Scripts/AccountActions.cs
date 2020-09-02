using AccountForm.Scripts.Misc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccountForm.Scripts
{
    /// <summary>
    /// This class has all the functions used by the user, like register and login
    /// </summary>
    public static class AccountActions
    {
        /// <summary>
        /// This function logins the user, returns true if user exists and password matches, returns false if not
        /// </summary>
        /// <param name="values">All the values needed to make the call to the php script </param>
        /// <returns></returns>
        public static async Task<bool> Login (List<string> values)
        {
            var client = new HttpClient();
            string url = URL(values, GlobalValues.PHP_LOGIN);

            var result = await client.GetAsync(url);


            if (result.IsSuccessStatusCode)
            {
                var stringResult = await result.Content.ReadAsStringAsync();

                var resultBool = false;
                bool.TryParse(stringResult, out resultBool);

                if (resultBool) return true;
                else return false;
            }
            else
                return false;
        }

        /// <summary>
        /// This function register an account if possible, returns true if success or false if the registration failed
        /// </summary>
        /// <param name="values">All the values needed to make the call to the php script</param>
        /// <returns></returns>
        public static async Task<bool> RegisterAccount (List<string> values)
        {
            var client = new HttpClient();
            string url = URL(values, GlobalValues.PHP_REGISTER);

            var result = await client.GetAsync(url);



            if (result.IsSuccessStatusCode)
            {
                var stringResult = await result.Content.ReadAsStringAsync();

                var resultBool = false;
                bool.TryParse(stringResult, out resultBool);

                if (resultBool) return true;
                else return false;
            }
            else
                return false;
        }

        /// <summary>
        /// This function creates the url with the values for the PHP call
        /// </summary>
        /// <param name="values">All the values needed by the php script</param>
        /// <param name="php_url">The url for the php script</param>
        /// <returns></returns>
        private static string URL (List<string> values, string php_url)
        {
            var url = php_url;

            for (int i = 0; i < values.Count; i++)
            {
                if(i == 0)
                {
                    url += $"?{values[i]}";
                    continue;
                }

                url += $"&{values[i]}";
            }

            return url;
        }
    }
}
