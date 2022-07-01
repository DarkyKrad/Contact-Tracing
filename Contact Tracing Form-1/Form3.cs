using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.QrCode;
using System.Diagnostics;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Contact_Tracing_Form_1
{

    public partial class Form3 : Form
    {
        private BarcodeReaderGeneric barcodeReader = new BarcodeReaderGeneric(new QRCodeReader(), null, null);

        public delegate void QRCodeReadEventHandler(object sender, QRCodeReadEventArgs eventArgs);
        public event QRCodeReadEventHandler QRCodeRead;


        public Form3()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void Form3_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cmbDevices.Items.Add(filterinfo.Name);
            cmbDevices.SelectedIndex = 0;
        }


        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void form3_closing(object sender, FormClosingEventArgs e)
        {
            stopCapture();
        }
        private void videocaptureerror(object sender, VideoSourceErrorEventArgs e)
        {
            txtError.Text = e.Description;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (pictureBox1.Image is not null)
            {

                Bitmap bmp = (Bitmap)pictureBox1.Image;
                var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;

                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                bmp.UnlockBits(bmpData);
                var bitmapFormat = bmp.PixelFormat switch
                {
                    PixelFormat.Format24bppRgb => RGBLuminanceSource.BitmapFormat.RGB24,
                    PixelFormat.Format32bppRgb => RGBLuminanceSource.BitmapFormat.RGB32,
                    PixelFormat.Format32bppArgb => RGBLuminanceSource.BitmapFormat.ARGB32,
                    PixelFormat.Format16bppRgb565 => RGBLuminanceSource.BitmapFormat.RGB565,
                    PixelFormat.Format16bppGrayScale => RGBLuminanceSource.BitmapFormat.Gray16,
                    _ => RGBLuminanceSource.BitmapFormat.Unknown,
                };

                Result result = barcodeReader.Decode(rgbValues, bmp.Width, bmp.Height, bitmapFormat);
                if (result is not null)
                {

                    timer1.Stop();
                    stopCapture();
                    QRCodeRead(this, new QRCodeReadEventArgs { Data = result.Text });
                    this.Close();
                }
            }
        }

        private void stopCapture()
        {
            if (captureDevice is not null)
            {
                captureDevice.SignalToStop();
                captureDevice.WaitForStop();
                captureDevice = null;
            }

        }

        private void form3_shown(object sender, EventArgs e)
        {
            startcapture();
        }

        private void startcapture()
        {
            if (captureDevice is null)
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cmbDevices.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.VideoSourceError += videocaptureerror;
                captureDevice.Start();
                timer1.Start();
            }

        }

        private void cmb_changed(object sender, EventArgs e)
        {
            stopCapture();
            startcapture();

        }
    }
    public class QRCodeReadEventArgs
    {
        public string Data { get; set; }
    }
}