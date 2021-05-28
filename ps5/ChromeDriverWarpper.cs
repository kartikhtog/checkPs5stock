using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ps5
{
    class ChromeDriverWarpper: IDisposable
    {
        public ChromeDriver driver { get; set; }
        public ChromeDriverWarpper(string uri)
        {
            Random rand = new Random();
            try
            {
                driver = new ChromeDriver(".\\");
                driver.Url = uri;
                Thread.Sleep(rand.Next(300, 2000));
            }
            catch
            {
                driver.Quit();
            }
        }
        public virtual void Dispose()
        {
            Thread.Sleep(200);
            driver.Quit();
        }
    }
}
