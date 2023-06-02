using CrawlerApp.Application.Common.Models.Crawler;
using CrawlerApp.Application.Common.Models.Product;
using CrawlerApp.Application.Features.Products.Commands.Add;
using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("UpSchool Crawler");
Console.ReadKey();

new DriverManager().SetUpDriver(new ChromeConfig());
IWebDriver driver = new ChromeDriver();

var hubConnection = new HubConnectionBuilder()
    .WithUrl($"https://localhost:7015/Hubs/CrawlerLogHub")
    .WithAutomaticReconnect()
    .Build();

await hubConnection.StartAsync();

try
{
    //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot started."));

    driver.Navigate().GoToUrl("https://finalproject.dotnet.gg/");
    //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Navigated to finalproject.dotnet.gg"));

    // We are waiting for fun. 
    Thread.Sleep(1500);

    var pageNumbers = driver.FindElements(By.ClassName("page-number"));

    //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"Toplam {pageNumbers.Count} sayfa ürün bulunduğu tespit edildi. " + DateTimeOffset.Now + "\n"));

    // We are waiting for the results to load.
    Thread.Sleep(3000);

    for (int i = 0; i < pageNumbers.Count; i++)
    {
        var productCard = driver.FindElements(By.ClassName("card-body"));
        var productImages = driver.FindElements(By.ClassName("card-img-top"));

        for (int j = 0; j < productCard.Count; j++)
        {
            string picture = productImages[j].GetAttribute("src");

            string[] parts = productCard[j].Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var name = parts[0];

            string[] prices = parts[1].Split(' ');

            decimal price = decimal.Parse(prices[0].TrimStart('$'));

            decimal salePrice = 0;

            if (prices.Length == 2)
            {
                salePrice = decimal.Parse(prices[1].TrimStart('$'));
            }

            await hubConnection.InvokeAsync("GetAllProductsAsync", AddProduct(name, picture, price, salePrice));
        }

        //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"{i + 1}. sayfa tarandı. Toplam {productNames.Count} ürün bulundu. " + DateTime.Now + "\n"));

        if (i != pageNumbers.Count - 1)
        {
            var nextButton = driver.FindElement(By.ClassName("next-page"));

            driver.Navigate().GoToUrl(nextButton.GetAttribute("href"));

            //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog($"---------- {i + 2}. sayfaya geçildi. ---------- " + DateTime.Now + "\n"));
        }
    }


    Console.ReadKey();

//await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot stopped."));

driver.Quit();
}
catch (Exception exception)
{
    driver.Quit();
}

CrawlerLogDto CreateLog(string message) => new CrawlerLogDto(message);
ProductDto AddProduct(string name, string picture, decimal price, decimal salePrice) => new ProductDto(name, picture, price, salePrice);
