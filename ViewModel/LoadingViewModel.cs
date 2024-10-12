using CommunityToolkit.Mvvm.ComponentModel;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel {
  public partial class LoadingViewModel : BaseViewModel {

    LoginService loginService;

    public LoadingViewModel(LoginService loginService) {
      Title = "BuildViewModel";
      this.loginService = loginService;
    }


  }
}
