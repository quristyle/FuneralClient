using CommunityToolkit.Mvvm.ComponentModel;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel {
  public partial class CardRoomViewModel : BaseViewModel {

    LoginService loginService;

    public CardRoomViewModel(LoginService loginService) {
      Title = "CardRoomViewModel";
      this.loginService = loginService;
    }


  }
}
