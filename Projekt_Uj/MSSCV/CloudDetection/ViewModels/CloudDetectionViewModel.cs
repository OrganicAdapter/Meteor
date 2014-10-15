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

        #endregion //Properties

        #region Constructor

        public CloudDetectionViewModel()
        {
            nightDetectorService = new NightDetectorService();
            saturationService = new SaturationService();
            blurService = new BlurService();
        }

        #endregion //Constructor

        #region Methods

        public string ProcessImage(Bitmap input)
        {
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

                return "";
            }
        }

        #endregion //Methods
    }
}
