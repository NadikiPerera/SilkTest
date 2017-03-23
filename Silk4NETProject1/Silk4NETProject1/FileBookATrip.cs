using System;
using System.Collections.Generic;
using SilkTest.Ntf;
using Silk.KeywordDriven;
using SilkTest.Ntf.XBrowser;
using NUnit.Framework;
using System.Threading;
using Silk4NETProject1.Actions;


[TestFixture]
[Parallelizable]
//[TestFixture("Chrome")]
//[TestFixture("Firefox")]
//[TestFixture("ie")]
public class FileBookATrip
{

    public static readonly Desktop _desktop = Agent.Desktop;
    private String browser;
    public static BrowserApplication webBrowser;
    public static BrowserWindow browserWindow;
    public static BrowserBaseState baseState;
    
    
    //public void BrowserFileBookATrip(String browser)
    //{
    //    if (browser.Equals("Chrome"))
    //    {
    //        baseState = new BrowserBaseState(BrowserType.GoogleChrome, "https://www.qantas.com/au/en.html");
    //        //baseState.Execute();
    //    }

    //    else
    //    {
    //        if (browser.Equals("Firefox"))
    //        {
    //            baseState = new BrowserBaseState(BrowserType.Firefox, "https://www.qantas.com/au/en.html");
    //            // baseState.Execute();
    //        }

    //        else
    //        {
    //            if (browser.Equals("ie"))
    //            {
    //                baseState = new BrowserBaseState(BrowserType.InternetExplorer, "https://www.qantas.com/au/en.html");
    //                // baseState.Execute();
    //            }

    //        }
    //    }

      
    //}

  
    
    [SetUp]
    [Keyword("Start application", IsBaseState = true)]
    public void Start_application()
    {
       
        baseState = new BrowserBaseState(BrowserType.GoogleChrome, "https://www.qantas.com/au/en.html");
      
    }

    //multiple browser parallel test execution code for selenium
    //public static IEnumerable<String> BrowsersType()
    //{

    //    String[] browsers = Silk4NETProject1.BrowserSetup.browserType.Split(',');

    //    foreach (String b in browsers)
    //    {
    //        yield return b;

    //    }

    //}


    [Test]
   // [TestCaseSource("BrowsersType")]
    [Keyword]
    public static void BookATrip()//String browserName)
    {

       // BrowserFileBookATrip(browser);
       // baseState = new BrowserBaseState(browserName, "https://www.qantas.com/au/en.html");
        baseState.Execute();
        webBrowser = _desktop.BrowserApplication("qantas_com");
        Thread.Sleep(5000);
        browserWindow = webBrowser.BrowserWindow("BrowserWindow");
        Thread.Sleep(2000);

        //  webBrowser.PushButton("Maximize").Select();
        browserWindow.DomButton("qfa1-submit-button__").Click();
       
        browserWindow.DomElement("M20 1548387,17 49156").Click();
        browserWindow.DomTextField("typeahead-input-from").TypeKeys("melbourne");
        browserWindow.DomElement("typeahead-list-item-2").Click();
        browserWindow.DomTextField("typeahead-input-to").TypeKeys("colombo");
        browserWindow.DomElement("typeahead-list-item-2").Click();

        browserWindow.DomElement("M10,18 L14,18 L14,22").Click();
        browserWindow.DomElement("date-picker__calenda").Click();
        browserWindow.DomElement("object SVGAnimatedR").Click();
        browserWindow.DomElement("date-picker__calenda2").Click();
        Thread.Sleep(2000);
       
             
        browserWindow.DomElement("M245,88 8026316 L242").Click();
        browserWindow.DomElement("M269,45 L269,41 L2672").Click();
        Thread.Sleep(3000);
        browserWindow.DomElement("M269,45 L269,41 L267").Click();              
        browserWindow.DomElement("M269,45 L269,41 L2673").Click();
        Thread.Sleep(5000);
        
        browserWindow.DomButton("SELECT").DoubleClick();
        Thread.Sleep(2000);
        browserWindow.DomElement("M245,88 8026316 L242").DoubleClick();
        Thread.Sleep(1000);
        browserWindow.DomElement("button2").Click();
        browserWindow.DomElement("select-picker-select").Click();
        Thread.Sleep(1000);
       // browserWindow.DomButton("SELECT").Click();
        Assert.AreEqual("Book a trip", browserWindow.DomLink("panel-book-a-trip").Text, "Book a trip validation successful");
        Thread.Sleep(1000);
        browserWindow.DomButton("SEARCH FLIGHTS").Click();
        Thread.Sleep(5000);
        Assert.AreEqual(true, browserWindow.DomElement("skipToContent").Visible);
        Assert.AreEqual("Select your fare", browserWindow.DomElement("skipToContent").Text, "Search Flights successful" );
       // webBrowser.PushButton("Close").Click();

        // Assert.AreEqual("Check-in", browserWindow.DomLink("panel-check-in").Text);
        //SelectCity("Melbourne, Australia [Mel]", 1);

    }



}