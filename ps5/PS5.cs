using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace ps5
{
    class PS5
    {
        int maxInterval {get; set;}
        int minInterval {get; set;}
        public PS5(int minRandomIntercalTOCheck = 0, int maxRandomInternalToCheck = 0)
        {
            minInterval = minRandomIntercalTOCheck;
            maxInterval = maxRandomInternalToCheck;
        }

        public bool checkSupply(string uri, string checkForKeyword = "", string className = "")
        {
            var returnValue = false;
            using (var builder = new ChromeDriverWarpper(uri))
            {
                //Console.WriteLine(builder.driver.PageSource);
                //File.WriteAllText("Uri.txt", builder.driver.PageSource);
                try
                {
                    if (!builder.driver.FindElementByClassName(className).Text.Trim().Equals(checkForKeyword,StringComparison.OrdinalIgnoreCase))
                    {
                        returnValue = true;
                    }
                }
                catch
                {
                    returnValue = true;
                }
                //Console.WriteLine(builder.driver.FindElementByClassName("buyDisabled").Text);
                var rand = new Random();
                Thread.Sleep(rand.Next(minInterval, maxInterval));
            }
            return returnValue;
        }

        public bool checkSupplyUntilTextExist(string uri, string text = "")
        {
            var returnValue = false;
            using (var builder = new ChromeDriverWarpper(uri))
            {
                try
                {
                    if(builder.driver.PageSource.Contains(text, StringComparison.OrdinalIgnoreCase))
                    {
                        returnValue = false;
                    } else
                    {
                        returnValue = true;
                    }
                }
                catch
                {
                    returnValue = true;
                }
                var rand = new Random();
            }
            return returnValue;
        }

        public bool checkSupplyUntilTextNotExist(string uri, string text = "")
        {
            var returnValue = false;
            using (var builder = new ChromeDriverWarpper(uri))
            {
                try
                {
                    if (builder.driver.PageSource.Contains(text, StringComparison.OrdinalIgnoreCase))
                    {
                        returnValue = true;
                    } else
                    {
                        returnValue = false;
                    }
                }
                catch
                {
                    returnValue = true;
                }
                var rand = new Random();
            }
            return returnValue;
        }

        public void OutputPageSource(string storeName,string uri)
        {
            using (var builder = new ChromeDriverWarpper(uri))
            {
                Thread.Sleep(500);
                File.WriteAllText( String.Format("store\\{0}.txt",storeName), builder.driver.PageSource);
            }
        }
    }
}