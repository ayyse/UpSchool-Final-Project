using CrawlerApp.Application.Common.Models.Crawler;
using CrawlerApp.Application.Common.Models.Product;
using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

Console.WriteLine("UpSchool Crawler");
Console.ReadKey();

new DriverManager().SetUpDriver(new ChromeConfig());
IWebDriver webDriver = new ChromeDriver();

var hubConnection = new HubConnectionBuilder()
    .WithUrl($"https://localhost:7015/Hubs/CrawlerLogHub")
    .WithAutomaticReconnect()
    .Build();

await hubConnection.StartAsync();

try
{
    await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot started."));

    webDriver.Navigate().GoToUrl("https://finalproject.dotnet.gg/");
    await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Navigated to finalproject.dotnet.gg"));

    // We are waiting for fun. 
    Thread.Sleep(1500);

    var pageNumbers = webDriver.FindElements(By.ClassName("page-number"));

    await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"Toplam {pageNumbers.Count} sayfa ürün bulunduğu tespit edildi. " + DateTimeOffset.Now + "\n"));
    
    // We are waiting for the results to load.
    Thread.Sleep(3000);

    for (int i = 0; i < pageNumbers.Count; i++)
    {
        var productNames = webDriver.FindElements(By.ClassName("product-name"));
        var productImages = webDriver.FindElements(By.ClassName("card-img-top"));

        for (int j = 0; j < productNames.Count; j++)
        {
            //await hubConnection.InvokeAsync("AddProductAsync", AddProduct(productNames[j].Text));
            
            //Console.WriteLine($"{j + 1}. ürün adı: " + AddProduct(productNames[j].Text));
            //Console.WriteLine($"{j + 1}. ürün fotoğrafı: " + productImages[j].GetAttribute("src") + "\n");
        }
        await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"{i + 1}. sayfa tarandı. Toplam {productNames.Count} ürün bulundu. " + DateTime.Now + "\n"));

        if (i != pageNumbers.Count - 1)
        {
            var nextButton = webDriver.FindElement(By.ClassName("next-page"));

            webDriver.Navigate().GoToUrl(nextButton.GetAttribute("href"));

            await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"---------- {i + 2}. sayfaya geçildi. ---------- " + DateTime.Now + "\n"));
        }
    }

    Console.ReadKey();

    await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot stopped."));

    webDriver.Quit();
}
catch (Exception exception)
{
    webDriver.Quit();
}

CrawlerLogDto CreateLog(string message) => new CrawlerLogDto(message);
//ProductDto AddProduct(string name) => new ProductDto(name);

