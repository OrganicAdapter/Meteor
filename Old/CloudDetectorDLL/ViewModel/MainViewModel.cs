using CloudDetectorDLL.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkSkyProject.Common.Models;

namespace CloudDetectorDLL.ViewModel
{
    public class MainViewModel : ModelBase
    {
        #region Properties

        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();

                return _instance;
            }
        }



        private int _cloudiness;
        public int Cloudiness
        {
            get { return _cloudiness; }
            set { _cloudiness = value; OnPropertyChanged("Cloudiness"); }
        }

        private string _cloudtype;
        public string CloudType
        {
            get { return _cloudtype; }
            set { _cloudtype = value; OnPropertyChanged("CloudType"); }
        }

        private int _realcloudiness;
        public int RealCloudiness
        {
            get { return _realcloudiness; }
            set { _realcloudiness = value; OnPropertyChanged("RealCloudiness"); }
        }

        private string _realcloudtype;
        public string RealCloudType
        {
            get { return _realcloudtype; }
            set { _realcloudtype = value; OnPropertyChanged("RealCloudType"); }
        }

        private double _percentage;
        public double Percentage
        {
            get { return _percentage; }
            set { _percentage = value; OnPropertyChanged("Percentage"); }
        }

        private int _imagesCount;
        public int ImagesCount
        {
            get { return _imagesCount; }
            set { _imagesCount = value; OnPropertyChanged("ImagesCount"); }
        }



        private Bitmap _originalimage;
        public Bitmap OriginalImage
        {
            get { return _originalimage; }
            set { _originalimage = value; OnPropertyChanged("OriginalImage"); }
        }

        private Bitmap _saturationimage;
        public Bitmap SaturationImage
        {
            get { return _saturationimage; }
            set { _saturationimage = value; OnPropertyChanged("SaturationImage"); }
        }

        private Bitmap _thresholdimage;
        public Bitmap ThresholdImage
        {
            get { return _thresholdimage; }
            set { _thresholdimage = value; OnPropertyChanged("ThresholdImage"); }
        }

        private string _nightorday;
        public string NightOrDay
        {
            get { return _nightorday; }
            set { _nightorday = value; OnPropertyChanged("NightOrDay"); }
        }


        public int CloudUpper { get; set; }
        public int SkyLower { get; set; }

        private int _testedImagesCount;
        public int TestedImagesCount
        {
            get { return _testedImagesCount; }
            set { _testedImagesCount = value; OnPropertyChanged("TestedImagesCount"); }
        }

        private int _allImagesCount;
        public int AllImagesCount
        {
            get { return _allImagesCount; }
            set { _allImagesCount = value; OnPropertyChanged("AllImagesCount"); }
        }


        public double GoodImagesCount { get; set; }
        public string FileName { get; set; }

        public string[] Names { get; set; }
        public string[] FullPath { get; set; }

        #endregion


        public MainViewModel()
        {
            LoadConfiguration();

            Percentage = 100;
            TestedImagesCount = 0;
            GoodImagesCount = 0;

            ImagesCount = 5;
        }


        public void Open()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = new Bitmap(openFileDialog.FileName);

                try
                {
                    var name = openFileDialog.SafeFileName;

                    name = name.Split('.').FirstOrDefault();
                    FileName = name;

                    var splitname = name.Split('_');

                    RealCloudType = splitname[0];
                    RealCloudiness = int.Parse(splitname[2]);
                }
                catch { }
            }
        }

        public void FakeOpen(Bitmap image, string fileName)
        {
            OriginalImage = image;

            try
            {
                var name = fileName;

                name = name.Split('.').FirstOrDefault();
                FileName = name;

                var splitname = name.Split('_');

                RealCloudType = splitname[0];
                RealCloudiness = int.Parse(splitname[2]);
            }
            catch { }
        }

        public void OpenSequence()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var akt = openFileDialog.SafeFileNames;
                Names = akt;
                FullPath = openFileDialog.FileNames;

                Thread thr = new Thread(SequenceStatics);
                thr.Start();
            }
        }

        private void SequenceStatics()
        {
            try
            {
                TestedImagesCount = 0;
                GoodImagesCount = 0;

                var akt = Names;
                AllImagesCount = akt.Length / ImagesCount;

                var realcloudiness = 0;
                int[] realcloudtypes = new int[ImagesCount];
                var cloudiness = 0;
                int[] cloudtypes = new int[ImagesCount];

                for (int i = 0; i < akt.Length; i += ImagesCount)
                {
                    for (int j = 0; j < ImagesCount; j++)
                    {
                        if (i + ImagesCount < akt.Length)
                        {
                            var name = Names[i];

                            name = name.Split('.').FirstOrDefault();
                            FileName = name;

                            var splitname = name.Split('_');

                            var ctype = splitname[0];
                            realcloudtypes[j] = (ctype == "Cumulus") ? 0 : 1;
                            realcloudiness += int.Parse(splitname[2]);

                            var img = new Bitmap(FullPath[i + j]);

                            var sat = SaturationModel.GetSaturation_1(img);
                            sat = GaussModel.GetGaussAForge(sat);

                            var cloud = CloudDetectorModel.GetClouds_1(sat, CloudUpper, SkyLower);
                            Cloudiness = CloudDetectorModel.GetCloudiness(cloud);
                            cloudiness += Cloudiness;
                            ctype = CloudTypeModel.GetCloudType(img, cloud, Cloudiness);
                            cloudtypes[j] = (ctype == "Cumulus") ? 0 : 1;

                            img.Dispose();
                            sat.Dispose();
                            cloud.Dispose();
                        }
                        else
                        {
                            break;
                        }
                    }

                    Cloudiness = (int)Math.Round((double)(cloudiness / ImagesCount));
                    RealCloudiness = (int)Math.Round((double)(realcloudiness / ImagesCount));

                    CloudType = GetMax(cloudtypes);
                    RealCloudType = GetMax(realcloudtypes);

                    cloudiness = 0;
                    realcloudiness = 0;

                    if (CloudType == "Cumulus" && Cloudiness == 8) Cloudiness = 7;

                    SetPercentage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetMax(int[] array)
        {
            int cumulus = 0;
            int stratus = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    cumulus++;
                else
                    stratus++;
            }

            return (cumulus >= stratus) ? "Cumulus" : "Stratus";
        }

        public void RunTest()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //var akt = openFileDialog.FileNames;
                var akt = openFileDialog.SafeFileNames;
                Names = akt;
                FullPath = openFileDialog.FileNames;

                Thread thr = new Thread(ThreadStatics);
                thr.Start();
            }
        }

        private void ThreadStatics()
        {
            try
            {
                TestedImagesCount = 0;
                GoodImagesCount = 0;

                var akt = Names;
                AllImagesCount = akt.Length;

                for (int i = 0; i < akt.Length; i++)
                {
                    var name = Names[i];

                    name = name.Split('.').FirstOrDefault();
                    FileName = name;

                    var splitname = name.Split('_');

                    RealCloudType = splitname[0];
                    RealCloudiness = int.Parse(splitname[2]);

                    var img = new Bitmap(FullPath[i]);

                    var sat = SaturationModel.GetSaturation_1(img);
                    sat = GaussModel.GetGaussAForge(sat);
                    var cloud = CloudDetectorModel.GetClouds_1(sat, CloudUpper, SkyLower);
                    Cloudiness = CloudDetectorModel.GetCloudiness(cloud);
                    CloudType = CloudTypeModel.GetCloudType(img, cloud, Cloudiness);

                    if (CloudType == "Cumulus" && Cloudiness == 8) Cloudiness = 7;

                    SetPercentage();

                    img.Dispose();
                    sat.Dispose();
                    cloud.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSaturation()
        {
            if (OriginalImage == null)
            {
                MessageBox.Show("Először nyiss meg egy képet!");
                return;
            }

            SaturationImage = SaturationModel.GetSaturation_1(OriginalImage);

            CommonImageSource.Instance.SetImage("Saturation", SaturationImage);
        }

        public void SetGauss(int count)
        {
            if (SaturationImage == null)
            {
                MessageBox.Show("Először kell egy szaturációs kép!");
                return;
            }

            //Bitmap a = new Bitmap(SaturationImage);

            //for (int i = 0; i < count; i++)
            //{
            //    a = GaussModel.GetGaussAForge(a);
            //}

            //SaturationImage = a;

            SaturationImage = GaussModel.GetGaussAForge(SaturationImage);

            CommonImageSource.Instance.SetImage("Saturation(Blur)", SaturationImage);
        }

        public void GetClouds()
        {
            if (SaturationImage == null)
            {
                MessageBox.Show("Először kell egy szaturációs kép!");
                return;
            }

            ThresholdImage = CloudDetectorModel.GetClouds_1(SaturationImage, CloudUpper, SkyLower);

            CommonImageSource.Instance.SetImage("Cloud threshold", ThresholdImage);
        }

        public void GetCloudiness()
        {
            if (ThresholdImage == null)
            {
                MessageBox.Show("Először detektáld a felhőket!");
                return;
            }

            Cloudiness = CloudDetectorModel.GetCloudiness(ThresholdImage);
        }

        public void GetCloudType()
        {
            if (OriginalImage == null || ThresholdImage == null)
            {
                MessageBox.Show("A detektáláshoz szükséged van egy küszöbölt képre és a borultság értékére!");
                return;
            }

            CloudType = CloudTypeModel.GetCloudType(OriginalImage, ThresholdImage, Cloudiness);
            
            if (CloudType == "Cumulus" && Cloudiness == 8) Cloudiness = 7;
        }

        public void GetFullDetection()
        {
            GetNight();

            if (NightOrDay == "Éjszaka")
                return;

            GetSaturation();
            SetGauss(20);
            GetClouds();
            GetCloudiness();
            GetCloudType();

            SetPercentage();
        }

        private void SetPercentage()
        {
            try
            {
                TestedImagesCount++;

                if (Math.Abs(RealCloudiness - Cloudiness) <= 1 && RealCloudType == CloudType)
                    GoodImagesCount++;
                else if ((Math.Abs(RealCloudiness - Cloudiness) <= 1 && RealCloudType != CloudType) || (Math.Abs(RealCloudiness - Cloudiness) > 1 && RealCloudType == CloudType))
                    GoodImagesCount += 0.5;

                Percentage = (GoodImagesCount / TestedImagesCount) * 100;

                AddToList();
            }
            catch { }
        }

        private async void AddToList()
        {
            using (var sw = File.AppendText("stats.txt"))              
                await sw.WriteLineAsync(FileName + ":\t" + RealCloudType + " - " + CloudType + "\t//\t" + RealCloudiness + " - " + Cloudiness);
        }

        public void GetAutoConfiguration()
        {
            GetSaturation();
            SetGauss(20);
            AutoConfigurationModel.GetThresholdLevels_2(SaturationImage);
        }

        public async void SaveConfiguration()
        {
            using (var sw = new StreamWriter("config.txt"))
            {
                await sw.WriteLineAsync(CloudUpper.ToString());
                await sw.WriteLineAsync(SkyLower.ToString());
            }
        }

        public async void LoadConfiguration()
        {
            if (!File.Exists("config.txt"))
            {
                CloudUpper = 36;
                SkyLower = 56;

                SaveConfiguration();
            }
            else
            {
                using (var sr = new StreamReader("config.txt"))
                {
                    CloudUpper = int.Parse(await sr.ReadLineAsync());
                    SkyLower = int.Parse(await sr.ReadLineAsync());
                }
            }
        }

        public void GetNight()
        {
            if (NightDetector.GetNight(OriginalImage))
                NightOrDay = "Éjszaka";
            else
                NightOrDay = "Nappal";
        }
    }
}
