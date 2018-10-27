using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace DemoMap.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<Pin> _pins;
        public ObservableCollection<Pin> Pins
        {
            get { return _pins; }
            set { SetProperty(ref _pins, value); }
        }

        public DelegateCommand<MapClickedEventArgs> MapClickedCommand =>
        new DelegateCommand<MapClickedEventArgs>(args =>
        {
            Pins.Add(new Pin
            {
                Label = $"Pin{Pins.Count}",
                Position = args.Point
            });
        });

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            
        }
    }
}
