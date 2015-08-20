using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ApplicationInsightExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int Level = 0;
        public MainPage()
        {
            this.InitializeComponent();




            //var client = new TelemetryClient();
            //client.TrackPageView("MainPage"); // sayfa görüntülemesini azure'a push eder.

            //client.TrackEvent("Oyun "+Level +" levelda kaybetti.");//eventin kaç kez tetiklendiğini falan da takip edebiliriz


        }

        private async void kameraBtn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationView.GetForCurrentView().TitleBar.BackgroundColor = Colors.Red; // Uygulamanın title barı kırmızı olur
            ApplicationView.GetForCurrentView().IsScreenCaptureEnabled = false; // Ekran screen shoot alınamaz.


            var client = new TelemetryClient();

            client.TrackEvent("ResimCekButonunaTiklandi");

            var camera = new CameraCaptureUI();

            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            camera.PhotoSettings.AllowCropping = true;

            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

            // resmi azure'a upload etmek için önce WindowsAzure.Storage 'ı nugetten ekle
            // var acount= CloudStorageAccount.Parse("");
            // var blobClient = account.CreateCloudBlobClient();
            // var folder = blobClient.GetBlockBlobReference("images");
            // burada azure'da blob'un içinde images klasorunde profile.jpg adında bir alan oluşturup çekilen fotoğraf buraya upload edilir.
            // var blobFile = folder.GetBlockBlobReference("profile.jpg");
            // blobFile.UploadFromFileAsync(file);
        }
    }
}
