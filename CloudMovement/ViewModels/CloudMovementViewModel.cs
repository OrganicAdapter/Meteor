using Accord.Imaging;
using AForge;
using CloudMovement.Models;
using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovement.ViewModels
{
    public class CloudMovementViewModel : IImageProcessService
    {
        #region Events

        public event SubresultAvailableEventHandler SubresultAvailableEvent;

        #endregion //Events

        #region Fields



        #endregion //Fields

        #region Properties

        private DirectionDetectorService directionDetectorService { get; set; }

        #endregion //Properties

        #region Constructor

        public CloudMovementViewModel()
        {
            directionDetectorService = new DirectionDetectorService();
            directionDetectorService.SubprocessCompletedEven += SubresultAvailable;

            SetValues();
        }

        #endregion //Constructor

        #region Methods

        /// <summary>
        /// Get the cloudiness and cloud type in string format.
        /// </summary>
        /// <param name="input">Original image</param>
        /// <returns>Cloud type and cloudiness</returns>
        public async Task<string> ProcessImage(List<Bitmap> inputList)
        {
            var result = await directionDetectorService.DetectDirection(inputList);
            if (result.Contains("No"))
                SubresultAvailableEvent(this, "No wind detected!");
            else
                SubresultAvailableEvent(this, "Wind direction detected!");

            return result;
        }

        void SubresultAvailable(object sender, string result)
        {
            SubresultAvailableEvent(this, "Direction: " + result);
        }

        public async void SetValues()
        {
            if (File.Exists("windConfig.txt"))
            {
                using (var sr = new StreamReader("windConfig.txt"))
                {
                    int direction = int.Parse(await sr.ReadLineAsync());
                    int quarters = int.Parse(await sr.ReadLineAsync());

                    directionDetectorService.SetValues(direction, quarters);
                }
            }
        }

        public async void SaveValues(int quarterThreshold, int directionThreshold)
        {
            try
            {
                using (var sw = new StreamWriter("cloudConfig.txt"))
                {
                    await sw.WriteLineAsync(directionThreshold.ToString());
                    await sw.WriteLineAsync(quarterThreshold.ToString());

                    directionDetectorService.SetValues(directionThreshold, quarterThreshold);
                }
            }

            catch (IOException)
            {

            }
        }

        #endregion //Methods
    }
}
