using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;

namespace sde_test
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(@"C:\Users\gunja\OneDrive\Documents\GitHub\sde-test\sample_input.json"));
            if (jObject != null)
            {
                string cid = "";
                string gid = "";
                float cyield = 0;
                float eyield = 0;
                float gtenor;
                int gamount_outstanding;
                var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.NumberFormat.NumberDecimalSeparator = ".";
                JArray data = (JArray)jObject["data"];
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        Console.WriteLine("id :" + item["id"].ToString());
                        Console.WriteLine("type :" + item["type"].ToString());
                        Console.WriteLine("tenor :" + item["tenor"].ToString());
                        Console.WriteLine("yield :" + item["yield"].ToString());
                        Console.WriteLine("amount_outstanding :" + item["amount_outstanding"].ToString());

                        if ((item["type"].ToString() == "corporate") && (item["yield"].ToString() != ""))
                            {
                                cid = item["id"].ToString();
                                cyield = float.Parse(item["yield"].ToString().Split('%')[0], culture);
                        }

                        if ((item["type"].ToString() == "government") && (item["yield"].ToString() != ""))
                        {
                            string gid1;
                            gid1 = item["id"].ToString();
                            float eyield1;
                            eyield1 = float.Parse(item["yield"].ToString().Split('%')[0], culture);
                            float gtenor1;
                            char[] whitespace = new char[] { ' ', '\t' };
                            gtenor1 = float.Parse (item["tenor"].ToString().Split(whitespace)[0]);
                            int gamount_outstanding1;
                            gamount_outstanding1 = Int32.Parse(item["amount_outstanding"].ToString());
                            gid = gid1;
                            eyield = eyield1;
                            gtenor = gtenor1;
                            gamount_outstanding = gamount_outstanding1;

                            if (gamount_outstanding1 > gamount_outstanding)
                            {
                                gamount_outstanding = gamount_outstanding1;
                                gid = gid1;
                                eyield = eyield1;
                                gtenor = gtenor1;
                            }

                        }
                    }
                    var jsonObjectSpread = new JObject();
                    dynamic Spreaddata = jsonObjectSpread;

                    Spreaddata.datas = new JArray() as dynamic;

                    dynamic sdata = new JObject();

                    sdata.corporate_bond_id = cid.ToString();
                    sdata.government_bond_id = gid.ToString();
                    float yieldresult = float.Parse(cyield.ToString()) - float.Parse(eyield.ToString());
                    int yieldresultInt = (int)Math.Round(yieldresult*100);
                    sdata.spread_to_benchmark = yieldresultInt.ToString() + " bps";
                    Spreaddata.datas.Add(sdata);
                    Console.WriteLine(Spreaddata);
                    File.WriteAllText(@"C:\Users\gunja\OneDrive\Documents\GitHub\sde-test\result.json", jsonObjectSpread.ToString());
                }
            }
        }
    }
}
