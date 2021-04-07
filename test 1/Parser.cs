using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace test_1
{
    class parser
    {
        public static List<TableRow> Parse(string url)
        {
            List<TableRow> elements = new List<TableRow>();
            try
            {


                using (HttpClientHandler hdl = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None })
                {
                    using (var clnt = new HttpClient(hdl))
                    {
                        using (HttpResponseMessage resp = clnt.GetAsync(url).Result)
                        {
                            if (resp.IsSuccessStatusCode)
                            {
                                var html = resp.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);
                                    var divNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'pc_temp_songlist')]");

                                    if (divNode != null)
                                    {
                                        var liNodes = divNode.SelectNodes("//ul//li[@class=' ']");

                                        foreach (var node in liNodes)
                                        {

                                            string[] temp = node.Attributes["title"].Value.Split(new char[] { '-' });
                                            elements.Add(new TableRow()
                                            {
                                                songName = $"Song: { temp[1] } ",
                                                songLength =$"Song length: { node.SelectSingleNode(".//span[@class='pc_temp_tips_r']//span[@class='pc_temp_time']").InnerText.Trim('\t', '\n') } ",
                                                artistName =$"Artist: { temp[0]} "
                                            });; ; ;
                                        }

                                    }

                                }

                            }
                        }
                    }
                }
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return elements;
        }

    }
}
