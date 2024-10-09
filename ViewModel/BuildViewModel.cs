using CommunityToolkit.Mvvm.Input;
using FuneralClient.Model;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel
{
    public partial class BuildViewModel : BaseViewModel {

        BuildService buildService;

        public ObservableCollection<Build> Builds { get; } = new();


        public BuildViewModel(BuildService buildService) {
            Title = "BuildViewModel";
            this.buildService = buildService;
        }

        [RelayCommand]
        async Task GetBuildsAsync() {
            if (IsBusy) return;


            try {
                IsBusy = true;
                var builds = await buildService.GetBuilds();

                foreach (var build in builds) {
                    Builds.Add(build);
                }

            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!!", ex.Message, "OK");
            }
            finally {
                IsBusy = false;
            }

        }


    }
}
