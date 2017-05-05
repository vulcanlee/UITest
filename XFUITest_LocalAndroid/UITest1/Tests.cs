using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("登入頁面");
        }

        [Test]
        public void LoginTest()
        {
            app.Screenshot("登入頁面");
            app.EnterText(x => x.Class("EntryEditText"), "vulcan");
            app.Tap(x => x.Class("EntryEditText").Index(1));
            app.EnterText(x => x.Class("EntryEditText").Index(1), "123");
            app.Tap(x => x.Text("登入"));
            app.WaitForElement(x => x.Id("message"));
            app.Screenshot("登入錯誤頁面");
            app.Tap(x => x.Id("button2"));
            app.WaitFor(() =>
            {
                Thread.Sleep(1000);
                return true;
            });
            app.Tap(x => x.Class("EntryEditText"));
            app.EnterText(x => x.Class("EntryEditText"), "1");
            app.Tap(x => x.Class("EntryEditText").Index(1));
            app.EnterText(x => x.Class("EntryEditText").Index(1), "1");
            app.Tap(x => x.Text("登入"));
            app.WaitFor(() =>
            {
                Thread.Sleep(4000);
                return true;
            });
            app.WaitForElement(x => x.Text("歡迎來到 Xamarin.Forms 的跨平台開發世界"));
            app.Screenshot("登入成功頁面");
        }
    }
}

