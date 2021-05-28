using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace ps5
{
    class Program
    {

        static bool stockNowAvaiable = false;

        static void Main(string[] args)
        {
            var rand = new Random();
            while (!stockNowAvaiable)
            {
                var ps5 = new PS5(0,0);
                if (ps5.checkSupply("https://www.ebgames.ca/PS5/Games/877523/playstation-5-digital-edition", "Out of Stock", "buyDisabled"))
                {
                    playAlarm("eb-games");
                }
                if (ps5.checkSupplyUntilTextExist("https://www.bestbuy.ca/en-ca/product/playstation-5-digital-edition-console-online-only/14962184", "disabled_mu48l"))
                {
                    playAlarm("bestbuy-1");
                }
                Thread.Sleep(rand.Next(0, 2000));
                if (ps5.checkSupplyUntilTextExist("https://www.bestbuy.ca/en-ca/product/playstation-5-console-online-only/14962185", "disabled_mu48l"))
                {
                    playAlarm("bestbuy-2");
                }
                //if (ps5.checkSupplyUntilTextExist("https://www.walmart.ca/en/ip/playstation5-console/6000202198562", "out of stock online"))
                //{
                //    playAlarm("walmart-1");
                //}
                //Thread.Sleep(rand.Next(0, 2000));
                //if (ps5.checkSupplyUntilTextExist("https://www.walmart.ca/en/ip/playstation5-digital-edition/6000202198823", "out of stock online"))
                //{
                //    playAlarm("walmart-2");
                //}
                if (ps5.checkSupplyUntilTextNotExist("https://www.amazon.ca/PlayStation-5-Console/dp/B08GSC5D9G/ref=sr_1_1?dchild=1&keywords=ps5&qid=1622055946&sr=8-1", "add to cart"))
                {
                    playAlarm("amazon-1");
                }
                Thread.Sleep(rand.Next(2000, 30000));
                //stockNowAvaiable = true;
            }
        }
        static void playAlarm(string store)
        {
            stockNowAvaiable = true;
            using (var wrapper = new ChromeDriverWarpper("https://www.youtube.com/watch?v=BIKarAqOB9I"))
            {
                File.WriteAllText(String.Format("store\\{0}.txt", store), store);
                Console.WriteLine(store);
                Thread.Sleep(600000);
                throw new Exception(store);
            }
        }
    }
}

//add to cart
//ps5.OutputPageSource("amazon-1","https://www.amazon.ca/PlayStation-5-Console/dp/B08GSC5D9G/ref=sr_1_1?dchild=1&keywords=ps5&qid=1622055946&sr=8-1");
//ps5.OutputPageSource("amazon-2", "https://www.amazon.ca/Seagate-Drive-Systems-External-Portable/dp/B07M9VCHDG/ref=pd_vtp_3/147-8703474-8226414?pd_rd_w=kF6xI&pf_rd_p=42ad2502-0d93-40f9-bcf4-49a0657bb461&pf_rd_r=MPZEZ7PMPKEGRKE9NGDE&pd_rd_r=b827ed2e-7f93-4695-947c-c3a2ecafc1b0&pd_rd_wg=UbDQz&pd_rd_i=B07M9VCHDG&psc=1");

//addToCartButton_1op0t
// disabled_mu48L
//ps5.OutputPageSource("bestbuy-1","https://www.bestbuy.ca/en-ca/product/playstation-5-digital-edition-console-online-only/14962184");
//ps5.OutputPageSource("bestbuy-2","https://www.bestbuy.ca/en-ca/product/playstation-5-console-online-only/14962185");
//ps5.OutputPageSource("bestbuy-garmin-1", "https://www.bestbuy.ca/en-ca/product/garmin-fenix-5x-plus-sapphire-51mm-gps-watch-with-topo-mapping-black/13011285");
//ps5.OutputPageSource("walmart-3", "https://www.walmart.ca/en/ip/premier-protein/6000197384728?rrid=richrelevance");
///out of stock online
//ps5.OutputPageSource("walmart-1","https://www.walmart.ca/en/ip/playstation5-console/6000202198562");
//ps5.OutputPageSource("walmart-2","https://www.walmart.ca/en/ip/playstation5-digital-edition/6000202198823");








