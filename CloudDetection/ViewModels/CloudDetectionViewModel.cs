﻿using AForge.Imaging.Filters;
using CloudDetection.Models;
using CloudDetection.Models.Datas;
using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private NightDetectorService nightDetectorService { get; set; }
        private SaturationService saturationService { get; set; }
        private BlurService blurService { get; set; }
        private CloudDetectorService cloudDetectorService { get; set; }
        private CloudinessService cloudinessService { get; set; }
        private CloudTypeService cloudTypeService { get; set; }

        private Bitmap Original { get; set; }
        private int Cloudiness { get; set; }
        private string CloudType { get; set; }
        private List<Result> Results { get; set; }


        public int CloudUpper { get; set; }
        public int SkyLower { get; set; }

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

            SetValues();
        }

        #endregion //Constructor

        #region Methods

        public async void SetValues()
        {
            if (!File.Exists("cloudConfig.txt"))
            {
                cloudDetectorService.SetValues(56, 36);
            }
            else
            {
                using (var sr = new StreamReader("cloudConfig.txt"))
                {
                    CloudUpper = int.Parse(await sr.ReadLineAsync());
                    SkyLower = int.Parse(await sr.ReadLineAsync());

                    cloudDetectorService.SetValues(CloudUpper, SkyLower);
                }
            }
        }

        public async void SaveValues(int cloudUpper, int skyLower)
        {
            try
            {
                using (var sw = new StreamWriter("cloudConfig.txt"))
                {
                    await sw.WriteLineAsync(cloudUpper.ToString());
                    await sw.WriteLineAsync(skyLower.ToString());
                }
            }

            catch (IOException)
            { 
            
            }
        }

        /// <summary>
        /// Get the cloudiness and cloud type in string format.
        /// </summary>
        /// <param name="input">Original image</param>
        /// <returns>Cloud type and cloudiness</returns>
        public async Task<string> ProcessImage(List<Bitmap> inputList)
        {
            await Calculate(inputList);
            GetCloudiness();

            if (Cloudiness == -1)
                return "Night";

            GetCloudType();

            return CloudType + ", " + Cloudiness + " okta";
        }

        private async Task Calculate(List<Bitmap> inputList)
        {
            Results = new List<Result>();

            foreach (var input in inputList)
            {
                Original = new Bitmap(input);

                if (nightDetectorService.IsNight(input))
                {
                    SubresultAvailableEvent(this, "Cant't detect clouds at night!");
                    Results.Add(new Result() { Type = "Night", Cloudiness = -1 });
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
                        Results.Add(new Result() { Type = null, Cloudiness = -1 });
                    }

                    CloudType = cloudTypeService.Execute(Original, input, Cloudiness);

                    if (CloudType != null)
                    {
                        SubresultAvailableEvent(this, "Cloud type: " + CloudType);
                    }
                    else
                    {
                        SubresultAvailableEvent(this, "Cloudtype detection failed!");
                        Results.Add(new Result() { Type = null, Cloudiness = -1 });
                    }

                    if (CloudType.Equals("Cumulus") && Cloudiness == 8)
                    {
                        Cloudiness = 7;
                        SubresultAvailableEvent(this, "Cloudiness modified to " + Cloudiness + " okta...");
                    }

                    SubresultAvailableEvent(this, "Cloud detection succesful!");
                    Results.Add(new Result() { Type = CloudType, Cloudiness = Cloudiness });
                }
            }
        }

        private void GetCloudiness()
        {
            var cloudinesses = new List<int>();

            foreach (var result in Results)
            {
                if (result.Cloudiness != -1)
                    cloudinesses.Add(result.Cloudiness);
            }

            var cloudMed = new int[9];

            var allZero = true;

            foreach (var item in cloudinesses)
            {
                if (item != 0)
                {
                    allZero = false;
                    break;
                }
            }

            if (allZero)
            {
                Cloudiness = -1;
            }
            else
            {
                foreach (var item in cloudinesses)
                    cloudMed[item]++;

                var max = 0;

                for (int i = 0; i < cloudMed.Length - 1; i++)
                {
                    if (cloudMed[i] > cloudMed[i + 1])
                        max = i;
                }

                Cloudiness = max;
            }
        }

        private void GetCloudType()
        {
            var types = new List<int>();

            foreach (var result in Results)
            {
                if (result.Type != null)
                    types.Add((result.Type.Equals("Cumulus") ? 0 : (result.Type.Equals("Stratus") ? 1 : 2)));
            }

            var cloudMed = new int[3];

            foreach (var item in types)
                cloudMed[item]++;

            var max = 0;

            for (int i = 0; i < cloudMed.Length - 1; i++)
            {
                if (cloudMed[i] > cloudMed[i + 1])
                    max = i;
            }

            CloudType = (max == 0) ? "Cumulus" : (max == 1) ? "Stratus" : "Night";
        }

        public async Task<Bitmap> GetThresholdedImage(Bitmap input, int lower, int upper)
        {
            try
            {
                await saturationService.Execute(input);
                await blurService.Execute(input);

                return await cloudDetectorService.GetImage(input, lower, upper);
            }

            catch
            {
                return null;
            }
        }

        public void AutoConfigureThresholds(Bitmap input)
        {
            var gray = new Grayscale(0.2125, 0.7154, 0.0721);
            var image = gray.Apply(input);

            var otsu = new OtsuThreshold();

            otsu.ApplyInPlace(image);
            var threshold = otsu.ThresholdValue;

            SaveValues(threshold - 30, threshold + 100);
            SetValues();

            image.Dispose();
        }

        #endregion //Methods
    }
}
