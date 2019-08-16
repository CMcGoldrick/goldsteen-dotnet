using Newtonsoft.Json;
using PotOfMcGold.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PotOfMcGold.Controllers.Api
{
    public class CryptoDetailsController : ApiController
    {
        //const string key1 = "a07362a5a5460d736395ff2f3f17a26c8e4004c4";
        //const string key2 = "01df8d4747ed7584b4c1b9df5c0a9a984357f468";

        class ApiCall
        {
            public static string DoIt(string url)
            {
                var time = DateTime.Now;
                string key;
                if (time.Hour % 2 == 0)
                { key = "01df8d4747ed7584b4c1b9df5c0a9a984357f468"; }
                else
                { key = "a07362a5a5460d736395ff2f3f17a26c8e4004c4"; }

                var client = new RestClient();
                var request = new RestRequest(url, Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-API-Key", key);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                //detail content
                //var content = "{\"payload\":{\"assetId\":\"ETH\",\"originalSymbol\":\"ETH\",\"name\":\"Ethereum\",\"slug\":\"ethereum\",\"cryptoType\":true,\"supply\":106898516.08,\"marketCap\":22283428019.033764,\"price\":211.49721688662027,\"volume\":4653107294.779797,\"change\":1.2133237854466536,\"change1Hour\":1.2503266736810494,\"change1Week\":-0.09790703333421434,\"allTimeHigh\":3398.681106007839,\"allTimeLow\":12.793825364720972,\"earliestKnownPrice\":12.793825364720972,\"earliestTradeDate\":1487265353,\"logo\":{\"mimeType\":\"image\\/svg+xml\",\"imageData\":\"PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIzMiIgaGVpZ2h0PSIzMiI+PGcgZmlsbD0ibm9uZSIgZmlsbC1ydWxlPSJldmVub2RkIj48Y2lyY2xlIGN4PSIxNiIgY3k9IjE2IiByPSIxNiIgZmlsbD0iIzYyN0VFQSIvPjxnIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyI+PHBhdGggZmlsbC1vcGFjaXR5PSIuNjAyIiBkPSJNMTYuNDk4IDR2OC44N2w3LjQ5NyAzLjM1eiIvPjxwYXRoIGQ9Ik0xNi40OTggNEw5IDE2LjIybDcuNDk4LTMuMzV6Ii8+PHBhdGggZmlsbC1vcGFjaXR5PSIuNjAyIiBkPSJNMTYuNDk4IDIxLjk2OHY2LjAyN0wyNCAxNy42MTZ6Ii8+PHBhdGggZD0iTTE2LjQ5OCAyNy45OTV2LTYuMDI4TDkgMTcuNjE2eiIvPjxwYXRoIGZpbGwtb3BhY2l0eT0iLjIiIGQ9Ik0xNi40OTggMjAuNTczbDcuNDk3LTQuMzUzLTcuNDk3LTMuMzQ4eiIvPjxwYXRoIGZpbGwtb3BhY2l0eT0iLjYwMiIgZD0iTTkgMTYuMjJsNy40OTggNC4zNTN2LTcuNzAxeiIvPjwvZz48L2c+PC9zdmc+\"},\"_id\":\"5b755dacd5dd99000b3d92b2\"}}";

                return content;
            }
        }

        // GET api/cryptodetails/id
        public IHttpActionResult GetCryptoDetail(string id)
        {
            string data = ApiCall.DoIt("https://api.cryptoapis.io/v1/assets/" + id);
            var serialized = JsonConvert.DeserializeObject<DetailClass.CryptoDetail>(data);
            var get = serialized.Payload;

            return Ok(
                     $"<h4 class='crypto-name-modal'><img style='padding-right:6px;' src='data:image/svg+xml;base64,{get.Logo.ImageData}'>{get.Name}</h4><table class='table table-borderless'><tbody><tr><th scope ='row'>Price</th><td>$ {get.Price}</td></tr><tr><th scope='row'>Market Cap</th><td>{get.MarketCap}</td></tr><tr><th scope'row'>Supply</th><td>{get.Supply}</td></tr><tr><th scope ='row'>Volume</th><td>{get.Volume}</td></tr><tr><th scope ='row'>24hr Change</th><td class={(get.Change > 0 ? "green" : "red")}>{get.Change} %</td></tr><tr><th scope ='row'>1hr Change</th><td class={(get.Change1Hour > 0 ? "green" : "red")}>{get.Change1Hour} %</td></tr><tr><th scope ='row'>1week Change</th><td class={(get.Change1Week > 0 ? "green" : "red")}>{get.Change1Week} %</td></tr><tr><th scope ='row'>All Time High</th><td>{get.AllTimeHigh}</td></tr><tr><th scope ='row'>All Time Low</th><td>{get.AllTimeLow}</td></tr><tr><th scope ='row'>Earliest Price</th><td>{get.EarliestKnownPrice}</td></tr></tbody></table>"
                     );
        }
    }
}



//<table class='table table-borderless'><tbody>
//    <tr>
//      <th scope = 'row' > Price </ th >
//      < td > {get.Price} </ td >
//    </ tr >
//    < tr >
//      < th scope='row'>Market Cap</th>
//      <td>{get.MarketCap}</td>
//    </tr>
//    <tr>
//      <th scope = 'row' > Supply </ th >
//      < td > {get.Supply} </ td >
//    </ tr >
//        < tr >
//      < th scope = 'row' > Volume</ th>
//      < td > {get.Volume} </ td >
//    </ tr >
//        <tr>
//      <th scope = 'row' >24hr Change </ th >
//      < td > {get.Change} </ td >
//    </ tr >
//        < tr >
//      < th scope = 'row' > 1hr Change</ th>
//      < td > { get.Change1Week} </ td >
//    </ tr >
//        <tr>
//      <th scope = 'row' > 1week Change </ th >
//      < td > { get.Change1Week} </ td >
//    </ tr >
//        < tr >
//      < th scope = 'row' > All Time High</ th>
//      < td > { get.AllTimeHigh} </ td >
//    </ tr >
//        <tr>
//      <th scope = 'row' > All Time Low </ th >
//      < td > { get.AllTimeLow} </ td >
//    </ tr >
//        < tr >
//      < th scope = 'row' > Earliest Price </ th>
//      < td > {get.EarliestKnownPrice} </ td >
//    </ tr >
//  </ tbody >

//</ table >