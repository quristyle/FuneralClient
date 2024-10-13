using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using FuneralClient.Model;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel {
  public partial class CodeListPopViewModel : BaseViewModel, INotifyPropertyChanged {



    private readonly IPopupService popupService;

    public CodeListPopViewModel(IPopupService popupService) {
      this.popupService = popupService;
    }

    //public void DisplayPopup() {
    //  this.popupService.ShowPopup<UpdatingPopupViewModel>();
    //}


    public void DisplayPopup() {
      //this.popupService.ShowPopup<UpdatingPopupViewModel>(onPresenting: viewModel => viewModel.PerformUpdates(10));
    }
  }


}

