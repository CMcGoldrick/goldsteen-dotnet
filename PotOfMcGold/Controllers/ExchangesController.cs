﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using PotOfMcGold.Models;
using Newtonsoft.Json;

namespace PotOfMcGold.Controllers
{
    [Authorize]
    public class ExchangesController : Controller
    {
        const string key1 = "a07362a5a5460d736395ff2f3f17a26c8e4004c4";
        const string key2 = "01df8d4747ed7584b4c1b9df5c0a9a984357f468";

        class ApiCall
        {
            public static string DoIt(string url)
            {
                var time = DateTime.Now;
                string key;
                if (time.Hour % 2 == 0)
                { key = "a07362a5a5460d736395ff2f3f17a26c8e4004c4"; }
                else
                { key = "01df8d4747ed7584b4c1b9df5c0a9a984357f468"; }

                //var client = new RestClient();
                //var request = new RestRequest(url, Method.GET);
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("X-API-Key", key);

                //IRestResponse response = client.Execute(request);
                //var content = response.Content;

                var content = "{\"meta\":{\"totalCount\":155,\"index\":0,\"limit\":500,\"results\":155},\"payload\":[{\"exchangeId\":\"BINANCE\",\"name\":\"Binance\",\"website\":\"https:\\/\\/www.binance.com\\/\",\"logo\":{\"mimeType\":\"image\\/svg+xml\",\"imageData\":\"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+Cjxzdmcgd2lkdGg9Ijg5M3B4IiBoZWlnaHQ9IjEwM3B4IiB2aWV3Qm94PSIwIDAgODkzIDEwMyIgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIj4KICAgIDwhLS0gR2VuZXJhdG9yOiBTa2V0Y2ggMy42LjEgKDI2MzEzKSAtIGh0dHA6Ly93d3cuYm9oZW1pYW5jb2RpbmcuY29tL3NrZXRjaCAtLT4KICAgIDx0aXRsZT5sb2dvPC90aXRsZT4KICAgIDxkZXNjPkNyZWF0ZWQgd2l0aCBTa2V0Y2guPC9kZXNjPgogICAgPGRlZnMvPgogICAgPGcgaWQ9IlBhZ2UtMSIgc3Ryb2tlPSJub25lIiBzdHJva2Utd2lkdGg9IjEiIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0iZXZlbm9kZCI+CiAgICAgICAgPGcgaWQ9ImxvZ28iIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0xMjkuMzk1ODExLCAtOTM2LjAwMDAwMCkiPgogICAgICAgICAgICA8ZyBpZD0ibG9nby13LWJnLW9uLWRhcmsiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAuMDAwMDAwLCA4NDkuMDAwMDAwKSI+CiAgICAgICAgICAgICAgICA8ZyBpZD0ibG9nbyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMTMwLjAwMDAwMCwgODcuMDAwMDAwKSI+CiAgICAgICAgICAgICAgICAgICAgPHBhdGggZD0iTTc5MS45MzU5MzcsODguNDEzNTI0MyBDNzk2LjczMTMzMSw5My40OTE4Mjc4IDgyMy4wNzA3NzQsMTE3LjgzMTUyNyA4NjQuNDEzNjU2LDg5LjU4MzQwMjkgQzg5NC4zMDg4MDEsNjYuMzAyMDMxIDg5My41NjE5NDQsMTUuODI2OTY4NiA4OTAuNjkwMDMxLDAuNTg0NDM5NDA2IEM4ODkuNjg5NTQ5LDIuODAyNzM3NjQgODU0Ljk2NTQyNyw3OC44NDM3ODU5IDc5MS45MzU5MzcsODguNDEzNTI0MyBaIE04OTAuNjg2MDA4LDAuNTcxNTM3OTM3IEM4OTAuMzE5ODI4LDAuNDIwMjcxMDI3IDg1MS44NTgzMzksLTQuODIzNDQ0MzkgODEzLjgzNjAxNiwxOS42NjU4NzA1IEM3OTAuMjI1NDIyLDM0Ljg3MjkxNzIgNzg3LjEwNDM5NSw1Ny4xMzAwODM2IDc4OC4xODE2NTEsNzEuOTYwOTc2OCBDODQzLjQ1NDc0Nyw2NS43NzU2MjA0IDg4OS40MzIxOSwyLjMxNTM2OTIgODkwLjY4NjAwOCwwLjU3MTUzNzkzNyBaIiBpZD0iUGF0aC0xLUNvcHktOSIgZmlsbD0iIzk3QzU1NCIvPgogICAgICAgICAgICAgICAgICAgIDxwYXRoIGQ9Ik04OTAuNjg2MDA4LDAuNTcxNTM3OTM3IEM4OTAuMzE5ODI4LDAuNDIwMjcxMDI3IDg1MS44NTgzMzksLTQuODIzNDQ0MzkgODEzLjgzNjAxNiwxOS42NjU4NzA1IEM3OTAuMjI1NDIyLDM0Ljg3MjkxNzIgNzg3LjEwNDM5NSw1Ny4xMzAwODM2IDc4OC4xODE2NTEsNzEuOTYwOTc2OCBDODQzLjQ1NDc0Nyw2NS43NzU2MjA0IDg4OS40MzIxOSwyLjMxNTM2OTIgODkwLjY4NjAwOCwwLjU3MTUzNzkzNyBaIiBpZD0iUGF0aC0xLUNvcHktOCIgZmlsbD0iIzcwOUIzMCIvPgogICAgICAgICAgICAgICAgICAgIDxwYXRoIGQ9Ik02MS42NTksODUuNDQ1IEwxOC42MDMsODUuNDQ1IEwxOC42MDMsNjIuNTEzIEw2MS42NTksNjIuNTEzIEM3Mi40MjMsNjIuNTEzIDc3LjkyMiw2Ny42NjEgNzcuOTIyLDc0LjMzIEM3Ny45MjIsODAuNzY1IDcyLjU0LDg1LjQ0NSA2MS42NTksODUuNDQ1IEw2MS42NTksODUuNDQ1IFogTTYwLjI1NSw1MC4yMjggTDE4LjYwMyw1MC4yMjggTDE4LjYwMywzMC45MjMgTDYwLjI1NSwzMC45MjMgQzcxLjYwNCwzMC45MjMgNzYuMDUsMzQuOTAxIDc2LjA1LDQwLjQgQzc2LjA1LDQ1LjQzMSA3MC45MDIsNTAuMjI4IDYwLjI1NSw1MC4yMjggTDYwLjI1NSw1MC4yMjggWiBNNzEuMjUzLDU2LjA3OCBDODkuMzg4LDU1LjQ5MyA5NS45NCw0Ni40ODQgOTUuOTQsMzYuNjU2IEM5NS45NCwyNS44OTIgODcuMzk5LDE3IDY2LjU3MywxNyBMMCwxNyBMMCw5OS4xMzQgTDY4LjU2Miw5OS4xMzQgQzg1LjY0NCw5OS4xMzQgOTguMzk3LDkxLjk5NyA5OC4zOTcsNzYuNjcgQzk4LjM5Nyw2NS43ODkgOTEuMjYsNTYuNTQ2IDcxLjI1Myw1Ni4wNzggTDcxLjI1Myw1Ni4wNzggWiBNMTIwLjM2OSwxNyBMMTIwLjM2OSw5OS4xMzQgTDEzOC45NzIsOTkuMTM0IEwxMzguOTcyLDE3IEwxMjAuMzY5LDE3IFogTTIxNC40MTI5OTksMzIuNTYxIEwyNTUuMzYyOTk5LDMyLjU2MSBMMjU1LjM2Mjk5OSwxNyBMMTU0Ljg1OTk5OSwxNyBMMTU0Ljg1OTk5OSwzMi41NjEgTDE5NS44MDk5OTksMzIuNTYxIEwxOTUuODA5OTk5LDk5LjEzNCBMMjE0LjQxMjk5OSw5OS4xMzQgTDIxNC40MTI5OTksMzIuNTYxIFogTTI3MS4yNTA5OTksMTcgTDI3MS4yNTA5OTksOTkuMTM0IEwyODkuODUzOTk5LDk5LjEzNCBMMjg5Ljg1Mzk5OSw2Ny4wNzYgTDMzMy40OTQ5OTksNjcuMDc2IEwzMzMuNDk0OTk5LDUzLjYyMSBMMjg5Ljg1Mzk5OSw1My42MjEgTDI4OS44NTM5OTksMzEuMTU3IEwzNjAuNzU1OTk5LDMxLjE1NyBMMzYwLjc1NTk5OSwxNyBMMjcxLjI1MDk5OSwxNyBaIE0zNzUuODI0OTk4LDE3IEwzNzUuODI0OTk4LDk5LjEzNCBMMzk0LjQyNzk5OCw5OS4xMzQgTDM5NC40Mjc5OTgsMTcgTDM3NS44MjQ5OTgsMTcgWiBNNDM4LjA0NDk5OCwzNy4wMDcgTDQ5OS43MDM5OTgsOTkuMTM0IEw1MjAuNzYzOTk4LDk5LjEzNCBMNTIwLjc2Mzk5OCwxNyBMNTAyLjM5NDk5OCwxNyBMNTAyLjM5NDk5OCw3Ni4yMDIgTDQ0My4xOTI5OTgsMTcgTDQxOS41NTg5OTgsMTcgTDQxOS41NTg5OTgsOTkuMTM0IEw0MzguMDQ0OTk4LDk5LjEzNCBMNDM4LjA0NDk5OCwzNy4wMDcgWiBNNTQ1Ljg5NDk5OCwxNyBMNTQ1Ljg5NDk5OCw5OS4xMzQgTDYzNi45MjA5OTgsOTkuMTM0IEw2MzYuOTIwOTk4LDg1LjMyOCBMNTY0LjQ5Nzk5OCw4NS4zMjggTDU2NC40OTc5OTgsNjIuNzQ3IEw2MDcuOTA0OTk4LDYyLjc0NyBMNjA3LjkwNDk5OCw0OS45OTQgTDU2NC40OTc5OTgsNDkuOTk0IEw1NjQuNDk3OTk4LDMxLjE1NyBMNjM2LjkyMDk5OCwzMS4xNTcgTDYzNi45MjA5OTgsMTcgTDU0NS44OTQ5OTgsMTcgWiBNNzYxLjUwMTk5NywxNyBMNzM2LjkzMTk5NywxNyBMNzA1LjU3NTk5Nyw0NS44OTkgTDY3NC40NTM5OTcsMTcgTDY0OS41MzI5OTcsMTcgTDY5My4yOTA5OTcsNTcuNDgyIEw2NDcuODk0OTk3LDk5LjEzNCBMNjcyLjQ2NDk5Nyw5OS4xMzQgTDcwNS4zNDE5OTcsNjguODMxIEw3MzguMTAxOTk3LDk5LjEzNCBMNzYzLjEzOTk5Nyw5OS4xMzQgTDcxNy42MjY5OTcsNTcuMzY1IEw3NjEuNTAxOTk3LDE3IFoiIGlkPSJCSVRGSU5FWC1Db3B5LTMiIGZpbGw9IiNEREREREQiLz4KICAgICAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPC9nPgogICAgICAgIDwvZz4KICAgIDwvZz4KPC9zdmc+\"},\"_id\":\"5b1ea9d21090c200146f7362\"},{\"exchangeId\":\"COINBASE\",\"name\":\"GDAX\",\"website\":\"https:\\/\\/www.gdax.com\\/\",\"_id\":\"5b1ea9d21090c200146f7363\"},{\"exchangeId\":\"BITSTAMP\",\"name\":\"Bitstamp Ltd.\",\"website\":\"https:\\/\\/www.bitstamp.net\\/\",\"_id\":\"5b1ea9d21090c200146f7364\"},{\"exchangeId\":\"OKCOIN_CNY\",\"name\":\"OKCoin CNY\",\"website\":\"https:\\/\\/www.okcoin.cn\\/\",\"_id\":\"5b1ea9d21090c200146f7365\"},{\"exchangeId\":\"BITTREX\",\"name\":\"Bittrex\",\"website\":\"https:\\/\\/bittrex.com\\/\",\"logo\":{\"mimeType\":\"image\\/svg+xml\",\"imageData\":\"PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI0MTkiIGhlaWdodD0iMTQyIiBmaWxsPSJub25lIiB2aWV3Qm94PSIwIDAgNDE5IDE0MiI+CiAgICA8ZyBmaWx0ZXI9InVybCgjYSkiPgogICAgICAgIDxwYXRoIGZpbGw9IiMwMDg0RDQiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZD0iTTQ2LjM3NCA0Mi41NTl2LTEyLjU1aDYzLjA1NHY2My4wN0g0Ni4zNzR2LTMzLjNoNy44ODJ2MjUuNDE2aDQ3LjI5VjM3Ljg5MWgtNDcuMjl2NC42NjhoLTcuODgyek0zMC4wMSAxMTAuODJWNDcuNzQ3aDYzLjA1MnYzMi43OTVoLTcuODh2LTI0LjkxSDM3Ljg4OXY0Ny4zMDRoNDcuMjkydi01LjE3NWg3Ljg4djEzLjA1OUgzMC4wMDl6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiLz4KICAgICAgICA8cGF0aCBmaWxsPSIjZmZmIiBkPSJNMTQ3LjIxNSAxMTAuOTI2VjkzLjY2OWgyLjAwN3YxNy4yNTdoLTIuMDA3em0yMy44NTggMGgtMi4yOWwtOS40MzEtMTQuNDgzaC0uMDk1Yy4xMjYgMS43LjE4OSAzLjI1OC4xODkgNC42NzR2OS44MDloLTEuODUzVjkzLjY2OWgyLjI2Nmw5LjQwOCAxNC40MjRoLjA5NGMtLjAxNi0uMjEyLS4wNTEtLjg5My0uMTA2LTIuMDQyLS4wNTUtMS4xNTYtLjA3NS0xLjk4My0uMDU5LTIuNDc4di05LjkwNGgxLjg3N3YxNy4yNTd6bTEzLjY4MyAwaC0yLjAwN1Y5NS40NTFoLTUuNDY1VjkzLjY3aDEyLjkzN3YxLjc4MmgtNS40NjV2MTUuNDc1em0yMS4zMiAwaC05LjYyVjkzLjY2OWg5LjYydjEuNzgyaC03LjYxNHY1LjU2aDcuMTUzdjEuNzcxaC03LjE1M3Y2LjM1aDcuNjE0djEuNzk0em05LjQ2OS03LjE3NnY3LjE3NmgtMi4wMDdWOTMuNjY5aDQuNzMzYzIuMTE3IDAgMy42NzkuNDA1IDQuNjg2IDEuMjE2IDEuMDE1LjgxIDEuNTIzIDIuMDMgMS41MjMgMy42NiAwIDIuMjgxLTEuMTU3IDMuODI0LTMuNDcgNC42MjZsNC42ODYgNy43NTVoLTIuMzczbC00LjE3OC03LjE3NmgtMy42em0wLTEuNzI0aDIuNzVjMS40MTYgMCAyLjQ1NS0uMjc5IDMuMTE2LS44MzguNjYxLS41NjYuOTkyLTEuNDEyLjk5Mi0yLjUzOCAwLTEuMTQtLjMzOS0xLjk2My0xLjAxNi0yLjQ2Ny0uNjY4LS41MDMtMS43NDctLjc1NS0zLjIzNC0uNzU1aC0yLjYwOHY2LjU5OHptMzAuMDQzIDguOWgtMi4yOWwtOS40MzItMTQuNDgzaC0uMDk0Yy4xMjYgMS43LjE4OSAzLjI1OC4xODkgNC42NzR2OS44MDloLTEuODUzVjkzLjY2OWgyLjI2Nmw5LjQwOCAxNC40MjRoLjA5NGMtLjAxNi0uMjEyLS4wNTEtLjg5My0uMTA2LTIuMDQyLS4wNTUtMS4xNTYtLjA3NS0xLjk4My0uMDU5LTIuNDc4di05LjkwNGgxLjg3N3YxNy4yNTd6bTE5LjIxOCAwbC0yLjE0OC01LjQ4OGgtNi45MTdsLTIuMTI1IDUuNDg4aC0yLjAzbDYuODIzLTE3LjMyOGgxLjY4OGw2Ljc4NyAxNy4zMjhoLTIuMDc4em0tMi43NzMtNy4yOTRsLTIuMDA3LTUuMzQ4YTI4LjcwOCAyOC43MDggMCAwIDEtLjgwMy0yLjQ5IDIyLjQ1NSAyMi40NTUgMCAwIDEtLjc0MyAyLjQ5bC0yLjAzMSA1LjM0OGg1LjU4NHptMTYuMTYxIDcuMjk0aC0yLjAwNlY5NS40NTFoLTUuNDY1VjkzLjY3aDEyLjkzNnYxLjc4MmgtNS40NjV2MTUuNDc1em0xMS43IDBWOTMuNjY5aDIuMDA3djE3LjI1N2gtMi4wMDd6bTI1LjM1Ny04LjY1MmMwIDIuNzYyLS43IDQuOTM0LTIuMTAxIDYuNTE2LTEuMzkzIDEuNTgyLTMuMzMzIDIuMzcyLTUuODE5IDIuMzcyLTIuNTQyIDAtNC41MDUtLjc3NS01Ljg5LTIuMzI1LTEuMzc3LTEuNTU4LTIuMDY2LTMuNzU0LTIuMDY2LTYuNTg2IDAtMi44MS42OTItNC45ODYgMi4wNzctNi41MjggMS4zODUtMS41NSAzLjM1My0yLjMyNSA1LjkwMi0yLjMyNSAyLjQ3OSAwIDQuNDE1Ljc4NyA1LjgwOCAyLjM2IDEuMzkzIDEuNTc0IDIuMDg5IDMuNzQ2IDIuMDg5IDYuNTE2em0tMTMuNzUxIDBjMCAyLjMzNy40OTUgNC4xMTIgMS40ODcgNS4zMjQuOTk5IDEuMjA0IDIuNDQ3IDEuODA2IDQuMzQ0IDEuODA2IDEuOTEyIDAgMy4zNTYtLjYwMiA0LjMzMi0xLjgwNi45NzYtMS4yMDQgMS40NjMtMi45NzkgMS40NjMtNS4zMjQgMC0yLjMyMS0uNDg3LTQuMDgtMS40NjMtNS4yNzYtLjk2OC0xLjIwNC0yLjQwNC0xLjgwNi00LjMwOS0xLjgwNi0xLjkxMiAwLTMuMzY4LjYwNi00LjM2NyAxLjgxOC0uOTkyIDEuMjA0LTEuNDg3IDIuOTU4LTEuNDg3IDUuMjY0em0zNC43MTcgOC42NTJoLTIuMjlsLTkuNDMxLTE0LjQ4M2gtLjA5NWMuMTI2IDEuNy4xODkgMy4yNTguMTg5IDQuNjc0djkuODA5aC0xLjg1M1Y5My42NjloMi4yNjZsOS40MDggMTQuNDI0aC4wOTRjLS4wMTUtLjIxMi0uMDUxLS44OTMtLjEwNi0yLjA0Mi0uMDU1LTEuMTU2LS4wNzUtMS45ODMtLjA1OS0yLjQ3OHYtOS45MDRoMS44Nzd2MTcuMjU3em0xOS4yMTkgMGwtMi4xNDgtNS40ODhoLTYuOTE3bC0yLjEyNSA1LjQ4OGgtMi4wM2w2LjgyMi0xNy4zMjhoMS42ODhsNi43ODcgMTcuMzI4aC0yLjA3N3ptLTIuNzc0LTcuMjk0bC0yLjAwNy01LjM0OGEyOC43NCAyOC43NCAwIDAgMS0uODAyLTIuNDkgMjIuMjYyIDIyLjI2MiAwIDAgMS0uNzQ0IDIuNDlsLTIuMDMgNS4zNDhoNS41ODN6bTEwLjg1IDcuMjk0VjkzLjY2OWgyLjAwN3YxNS40NGg3LjYxM3YxLjgxN2gtOS42MnoiLz4KICAgICAgICA8cGF0aCBmaWxsPSIjZmZmIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0zNDEuMDcxIDYzLjUzaC0xOS4zOTN2MTYuNzM3aDIxLjY0N3Y0LjM3MmgtMjYuODM2VjM4LjQ2aDI2LjYyOXY0LjM3MmgtMjEuNDR2MTYuNTMyaDE5LjM5M3Y0LjE2NnptLTE2NC4yNCAyMS4xMDdoNS4xODlWMzguNDZoLTUuMTg5djQ2LjE3NnptLTI2Ljk3Ni00LjM3aC0xMC43OVY2My4zMjRoMTEuMTk5YzUuODczIDAgOS42OTYgMy40MTYgOS42OTYgOC42NzYgMCA1LjE5LTMuNzU1IDguMjY1LTEwLjEwNSA4LjI2NXptLTEwLjc5LTM3LjQzNGg5LjQyM2M1Ljg3MiAwIDkuMjg3IDIuODcgOS4yODcgNy41ODMgMCA1LjM5Ny0zLjQxNSA4LjgxMi04LjY3MSA4LjgxMmgtMTAuMDM5VjQyLjgzM3ptMTYuNDU2IDE4LjAzNGM0LjkxOC0xLjUwMiA3LjU4MS01LjMyOSA3LjU4MS0xMC44NiAwLTcuMjQyLTUuMzk1LTExLjU0NC0xNC42MTQtMTEuNTQ0aC0xNC42MTJ2NDYuMTc1aDE1Ljk3OWM5LjY5NiAwIDE1LjQzMi00LjcxMyAxNS40MzItMTIuNjM2IDAtNS41MzQtMy42MTktOS43MDEtOS43NjYtMTEuMTM1em01MC42NzYtMTguMDMzaC0xMy4wNDRWMzguNDZoMzEuMTQxdjQuMzczaC0xMi45MDh2NDEuODAzaC01LjE4OVY0Mi44MzR6bTI1LjYwOSAwaDEzLjA0NHY0MS44MDNoNS4xODhWNDIuODM0aDEyLjkwOFYzOC40NmgtMzEuMTR2NC4zNzN6bTYxLjQ2MyAyMy4yOTJjNi4xNDctMS40MzQgMTAuMDM5LTYuMDc4IDEwLjAzOS0xMy41MjUgMC04Ljg4LTYuMDExLTE0LjEzOS0xNi4xODYtMTQuMTM5aC0xMy4zMTV2NDYuMTc1aDUuMTg5VjY2Ljc0Mmg5Ljk3bDEwLjAzOSAxNy44OTVoNi4xNDVsLTEwLjUxNi0xNy4xNDUtMS4zNjUtMS4zNjZ6bTgwLjU4NS01LjA1NGwxMy43MjYtMjIuNTQzaC02LjI4NGwtMTAuMzExIDE4LjMwNy0uNDA5IDEuNzc3LS40MDktMS43NzctMTAuMzExLTE4LjMwNmgtNi4yMTNsMTMuNzI1IDIyLjU0Mi0xNC4xMzcgMjMuNTY3aDYuMzUybDEwLjU4NC0xOC45OS40MDktMS43NzguNDA5IDEuNzc3IDEwLjY1NCAxOC45OWg2LjM1MmwtMTQuMTM3LTIzLjU2NnptLTk0LjkyNiAxLjU3aDguODFjNi4xNDQgMCAxMC4zMTEtMy4zNDcgMTAuMzExLTEwLjA0MSAwLTYuMTQ3LTMuNjg3LTkuNzY3LTkuOTcxLTkuNzY3aC05LjE1djE5LjgwOXoiIGNsaXAtcnVsZT0iZXZlbm9kZCIvPgogICAgPC9nPgogICAgPGRlZnM+CiAgICAgICAgPGZpbHRlciBpZD0iYSIgd2lkdGg9IjQzMy4xMDYiIGhlaWdodD0iMTQ3LjA0NSIgeD0iLTMuMTA5IiB5PSItMy4xMDkiIGNvbG9yLWludGVycG9sYXRpb24tZmlsdGVycz0ic1JHQiIgZmlsdGVyVW5pdHM9InVzZXJTcGFjZU9uVXNlIj4KICAgICAgICAgICAgPGZlRmxvb2QgZmxvb2Qtb3BhY2l0eT0iMCIgcmVzdWx0PSJCYWNrZ3JvdW5kSW1hZ2VGaXgiLz4KICAgICAgICAgICAgPGZlQ29sb3JNYXRyaXggaW49IlNvdXJjZUFscGhhIiB2YWx1ZXM9IjAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDEyNyAwIi8+CiAgICAgICAgICAgIDxmZU9mZnNldC8+CiAgICAgICAgICAgIDxmZUdhdXNzaWFuQmx1ciBzdGREZXZpYXRpb249IjE1Ii8+CiAgICAgICAgICAgIDxmZUNvbG9yTWF0cml4IHZhbHVlcz0iMCAwIDAgMCAwLjA3NDUwOTggMCAwIDAgMCAwLjI1MDk4IDAgMCAwIDAgMC40MTE3NjUgMCAwIDAgMSAwIi8+CiAgICAgICAgICAgIDxmZUJsZW5kIGluMj0iQmFja2dyb3VuZEltYWdlRml4IiByZXN1bHQ9ImVmZmVjdDFfZHJvcFNoYWRvdyIvPgogICAgICAgICAgICA8ZmVCbGVuZCBpbj0iU291cmNlR3JhcGhpYyIgaW4yPSJlZmZlY3QxX2Ryb3BTaGFkb3ciIHJlc3VsdD0ic2hhcGUiLz4KICAgICAgICA8L2ZpbHRlcj4KICAgIDwvZGVmcz4KPC9zdmc+\"},\"_id\":\"5b1ea9d21090c200146f7366\"},{\"exchangeId\":\"POLONIEX\",\"name\":\"POLONIEX\",\"website\":\"https:\\/\\/poloniex.com\\/\",\"_id\":\"5b1ea9d21090c200146f7367\"},{\"exchangeId\":\"KRAKEN\",\"name\":\"Kraken\",\"website\":\"https:\\/\\/www.kraken.com\\/\",\"_id\":\"5b1ea9d21090c200146f7369\"},{\"exchangeId\":\"BTCCHINA\",\"name\":\"BTCCHINA\",\"website\":\"https:\\/\\/www.btcchina.com\\/\",\"_id\":\"5b1ea9d21090c200146f736c\"},{\"exchangeId\":\"BITHUMB\",\"name\":\"BITHUMB\",\"website\":\"https:\\/\\/www.bithumb.com\\/\",\"_id\":\"5b1ea9d21090c200146f736d\"},{\"exchangeId\":\"COINONE\",\"name\":\"coinone\",\"website\":\"https:\\/\\/coinone.co.kr\\/\",\"_id\":\"5b1ea9d21090c200146f736e\"},{\"exchangeId\":\"OKEX\",\"name\":\"OKEx\",\"website\":\"https:\\/\\/www.okex.com\\/\",\"_id\":\"5b1ea9d21090c200146f736f\"},{\"exchangeId\":\"OKCOIN_USD\",\"name\":\"OKCoin USD\",\"website\":\"https:\\/\\/www.okcoin.com\\/\",\"_id\":\"5b1ea9d21090c200146f7370\"},{\"exchangeId\":\"BTCTRADE\",\"name\":\"BTCTRADE\",\"website\":\"https:\\/\\/www.btctrade.com\\/\",\"_id\":\"5b1ea9d21090c200146f7371\"},{\"exchangeId\":\"BITMEX\",\"name\":\"BitMEX\",\"website\":\"https:\\/\\/www.bitmex.com\\/\",\"_id\":\"5b1ea9d21090c200146f7372\"},{\"exchangeId\":\"GEMINI\",\"name\":\"Gemini\",\"website\":\"https:\\/\\/gemini.com\\/\",\"_id\":\"5b1ea9d21090c200146f7373\"},{\"exchangeId\":\"ITBIT\",\"name\":\"itBit\",\"website\":\"https:\\/\\/www.itbit.com\\/\",\"_id\":\"5b1ea9d21090c200146f7374\"},{\"exchangeId\":\"HUOBI\",\"name\":\"Huobi\",\"website\":\"https:\\/\\/www.huobi.com\\/\",\"logo\":{\"mimeType\":\"image\\/svg+xml\",\"imageData\":\"PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHN2ZyBQVUJMSUMgIi0vL1czQy8vRFREIFNWRyAxLjEvL0VOIiAiaHR0cDovL3d3dy53My5vcmcvR3JhcGhpY3MvU1ZHLzEuMS9EVEQvc3ZnMTEuZHRkIj4KPCEtLSBDcmVhdG9yOiBDb3JlbERSQVcgWDcgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWw6c3BhY2U9InByZXNlcnZlIiB3aWR0aD0iNy41aW4iIGhlaWdodD0iNy41aW4iIHZlcnNpb249IjEuMSIgc3R5bGU9InNoYXBlLXJlbmRlcmluZzpnZW9tZXRyaWNQcmVjaXNpb247IHRleHQtcmVuZGVyaW5nOmdlb21ldHJpY1ByZWNpc2lvbjsgaW1hZ2UtcmVuZGVyaW5nOm9wdGltaXplUXVhbGl0eTsgZmlsbC1ydWxlOmV2ZW5vZGQ7IGNsaXAtcnVsZTpldmVub2RkIiB2aWV3Qm94PSIwIDAgNzUwMCA3NTAwIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayI+CiA8ZGVmcz4KICA8c3R5bGUgdHlwZT0idGV4dC9jc3MiPgogICA8IVtDREFUQVsKICAgIC5maWwwIHtmaWxsOm5vbmV9CiAgICAuZmlsMSB7ZmlsbDojRjBGMEYwfQogICAgLmZpbDIge2ZpbGw6IzFDMjE0MztmaWxsLXJ1bGU6bm9uemVyb30KICAgIC5maWwzIHtmaWxsOiMyRUE3RTA7ZmlsbC1ydWxlOm5vbnplcm99CiAgIF1dPgogIDwvc3R5bGU+CiA8L2RlZnM+CiA8ZyBpZD0iTGF5ZXJfeDAwMjBfMSI+CiAgPG1ldGFkYXRhIGlkPSJDb3JlbENvcnBJRF8wQ29yZWwtTGF5ZXIiLz4KICA8cmVjdCBjbGFzcz0iZmlsMCIgd2lkdGg9Ijc1MDAiIGhlaWdodD0iNzUwMCIvPgogIDxnIGlkPSJfMTg1MTg4OTgxMTE1MiI+CiAgIDxjaXJjbGUgY2xhc3M9ImZpbDEiIGN4PSIzNzUwIiBjeT0iMzc1MCIgcj0iMzEwMCIvPgogICA8Zz4KICAgIDxwYXRoIGNsYXNzPSJmaWwyIiBkPSJNMzYyNCAxMTYzYzc2LDE0IDIzMiwyMjcgMjc2LDI5MyA0NDAsNjc2IDUzOCwxMzgzIDc5LDIwNTIgLTI2NiwzODMgLTYyNSw3NTkgLTc5OSwxMTk1IC0xNzQsNDI5IC04Niw4NDcgMTIwLDEyNTAgNDgsOTggMTA4LDE5MSAxNTUsMjg5IDEwLDI1IDI2LDU0IDExLDgwIC0yOCwyMiAtNjgsMTEgLTEwMCw3IC03NzAsLTE1OSAtMTM0MCwtMTAwNCAtMTMwMCwtMTc3MyAxNSwtMzM0IDEzOSwtNjU3IDMyOCwtOTMxIDIyNywtMzM1IDU2MiwtNTg5IDc5OCwtOTM1IDIxNCwtMzA5IDM0MiwtNjcxIDM5NCwtMTA0MSAyNSwtMTYxIDMxLC0zMjQgMzgsLTQ4NnoiLz4KICAgIDxwYXRoIGNsYXNzPSJmaWwzIiBkPSJNNDc0MiAzMjQ0YzEsLTIgMSwtNCAzLC02IDIsLTEgNCwwIDcsLTEgMjMsMTEgNDEsMzAgNjAsNDcgNTE3LDQ1OSA3NTUsMTE2OCA1NTEsMTgzNyAtNzMsMjQxIC0yMDgsNDYyIC0zODMsNjQ0IC0xNDQsMTUxIC0yNTYsMjIwIC00MzMsMzI0IC03NCw0MyAtMTQzLDg3IC0xOTIsMTQwIC0zMiwzMiAtNTUsNzIgLTgyLDEwOCAtOTQsLTI2IC0zMjgsLTM5MyAtMzcyLC00ODkgLTE3NywtMzg2IC05OCwtNzk1IDc0LC0xMTY3IDE2NiwtMzU5IDQxOCwtNjUwIDYwMSwtMTAwMSA3MCwtMTM5IDE0MiwtMjgxIDE2NiwtNDM2eiIvPgogICA8L2c+CiAgPC9nPgogPC9nPgo8L3N2Zz4=\"},\"_id\":\"5b1ea9d21090c200146f7375\"},{\"exchangeId\":\"BTC-E\",\"name\":\"BTC-e\",\"website\":\"https:\\/\\/btc-e.com\\/\",\"_id\":\"5b1ea9d21090c200146f7376\"},{\"exchangeId\":\"CRYPTOPIA\",\"name\":\"Cryptopia\",\"website\":\"https:\\/\\/www.cryptopia.co.nz\\/\",\"_id\":\"5b1ea9d21090c200146f7377\"},{\"exchangeId\":\"COINCHECK\",\"name\":\"coincheck\",\"website\":\"https:\\/\\/coincheck.com\\/\",\"_id\":\"5b1ea9d21090c200146f7378\"},{\"exchangeId\":\"LIQUI\",\"name\":\"Liqui\",\"website\":\"https:\\/\\/liqui.io\\/\",\"_id\":\"5b1ea9d21090c200146f7379\"},{\"exchangeId\":\"EXMO\",\"name\":\"EXMO\",\"website\":\"https:\\/\\/exmo.com\\/\",\"_id\":\"5b1ea9d21090c200146f737a\"},{\"exchangeId\":\"CHBTC\",\"name\":\"CHBTC\",\"website\":\"https:\\/\\/www.chbtc.com\\/\",\"_id\":\"5b1ea9d21090c200146f737b\"},{\"exchangeId\":\"YOBIT\",\"name\":\"YObit\",\"website\":\"https:\\/\\/yobit.net\\/en\\/\",\"_id\":\"5b1ea9d21090c200146f737c\"},{\"exchangeId\":\"BITFLYER\",\"name\":\"bitFlyer\",\"website\":\"https:\\/\\/bitflyer.jp\\/\",\"_id\":\"5b1ea9d21090c200146f737d\"},{\"exchangeId\":\"ZAIF\",\"name\":\"Zaif\",\"website\":\"https:\\/\\/zaif.jp\\/\",\"_id\":\"5b1ea9d21090c200146f737e\"},{\"exchangeId\":\"KORBIT\",\"name\":\"Korbit\",\"website\":\"https:\\/\\/www.korbit.co.kr\",\"_id\":\"5b1ea9d21090c200146f737f\"},{\"exchangeId\":\"JUBI\",\"name\":\"Jubi\",\"website\":\"https:\\/\\/www.jubi.com\",\"_id\":\"5b1ea9d21090c200146f7380\"},{\"exchangeId\":\"GATEIO\",\"name\":\"Gate.io\",\"website\":\"https:\\/\\/gate.io\\/\",\"_id\":\"5b1ea9d21090c200146f7381\"},{\"exchangeId\":\"BTC38\",\"name\":\"BTC38\",\"website\":\"http:\\/\\/www.btc38.com\",\"_id\":\"5b1ea9d21090c200146f7382\"},{\"exchangeId\":\"MTGOX\",\"name\":\"mtgox\",\"website\":\"https:\\/\\/www.mtgox.com\\/\",\"_id\":\"5b1ea9d21090c200146f7383\"},{\"exchangeId\":\"WEXNZ\",\"name\":\"WexNz\",\"website\":\"https:\\/\\/wex.nz\\/\",\"_id\":\"5b1ea9d21090c200146f7384\"},{\"exchangeId\":\"KUCOIN\",\"name\":\"Kucoin\",\"website\":\"https:\\/\\/kucoin.com\\/\",\"_id\":\"5b1ea9d21090c200146f7385\"},{\"exchangeId\":\"LAKEBTC\",\"name\":\"LakeBTC\",\"website\":\"https:\\/\\/www.lakebtc.com\\/\",\"_id\":\"5b1ea9d21090c200146f7386\"},{\"exchangeId\":\"BLEUTRADE\",\"name\":\"Bleutrade\",\"website\":\"https:\\/\\/bleutrade.com\",\"_id\":\"5b1ea9d21090c200146f7387\"},{\"exchangeId\":\"BITCOINID\",\"name\":\"Indodax\",\"website\":\"https:\\/\\/indodax.com\\/\",\"_id\":\"5b1ea9d21090c200146f7388\"},{\"exchangeId\":\"QUOINE\",\"name\":\"QUOINE\",\"website\":\"https:\\/\\/quoine.com\\/\",\"_id\":\"5b1ea9d21090c200146f7389\"},{\"exchangeId\":\"ACX\",\"name\":\"ACX\",\"website\":\"https:\\/\\/acx.io\\/\",\"_id\":\"5b1ea9d21090c200146f738a\"},{\"exchangeId\":\"TIDEX\",\"name\":\"Tidex\",\"website\":\"https:\\/\\/tidex.com\\/\",\"_id\":\"5b1ea9d21090c200146f738b\"},{\"exchangeId\":\"BITSO\",\"name\":\"Bitso\",\"website\":\"https:\\/\\/bitso.com\\/\",\"_id\":\"5b1ea9d21090c200146f738c\"},{\"exchangeId\":\"LIVECOIN\",\"name\":\"LiveCoin\",\"website\":\"https:\\/\\/www.livecoin.net\\/\",\"_id\":\"5b1ea9d21090c200146f738d\"},{\"exchangeId\":\"MIXCOINS\",\"name\":\"MixCoins\",\"website\":\"https:\\/\\/mixcoins.com\\/\",\"_id\":\"5b1ea9d21090c200146f738e\"},{\"exchangeId\":\"VIRWOX\",\"name\":\"BirWoX\",\"website\":\"https:\\/\\/www.virwox.com\\/\",\"_id\":\"5b1ea9d21090c200146f738f\"},{\"exchangeId\":\"BTER\",\"name\":\"Bter\",\"website\":\"https:\\/\\/bter.com\\/\",\"_id\":\"5b1ea9d21090c200146f7390\"},{\"exchangeId\":\"MERCADOBITCOIN\",\"name\":\"Mercado Bitcoin\",\"website\":\"https:\\/\\/www.mercadobitcoin.com.br\\/\",\"_id\":\"5b1ea9d21090c200146f7391\"},{\"exchangeId\":\"CEXIO\",\"name\":\"CEX.IO\",\"website\":\"https:\\/\\/cex.io\\/\",\"_id\":\"5b1ea9d21090c200146f7392\"},{\"exchangeId\":\"THEROCKTRADING\",\"name\":\"The Rock Trading LTD.\",\"website\":\"https:\\/\\/www.therocktrading.com\\/\",\"_id\":\"5b1ea9d21090c200146f7393\"},{\"exchangeId\":\"DERIBIT\",\"name\":\"Deribit\",\"website\":\"https:\\/\\/www.deribit.com\\/\",\"_id\":\"5b1ea9d21090c200146f7394\"},{\"exchangeId\":\"QRYPTOS\",\"name\":\"QRYPTOS\",\"website\":\"https:\\/\\/www.qryptos.com\\/\",\"_id\":\"5b1ea9d21090c200146f7395\"},{\"exchangeId\":\"CCEX\",\"name\":\"c-cex\",\"website\":\"https:\\/\\/c-cex.com\",\"_id\":\"5b1ea9d21090c200146f7396\"},{\"exchangeId\":\"QUADRIGACX\",\"name\":\"QuadrigaCX\",\"website\":\"https:\\/\\/www.quadrigacx.com\\/\",\"_id\":\"5b1ea9d21090c200146f7397\"},{\"exchangeId\":\"COINNEST\",\"name\":\"Coinnest\",\"website\":\"https:\\/\\/www.coinnest.co.kr\\/\",\"_id\":\"5b1ea9d21090c200146f7398\"},{\"exchangeId\":\"BITMARKET\",\"name\":\"BitMarket\",\"website\":\"https:\\/\\/www.bitmarket.pl\",\"_id\":\"5b1ea9d21090c200146f7399\"},{\"exchangeId\":\"LUNO\",\"name\":\"Luno\",\"website\":\"https:\\/\\/www.luno.com\",\"_id\":\"5b1ea9d21090c200146f739a\"},{\"exchangeId\":\"BTCMARKETS\",\"name\":\"BTC Markets Pty Ltd.\",\"website\":\"https:\\/\\/www.btcmarkets.net\\/\",\"_id\":\"5b1ea9d21090c200146f739b\"},{\"exchangeId\":\"BTCBOX\",\"name\":\"BtcBox\",\"website\":\"https:\\/\\/www.btcbox.co.jp\\/\",\"_id\":\"5b1ea9d21090c200146f739c\"},{\"exchangeId\":\"GATECOIN\",\"name\":\"Gatecoin\",\"website\":\"https:\\/\\/gatecoin.com\\/\",\"_id\":\"5b1ea9d21090c200146f739d\"},{\"exchangeId\":\"BXINTH\",\"name\":\"bx.in.th\",\"website\":\"https:\\/\\/bx.in.th\\/\",\"_id\":\"5b1ea9d21090c200146f739e\"},{\"exchangeId\":\"ALLCOIN\",\"name\":\"Allcoin\",\"website\":\"https:\\/\\/www.allcoin.com\\/\",\"_id\":\"5b1ea9d21090c200146f739f\"},{\"exchangeId\":\"COINMATE\",\"name\":\"Coin Mate\",\"website\":\"https:\\/\\/coinmate.io\\/\",\"_id\":\"5b1ea9d21090c200146f73a0\"},{\"exchangeId\":\"BTCTURK\",\"name\":\"BTCTurk\",\"website\":\"https:\\/\\/www.btcturk.com\\/\",\"_id\":\"5b1ea9d21090c200146f73a1\"},{\"exchangeId\":\"INDEPENDENTRESERVE\",\"name\":\"Independent Reserve\",\"website\":\"https:\\/\\/www.independentreserve.com\\/\",\"_id\":\"5b1ea9d21090c200146f73a2\"},{\"exchangeId\":\"COINFLOOR\",\"name\":\"coinfloor\",\"website\":\"https:\\/\\/www.coinfloor.co.uk\\/\",\"_id\":\"5b1ea9d21090c200146f73a3\"},{\"exchangeId\":\"DSX\",\"name\":\"DSX\",\"website\":\"https:\\/\\/dsx.uk\",\"_id\":\"5b1ea9d21090c200146f73a4\"},{\"exchangeId\":\"ABUCOINS\",\"name\":\"Abucoins\",\"website\":\"https:\\/\\/abucoins.com\\/\",\"_id\":\"5b1ea9d21090c200146f73a5\"},{\"exchangeId\":\"SOUTHXCHANGE\",\"name\":\"SouthXchange\",\"website\":\"https:\\/\\/www.southxchange.com\\/\",\"_id\":\"5b1ea9d21090c200146f73a6\"},{\"exchangeId\":\"BTCTRADEUA\",\"name\":\"BTC Trade UA\",\"website\":\"https:\\/\\/btc-trade.com.ua\\/\",\"_id\":\"5b1ea9d21090c200146f73a7\"},{\"exchangeId\":\"BTCX\",\"name\":\"bt.cx\",\"website\":\"https:\\/\\/bt.cx\\/en\\/\",\"_id\":\"5b1ea9d21090c200146f73a8\"},{\"exchangeId\":\"KUNA\",\"name\":\"Kuna\",\"website\":\"https:\\/\\/kuna.io\\/\",\"_id\":\"5b1ea9d21090c200146f73a9\"},{\"exchangeId\":\"BRAZILIEX\",\"name\":\"Braziliex\",\"website\":\"https:\\/\\/braziliex.com\\/\",\"_id\":\"5b1ea9d21090c200146f73aa\"},{\"exchangeId\":\"FYBSG\",\"name\":\"FYB-SG\",\"website\":\"https:\\/\\/www.fybsg.com\\/\",\"_id\":\"5b1ea9d21090c200146f73ab\"},{\"exchangeId\":\"YUNBI\",\"name\":\"YUNBI\",\"website\":\"https:\\/\\/yunbi.com\\/\",\"_id\":\"5b1ea9d21090c200146f73ac\"},{\"exchangeId\":\"BITKONAN\",\"name\":\"BitKonan\",\"website\":\"https:\\/\\/bitkonan.com\\/\",\"_id\":\"5b1ea9d21090c200146f73ad\"},{\"exchangeId\":\"FYBSE\",\"name\":\"FYB-SE\",\"website\":\"https:\\/\\/www.fybse.se\\/\",\"_id\":\"5b1ea9d21090c200146f73ae\"},{\"exchangeId\":\"BTCC\",\"name\":\"BTCC\",\"website\":\"https:\\/\\/www.btcc.com\\/\",\"_id\":\"5b1ea9d21090c200146f73af\"},{\"exchangeId\":\"COINGI\",\"name\":\"Coingi\",\"website\":\"https:\\/\\/coingi.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b0\"},{\"exchangeId\":\"1BTCXE\",\"name\":\"1Btcxe\",\"website\":\"https:\\/\\/1btcxe.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b1\"},{\"exchangeId\":\"NOVA\",\"name\":\"Novaexchange\",\"website\":\"https:\\/\\/novaexchange.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b2\"},{\"exchangeId\":\"BITLISH\",\"name\":\"Bitlish\",\"website\":\"https:\\/\\/bitlish.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b3\"},{\"exchangeId\":\"COINSECURE\",\"name\":\"Coinsecure\",\"website\":\"https:\\/\\/coinsecure.in\\/\",\"_id\":\"5b1ea9d21090c200146f73b4\"},{\"exchangeId\":\"BITBAY\",\"name\":\"BitBay\",\"website\":\"https:\\/\\/www.bitbay.net\\/\",\"_id\":\"5b1ea9d21090c200146f73b5\"},{\"exchangeId\":\"VBTC\",\"name\":\"VBTC.VN\",\"website\":\"https:\\/\\/vbtc.vn\\/\",\"_id\":\"5b1ea9d21090c200146f73b6\"},{\"exchangeId\":\"ANXPRO\",\"name\":\"ANXPro\",\"website\":\"https:\\/\\/anxpro.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b7\"},{\"exchangeId\":\"COINEXCHANGE\",\"name\":\"CoinExchange\",\"website\":\"https:\\/\\/www.coinexchange.io\\/\",\"_id\":\"5b1ea9d21090c200146f73b8\"},{\"exchangeId\":\"LYKKE\",\"name\":\"Lykke\",\"website\":\"https:\\/\\/www.lykke.com\\/\",\"_id\":\"5b1ea9d21090c200146f73b9\"},{\"exchangeId\":\"XBTCE\",\"name\":\"xBTCe\",\"website\":\"https:\\/\\/www.xbtce.com\",\"_id\":\"5b1ea9d21090c200146f73ba\"},{\"exchangeId\":\"BCEX\",\"name\":\"Bcex\",\"website\":\"https:\\/\\/www.bcex.ca\\/\",\"_id\":\"5b3f028bc38520403e45b2ae\"},{\"exchangeId\":\"BIBOX\",\"name\":\"Bibox\",\"website\":\"https:\\/\\/www.bibox.com\\/\",\"_id\":\"5b3f0359c38520403e45b2b0\"},{\"exchangeId\":\"BITBANK\",\"name\":\"Bitbank\",\"website\":\"https:\\/\\/bitbank.cc\\/\",\"_id\":\"5b3f03cac38520403e45b2b1\"},{\"exchangeId\":\"BITZ\",\"name\":\"Bit-Z\",\"website\":\"https:\\/\\/www.bit-z.com\\/\",\"_id\":\"5b3f04fac38520403e45b2b2\"},{\"exchangeId\":\"BL3P\",\"name\":\"Bl3p\",\"website\":\"https:\\/\\/bl3p.eu\",\"_id\":\"5b3f0548c38520403e45b2b4\"},{\"exchangeId\":\"BTCALPHA\",\"name\":\"BTC-ALPHA\",\"website\":\"https:\\/\\/btc-alpha.com\\/\",\"_id\":\"5b3f05dac38520403e45b2b6\"},{\"exchangeId\":\"COINTIGER\",\"name\":\"CoinTiger\\u00a0\",\"website\":\"https:\\/\\/www.cointiger.pro\\/\",\"_id\":\"5b3f062fc38520403e45b2b8\"},{\"exchangeId\":\"DDEX\",\"name\":\"DDEX\",\"website\":\"https:\\/\\/ddex.io\\/\",\"_id\":\"5b3f0642c38520403e45b2ba\"},{\"exchangeId\":\"GDAX\",\"name\":\"Gdax\",\"website\":\"https:\\/\\/www.gdax.com\\/\",\"_id\":\"5b3f072ac38520403e45b2bb\"},{\"exchangeId\":\"BIGONE\",\"name\":\"BigONE\",\"website\":\"https:\\/\\/big.one\\/\",\"_id\":\"5b3f0772c38520403e45b2bc\"},{\"exchangeId\":\"BITMASZYNA\",\"name\":\"bitmaszyna\",\"website\":\"https:\\/\\/bitmaszyna.pl\",\"_id\":\"5b3f07a8c38520403e45b2be\"},{\"exchangeId\":\"BITCOINSNORWAY\",\"name\":\"bitcoinsnorway\",\"website\":\"https:\\/\\/bitcoinsnorway.com\\/\",\"_id\":\"5b3f07d2c38520403e45b2c0\"},{\"exchangeId\":\"PAXFUL\",\"name\":\"paxful\",\"website\":\"https:\\/\\/paxful.com\",\"_id\":\"5b3f0808c38520403e45b2c2\"},{\"exchangeId\":\"COBINHOOD\",\"name\":\"Cobinhood\",\"website\":\"https:\\/\\/cobinhood.com\\/\",\"_id\":\"5b4e11256ab304000a106942\"},{\"exchangeId\":\"COINBENE\",\"name\":\"CoinBene\",\"website\":\"https:\\/\\/www.coinbene.com\\/\",\"_id\":\"5b4e117a6ab304000a106943\"},{\"exchangeId\":\"EXX\",\"name\":\"Exx\",\"website\":\"https:\\/\\/www.exx.com\\/\",\"_id\":\"5b4e11df6ab304000b6b0372\"},{\"exchangeId\":\"FISCO\",\"name\":\"Fisco\",\"website\":\"https:\\/\\/fcce.jp\\/\",\"_id\":\"5b4e12016ab304000b6b0373\"},{\"exchangeId\":\"GOPAX\",\"name\":\"Gopax\",\"website\":\"https:\\/\\/www.gopax.co.kr\\/\",\"_id\":\"5b4e12486ab304000a106944\"},{\"exchangeId\":\"IDAX\",\"name\":\"IDAX\",\"website\":\"https:\\/\\/www.idax.mn\\/\",\"_id\":\"5b4e12ba6ab304000929ace2\"},{\"exchangeId\":\"IDEX\",\"name\":\"Idex\",\"website\":\"https:\\/\\/idex.market\\/eth\\/aura\",\"_id\":\"5b4e12d66ab304000929ace3\"},{\"exchangeId\":\"LBANK\",\"name\":\"LBank\",\"website\":\"https:\\/\\/www.lbank.info\\/\",\"_id\":\"5b4e131b6ab304000a106945\"},{\"exchangeId\":\"NEGOCIECOINS\",\"name\":\"Negociecoins\",\"website\":\"https:\\/\\/www.negociecoins.com\\/\",\"_id\":\"5b4ef2fa6ab304000a106946\"},{\"exchangeId\":\"OTCBTC\",\"name\":\"OTCBTC\",\"website\":\"https:\\/\\/okcoin.com\\/\",\"_id\":\"5b4ef4596ab304000a106947\"},{\"exchangeId\":\"PAYMIUM\",\"name\":\"Paymium\",\"website\":\"https:\\/\\/www.paymium.com\\/\",\"_id\":\"5b4ef4df6ab30400186fcb92\"},{\"exchangeId\":\"QBTC\",\"name\":\"Qbtc\",\"website\":\"https:\\/\\/www.qbtc.com\\/\",\"_id\":\"5b4ef54f6ab30400164b6de2\"},{\"exchangeId\":\"RIGHTBTC\",\"name\":\"RightBTC\",\"website\":\"https:\\/\\/www.rightbtc.com\\/\",\"_id\":\"5b4f04996ab30400170ef2e2\"},{\"exchangeId\":\"SIMEX\",\"name\":\"Simex\",\"website\":\"https:\\/\\/simex.global\\/en\",\"_id\":\"5b4f05436ab3040019577e22\"},{\"exchangeId\":\"TDAX\",\"name\":\"Tdax\",\"website\":\"https:\\/\\/tdax.com\",\"_id\":\"5b4f05b36ab30400170ef2e3\"},{\"exchangeId\":\"TDEX\",\"name\":\"Tdex\",\"website\":\"https:\\/\\/tidex.com\\/\",\"_id\":\"5b4f05e96ab30400170ef2e4\"},{\"exchangeId\":\"UPBIT\",\"name\":\"Upbit\",\"website\":\"https:\\/\\/upbit.com\\/\",\"_id\":\"5b4f15fb6ab30400186fcb93\"},{\"exchangeId\":\"VAULTORO\",\"name\":\"Vaultoro\",\"website\":\"https:\\/\\/api.vaultoro.com\\/\",\"_id\":\"5b4f163c6ab304001a484222\"},{\"exchangeId\":\"ZB\",\"name\":\"Zb\",\"website\":\"https:\\/\\/www.zb.com\\/\",\"_id\":\"5b4f16b96ab304001a484223\"},{\"exchangeId\":\"TIDEBIT\",\"name\":\"Tidebit\",\"website\":\"https:\\/\\/www.tidebit.com\\/\",\"_id\":\"5b4f17006ab304001b6053c2\"},{\"exchangeId\":\"STOCKS\",\"name\":\"Stocks Exchange\",\"website\":\"https:\\/\\/stocks.exchange\\/\",\"_id\":\"5b4f17e56ab304001f2e3252\"},{\"exchangeId\":\"GETBTC\",\"name\":\"GetBTC\",\"website\":\"https:\\/\\/getbtc.org\\/\",\"_id\":\"5b4f18386ab304001f2e3253\"},{\"exchangeId\":\"COINFALCON\",\"name\":\"Coinfalcon\",\"website\":\"https:\\/\\/coinfalcon.com\\/\",\"_id\":\"5b4f189f6ab304001d4db692\"},{\"exchangeId\":\"AIDOSMARKET\",\"name\":\"Aidosmarket\",\"website\":\"https:\\/\\/aidosmarket.com\\/\",\"_id\":\"5b4f19b26ab304001d4db693\"},{\"exchangeId\":\"COINSUPER\",\"name\":\"Coinsuper\",\"website\":\"https:\\/\\/www.coinsuper.com\\/\",\"_id\":\"5b4f19fb6ab304001e3bc0b2\"},{\"exchangeId\":\"TRADEBYTRADE\",\"name\":\"Trade By Trade\",\"website\":\"https:\\/\\/tradebytrade.com\\/\",\"_id\":\"5b4f1a3d6ab3040022764ce2\"},{\"exchangeId\":\"COINROOM\",\"name\":\"Coinroom\",\"website\":\"https:\\/\\/coinroom.com\\/\",\"_id\":\"5b4f1b3e6ab3040021369c22\"},{\"exchangeId\":\"WAVESPLATFORM\",\"name\":\"Waves Platform\",\"website\":\"https:\\/\\/wavesplatform.com\\/\",\"_id\":\"5b4f1ba46ab304001f2e3254\"},{\"exchangeId\":\"BITEBTC\",\"name\":\"BiteBTC\",\"website\":\"https:\\/\\/bitebtc.com\\/\",\"_id\":\"5b4f1be86ab3040022764ce3\"},{\"exchangeId\":\"BITIBU\",\"name\":\"Bitibu\",\"website\":\"https:\\/\\/bitibu.com\\/\",\"_id\":\"5b4f1c546ab304001f2e3255\"},{\"exchangeId\":\"CRXZONE\",\"name\":\"CRX Zone\",\"website\":\"https:\\/\\/www.crxzone.com\\/\",\"_id\":\"5b4f1cac6ab304001f2e3256\"},{\"exchangeId\":\"CREX24\",\"name\":\"CREX24\",\"website\":\"https:\\/\\/crex24.com\\/\",\"_id\":\"5b4f1ced6ab3040022764ce4\"},{\"exchangeId\":\"COSS\",\"name\":\"COSS\",\"website\":\"https:\\/\\/www.coss.io\\/\",\"_id\":\"5b4f1d2c6ab3040021369c23\"},{\"exchangeId\":\"TRADEOGRE\",\"name\":\"TRADEOGRE\",\"website\":\"https:\\/\\/tradeogre.com\\/\",\"_id\":\"5b4f1d676ab3040021369c24\"},{\"exchangeId\":\"COINUT\",\"name\":\"Coinut\",\"website\":\"https:\\/\\/coinut.com\\/\",\"_id\":\"5b4f1eda6ab3040020122802\"},{\"exchangeId\":\"BITHASH\",\"name\":\"BitHash\",\"website\":\"https:\\/\\/www.bithash.net\\/\",\"_id\":\"5b4f1f6b6ab30400231169b2\"},{\"exchangeId\":\"BITSANE\",\"name\":\"Bitsane\",\"website\":\"https:\\/\\/bitsane.com\\/\",\"_id\":\"5b4f20d16ab304002567f3b2\"},{\"exchangeId\":\"FCOIN\",\"name\":\"FCoin\",\"website\":\"https:\\/\\/www.fcoin.com\\/\",\"_id\":\"5b4f21c96ab30400231169b3\"},{\"exchangeId\":\"BUDA\",\"name\":\"Buda\",\"website\":\"https:\\/\\/www.buda.com\\/\",\"_id\":\"5b4f225a6ab304002733bd82\"},{\"exchangeId\":\"EZBTC\",\"name\":\"ezBtc\",\"website\":\"https:\\/\\/www.ezbtc.ca\\/\",\"_id\":\"5b4f22e56ab30400231169b4\"},{\"exchangeId\":\"CFINEX\",\"name\":\"Cfinex\",\"website\":\"https:\\/\\/cfinex.com\\/\",\"_id\":\"5b4f235c6ab304002733bd83\"},{\"exchangeId\":\"BITFOREX\",\"name\":\"Bitforex\",\"website\":\"https:\\/\\/bitforex.com\\/\",\"_id\":\"5b4f24dc6ab304002476ea82\"},{\"exchangeId\":\"CRYPTOHUB\",\"name\":\"Crypto Hub\",\"website\":\"https:\\/\\/cryptohub.online\\/\",\"_id\":\"5b4f255e6ab304002567f3b3\"},{\"exchangeId\":\"DGTMARKET\",\"name\":\"DGTMarket\",\"website\":\"https:\\/\\/exchange.dgtmarket.com\\/\",\"_id\":\"5b4f258d6ab304002733bd84\"},{\"exchangeId\":\"BITFINEX\",\"name\":\"Bitfinex\",\"website\":\"https:\\/\\/www.bitfinex.com\\/\",\"_id\":\"5bc0893ea6f99f00093f0202\"},{\"exchangeId\":\"HITBTC\",\"name\":\"HitBTC\",\"website\":\"https:\\/\\/hitbtc.com\\/\",\"_id\":\"5bc08966a6f99f000b5968c2\"},{\"exchangeId\":\"BITMART\",\"name\":\"Bitmart\",\"website\":\"https:\\/\\/www.bitmart.com\\/\",\"_id\":\"5c12385de0f4a8000c06b7c2\"},{\"exchangeId\":\"COINSBANK\",\"name\":\"CoinsBank\",\"website\":\"https:\\/\\/coinsbank.com\\/\",\"_id\":\"5c124ed7e0f4a8000c06b7c3\"},{\"exchangeId\":\"OEX\",\"name\":\"OEX\",\"website\":\"https:\\/\\/www.oex.com\\/\",\"_id\":\"5c1255aae0f4a80008643582\"},{\"exchangeId\":\"IDCM\",\"name\":\"International Digital Currency Markets\",\"website\":\"https:\\/\\/www.idcm.io\\/\",\"_id\":\"5c137c45e0f4a80009789502\"},{\"exchangeId\":\"DRAGONEX\",\"name\":\"DragonEx\",\"website\":\"https:\\/\\/dragonex.io\\/en-us\\/\",\"_id\":\"5c137d5be0f4a80009789503\"},{\"exchangeId\":\"TOPBTC\",\"name\":\"TOPBTC\",\"website\":\"http:\\/\\/www.topbtc.one\\/\",\"_id\":\"5c137e3be0f4a8000b27c772\"},{\"exchangeId\":\"EXRATES\",\"name\":\"EXRATES\",\"website\":\"https:\\/\\/exrates.me\",\"_id\":\"5c1399ebe0f4a80009789504\"},{\"exchangeId\":\"DIGIFINEX\",\"name\":\"DigiFinex\",\"website\":\"https:\\/\\/www.digifinex.com\\/en-ww\\/\",\"_id\":\"5c139a47e0f4a8000a44ec02\"},{\"exchangeId\":\"DOBI\",\"name\":\"DOBITRADE\",\"website\":\"https:\\/\\/www.dobitrade.com\\/\",\"_id\":\"5c177252e0f4a80009789505\"},{\"exchangeId\":\"FATBTC\",\"name\":\"FatBTC\",\"website\":\"http:\\/\\/www.fatbtc.com\",\"_id\":\"5cac5c0ada249426f268cc92\"}]}";
                return content;
            }
        }

        public ActionResult Index()
        {
            string data = ApiCall.DoIt("https://api.cryptoapis.io/v1/exchanges?limit=500");
            var serialized = JsonConvert.DeserializeObject<ExchangeIndexClass.ExchangeIndex>(data);
            return View(serialized);
        }
    }
}


