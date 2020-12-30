using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Coop_Exam
{
    public class Animation
    {
        bool flag = false;
        bool stop = false;

        Image img;

        private BitmapImage bitMapImage;

        private DispatcherTimer animationClock = new DispatcherTimer();


        List<string> buffer = new List<string>();
        private int index = 0;
        public Animation(Image imageUI, List<string> imagesPath)
        {
            img = imageUI;
            buffer = imagesPath;
        }
        public Animation(Image imageUI)
        {
            img = imageUI;
        }

        public void start()
        {
            var imagePath = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + buffer[index]);

            img.Source = bitMapImage;
            img.InvalidateVisual();

            animationClock.Interval = new TimeSpan(0, 0, 0, 0, 100);
            animationClock.Tick += new EventHandler(Animate);
            animationClock.Start();
        }

        private void Animate(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (index < buffer.Count)
                {
                    bitMapImage = new BitmapImage();
                    var imagePath = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + buffer[index]);

                    bitMapImage.BeginInit();
                    bitMapImage.UriSource = imagePath;
                    bitMapImage.EndInit();

                    img.Source = bitMapImage;
                    img.InvalidateVisual();

                    index++;

                    if(stop)
                    {
                        stop = false;
                        return;
                    }
                }
                else
                {
                    bitMapImage = new BitmapImage();

                    index = 0;

                    var imagePath = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + buffer[index]);

                    bitMapImage.BeginInit();
                    bitMapImage.UriSource = imagePath;
                    bitMapImage.EndInit();
                    img.Source = bitMapImage;
                    img.InvalidateVisual();

                    index++;
                }
            }
            else
            {
                if (index < buffer.Count)
                {
                    bitMapImage = new BitmapImage();
                    var imagePath = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + buffer[index]);

                    bitMapImage.BeginInit();
                    bitMapImage.UriSource = imagePath;
                    bitMapImage.EndInit();

                    img.Source = bitMapImage;
                    img.InvalidateVisual();

                    index++;
                }
            }

        }
        public void SetImagesLibrary(List<string> Images, bool cycle)
        {
            buffer = Images;
            flag = cycle;
            index = 0;
        }

        public void Stop()
        {
            stop = true;
        }
    }
}
