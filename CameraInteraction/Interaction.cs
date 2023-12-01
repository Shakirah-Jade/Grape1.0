using System;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Diagnostics;

namespace CameraInteraction
{
    public class Interaction
    {
        private VideoCaptureDevice videoSource;

        //creating a folder to keep the images taken
        static string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        private string imageFilePath = $"HADIE/captured_image_{timestamp}.jpg";
        public void StartCamera()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                Console.WriteLine("No video devices found.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();

            Console.WriteLine("Press Enter to capture an image...");
            Console.ReadLine();
            Console.WriteLine("Image captured and saved to: " + imageFilePath);

            videoSource.SignalToStop();
            videoSource.WaitForStop();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Handle new frame from the camera
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            // Save the bitmap to a file
            bitmap.Save(imageFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void OpenCapturedImage()
        {
            // Open the captured image using the default image viewer
            Process.Start(imageFilePath);
        }

    }
}


/*using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.Diagnostics;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CameraInteraction
{
    public class Interaction
    {
        private VideoCaptureDevice videoSource;

        public void StartCamera()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                Console.WriteLine("No video devices found.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();

            Console.WriteLine("Press Enter to capture an image...");
            Console.ReadLine();

            // Perform food analysis
            AnalyzeFood();

            videoSource.SignalToStop();
            videoSource.WaitForStop();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Handle new frame from the camera
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            // Process the frame or save it to a file if needed
            // ...
        }

        private void AnalyzeFood()
        {
            // Load the captured image using Emgu.CV
            using (var image = new Mat("path_to_captured_image.jpg"))
            {
                // Load YOLO model and configuration
                using (var net = CvDnn.ReadNetFromDarknet("path_to_yolov3.cfg", "path_to_yolov3.weights"))
                {
                    // Load COCO class names
                    var classNames = File.ReadAllLines("path_to_coco.names");

                    // Prepare the image for analysis
                    CvInvoke.Resize(image, image, new Size(416, 416));
                    CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Rgb);

                    // Normalize the image
                    image.ConvertTo(image, DepthType.Cv32F, 1.0 / 255.0);

                    // Set the input for the YOLO model
                    net.SetInput(image);

                    // Forward pass to get the output
                    var detections = net.Forward();

                    // Process the detection results
                    ProcessDetections(detections, classNames);

                    // Display the captured image with detections
                    CvInvoke.Imshow("Food Analysis", image);
                    CvInvoke.WaitKey(0);
                }
            }
        }

        private void ProcessDetections(Mat detections, string[] classNames)
        {
            float[,] data = detections.GetData<float>();

            for (int i = 0; i < data.GetLength(0); i++)
            {
                float confidence = data[i, 2];

                if (confidence > 0.5) // Consider only detections with confidence greater than 0.5
                {
                    int classId = (int)data[i, 1];
                    float[] scores = data.GetRow(i).Skip(5).ToArray();
                    float maxScore = scores.Max();

                    if (maxScore > 0.5) // Consider only classes with score greater than 0.5
                    {
                        // Get the label and draw a rectangle around the detected object
                        string label = $"{classNames[classId]}: {maxScore * 100}%";
                        Rectangle rect = new Rectangle(
                            (int)data[i, 3],
                            (int)data[i, 4],
                            (int)data[i, 5] - (int)data[i, 3],
                            (int)data[i, 6] - (int)data[i, 4]
                        );

                        CvInvoke.Rectangle(image, rect, new MCvScalar(0, 255, 0), 2);
                        CvInvoke.PutText(image, label, new Point(rect.X, rect.Y - 5), FontFace.HersheyComplex, 0.5, new MCvScalar(0, 255, 0), 2);
                    }
                }
            }
        }
    }
}*/