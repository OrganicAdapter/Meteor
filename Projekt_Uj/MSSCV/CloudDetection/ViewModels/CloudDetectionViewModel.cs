using CloudDetection.Models;
using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetection.ViewModels
{
    public class CloudDetectionViewModel : IImageProcessService
    {
        #region Events

        public event SubresultAvailableEventHandler SubresultAvailableEvent;

        #endregion //Events

        #region Fields



        #endregion //Fields

        #region Properties

        public NightDetectorService nightDetectorService { get; set; }
        private SaturationService saturationService { get; set; }
        private BlurService blurService { get; set; }
        private CloudDetectorService cloudDetectorService { get; set; }
        private CloudinessService cloudinessService { get; set; }
        private CloudTypeService cloudTypeService { get; set; }

        private Bitmap Original { get; set; }
        private int Cloudiness { get; set; }
        private string CloudType { get; set; }

        #endregion //Properties

        #region Constructor

        public CloudDetectionViewModel()
        {
            nightDetectorService = new NightDetectorService();
            saturationService = new SaturationService();
            blurService = new BlurService();
            cloudDetectorService = new CloudDetectorService();
            cloudinessService = new CloudinessService();
            cloudTypeService = new CloudTypeService();
        }

        #endregion //Constructor

        #region Methods

        public string ProcessImage(Bitmap input)
        {
            Original = new Bitmap(input);

            if (nightDetectorService.IsNight(input))
            {
                return "Night detected!";
            }
            else
            {
                saturationService.Execute(input);
                SubresultAvailableEvent(this, "Saturation succesfull...");
                blurService.Execute(input);
                SubresultAvailableEvent(this, "Blur succesfull...");
                cloudDetectorService.Execute(input);
                SubresultAvailableEvent(this, "Cloud detection succesfull...");
                Cloudiness = cloudinessService.Execute(input);
                SubresultAvailableEvent(this, "Cloudiness: " + Cloudiness + " okta...");
                CloudType = cloudTypeService.Execute(Original, input, Cloudiness);
                SubresultAvailableEvent(this, "Cloud type: " + CloudType);

                return CloudType + ", " + Cloudiness + " okta";
            }
        }

        #endregion //Methods
    }
}
