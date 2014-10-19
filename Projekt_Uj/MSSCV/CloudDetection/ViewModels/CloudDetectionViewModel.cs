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

            cloudDetectorService.SetValues(56, 36);
        }

        #endregion //Constructor

        #region Methods

        public async Task<string> ProcessImage(Bitmap input)
        {
            Original = new Bitmap(input);

            if (nightDetectorService.IsNight(input))
            {
                return "Night detected!";
            }
            else
            {
                await saturationService.Execute(input);
                SubresultAvailableEvent(this, "Saturation succesfull...");

                await blurService.Execute(input);
                SubresultAvailableEvent(this, "Blur succesfull...");

                await cloudDetectorService.Execute(input);
                SubresultAvailableEvent(this, "Cloud detection succesfull...");

                Cloudiness = cloudinessService.Execute(input);

                if (Cloudiness != -1)
                {
                    SubresultAvailableEvent(this, "Cloudiness: " + Cloudiness + " okta...");
                }
                else
                {
                    SubresultAvailableEvent(this, "Cloudiness detection failed!");
                    return "Cloud detection failed!";
                }

                CloudType = cloudTypeService.Execute(Original, input, Cloudiness);

                if (CloudType != null)
                {
                    SubresultAvailableEvent(this, "Cloud type: " + CloudType);
                }
                else
                {
                    SubresultAvailableEvent(this, "Cloudtype detection failed!");
                    return "Cloud detection failed!";
                }


                return CloudType + ", " + Cloudiness + " okta";
            }
        }

        #endregion //Methods
    }
}
