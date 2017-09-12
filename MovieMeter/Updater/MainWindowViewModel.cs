using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    public class MainWindowViewModel
    {
        private IMovieMeterService _movieMeterService;

        public MainWindowViewModel(IMovieMeterService movieMeterService)
        {
            _movieMeterService = movieMeterService;

            CreateUpdateCommand = new DelegateCommand(OnCreteUpdate);
        }

        public DelegateCommand CreateUpdateCommand { get; set; }

        private async void OnCreteUpdate(object param)
        {
            await Task.Run(() =>
            {
                _movieMeterService.CreateUpdate("529c56db-6a1e-41b2-9af6-6a9ff3192ddc");
            });
        }
    }
}
