using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver webDriver = new ChromeDriver();
webDriver.Navigate().GoToUrl("https://finalproject.dotnet.gg/");

Console.WriteLine("Websiteye giriş yapıldı. " + DateTime.Now + "\n");

//webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

var pageNumbers = webDriver.FindElements(By.ClassName("page-number"));

Console.WriteLine($"Toplam {pageNumbers.Count} sayfa ürün bulunduğu tespit edildi. " + DateTime.Now + "\n");

for (int i = 0; i < pageNumbers.Count; i++)
{
    var productNames = webDriver.FindElements(By.ClassName("product-name"));
    var productImages = webDriver.FindElements(By.ClassName("card-img-top"));

    for (int j = 0; j < productNames.Count; j++)
    {
        Console.WriteLine($"{j + 1}. ürün adı: " + productNames[j].Text);
        Console.WriteLine($"{j + 1}. ürün fotoğrafı: " + productImages[j].GetAttribute("src") + "\n");
    }

    Console.WriteLine($"{i + 1}. sayfa tarandı. Toplam {productNames.Count} ürün bulundu. " + DateTime.Now + "\n");

    if (i != pageNumbers.Count - 1)
    {
        var nextButton = webDriver.FindElement(By.ClassName("next-page"));

        webDriver.Navigate().GoToUrl(nextButton.GetAttribute("href"));

        Console.WriteLine($"---------- {i + 2}. sayfaya geçildi. ---------- " + DateTime.Now + "\n");
    }
}

webDriver.Quit();
