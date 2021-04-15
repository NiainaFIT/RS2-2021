using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eProdaja.Model.Helpers;
namespace eProdaja.WinUI
{
    public class APIService
    {
        //1. dodati properti koji ce pokazivati koji kontroler koristim
        private string _route = null;
        public APIService(string route)//kontroler
        {
            _route = route;
        }
        //2. Izdvojiti api putanju u Properties.Settings
        //3. Kreirati asinhrone pozive na api
        public async Task<T> GetAll<T>(object request)
        {

            var url = $"{ Properties.Settings.Default.ApiURL}/{_route}";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();
            }
            var result= await url.GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{ Properties.Settings.Default.ApiURL}/{_route}/{id}";
            var result = await url.GetJsonAsync();
            return result;
        }
        public async Task<T> Insert<T>(object insertRequest)
        {
            var url = $"{ Properties.Settings.Default.ApiURL}/{_route}";
            var result = await url.PostJsonAsync(insertRequest).ReceiveJson<T>();
            return result;
        }
        public async Task<T> Update<T>(object id, object updateRequest)
        {
            var url = $"{ Properties.Settings.Default.ApiURL}/{_route}/{id}";
            var result = await url.PutJsonAsync(updateRequest).ReceiveJson<T>(); ;
            return result;
        }
    }
}
