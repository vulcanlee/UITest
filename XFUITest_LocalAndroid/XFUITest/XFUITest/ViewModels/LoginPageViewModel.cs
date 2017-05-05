using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFUITest.ViewModels
{

    [ImplementPropertyChanged]
    public class LoginPageViewModel : INavigationAware
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)
        public string Account { get; set; }
        public string Password { get; set; }
        public bool ShowMask { get; set; } = false;
        #region 基本型別與類別的 Property

        #endregion

        #region 集合類別的 Property

        #endregion

        #endregion

        #region Field 欄位

        #region ViewModel 內使用到的欄位
        #endregion

        #region 命令物件欄位

        public DelegateCommand 登入Command { get; set; }

        #endregion

        #region 注入物件欄位
        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        #endregion

        #endregion

        #region Constructor 建構式
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            #region 相依性服務注入的物件

            _dialogService = dialogService;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            登入Command = new DelegateCommand(async () =>
            {
                if(Account == "1" && Password == "1")
                {
                    Random rm = new Random(DateTime.UtcNow.Millisecond);
                    var fooWait = rm.Next(1000, 3000);
                    ShowMask = true;
                    await Task.Delay(fooWait);
                    await _navigationService.NavigateAsync("xf:///NavigationPage/MainPage");
                }
                else
                {
                    await _dialogService.DisplayAlertAsync("警告", "帳號或者密碼不正確", "確定");
                    Account = "";
                    Password = "";
                }
            });
            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await ViewModelInit();
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        /// <summary>
        /// ViewModel 資料初始化
        /// </summary>
        /// <returns></returns>
        private async Task ViewModelInit()
        {
            await Task.Delay(100);
        }
        #endregion

    }
}
