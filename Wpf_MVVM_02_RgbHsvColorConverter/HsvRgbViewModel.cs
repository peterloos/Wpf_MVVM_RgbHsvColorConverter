using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Wpf_MVVM_02_RgbHsvColorConverter
{
    class HsvRgbViewModel : INotifyPropertyChanged
    {
        private int red;         // 0 .. 255
        private int green;       // 0 .. 255
        private int blue;        // 0 .. 255

        private int hue;         // 0 .. 360
        private int saturation;  // 0 .. 100
        private int value;       // 0 .. 100

        private Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        public HsvRgbViewModel()
        {
            this.Color = Colors.Black;
        }

        // public properties
        public int Hue
        {
            set
            {
                if (this.hue != value)
                {
                    Console.WriteLine("   ... new hue {0}", value);
                    this.hue = value;
                    this.OnPropertyChanged("Hue");
                    this.UpdateRgbFromHsv();
                    this.UpdateColor();
                }
            }
            get
            {
                return hue;
            }
        }

        public int Saturation
        {
            set
            {
                if (this.saturation != value)
                {
                    Console.WriteLine("   ... new saturation {0}", value);
                    this.saturation = value;
                    this.OnPropertyChanged("Saturation");
                    this.UpdateRgbFromHsv();
                    this.UpdateColor();
                }
            }
            get
            {
                return saturation;
            }
        }

        public int Value
        {
            set
            {
                if (this.value != value)
                {
                    Console.WriteLine("   ... new value {0}", value);
                    this.value = value;
                    this.OnPropertyChanged("Value");
                    this.UpdateRgbFromHsv();
                    this.UpdateColor();
                }
            }
            get
            {
                return value;
            }
        }

        public int Red
        {
            set
            {
                if (this.red != value)
                {
                    Console.WriteLine("   ... new red {0}", value);
                    this.red = value;
                    this.OnPropertyChanged("Red");
                    this.UpdateHsvFromRgb();
                    this.UpdateColor();
                }
            }
            get
            {
                return this.red;
            }
        }

        public int Green
        {
            set
            {
                if (this.green != value)
                {
                    Console.WriteLine("   ... new green {0}", value);

                    this.green = value;
                    this.OnPropertyChanged("Green");
                    this.UpdateHsvFromRgb();
                    this.UpdateColor();
                }
            }
            get
            {
                return this.green;
            }
        }

        public int Blue
        {
            set
            {
                if (this.blue != value)
                {
                    Console.WriteLine("   ... new blue {0}", value);

                    this.blue = value;
                    this.OnPropertyChanged("Blue");
                    this.UpdateHsvFromRgb();
                    this.UpdateColor();
                }
            }
            get
            {
                return this.blue;
            }
        }

        public Color Color
        {
            set
            {
                if (this.color != value)
                {
                    Console.WriteLine("   ... new color {0}", value.ToString());
                    this.color = value;
                    this.OnPropertyChanged("Color");
                }
            }

            get
            {
                return color;
            }
        }

        // private helper methods
        private void UpdateColor()
        {
            this.Color = Color.FromRgb((byte)this.red, (byte)this.green, (byte)this.blue);
        }

        private void UpdateHsvFromRgb()
        {
            Rgb rgb = new Rgb() { R = this.red, G = this.green, B = this.blue };
            Hsv hsv = rgb.To<Hsv>();

            if (this.hue != (int)hsv.H)
            {
                this.hue = (int)hsv.H;
                this.OnPropertyChanged("Hue");
            }

            if (this.saturation != (int)(100.0 * hsv.S))
            {
                this.saturation = (int)(100.0 * hsv.S);
                this.OnPropertyChanged("Saturation");
            }

            if (this.value != (int)(100.0 * hsv.V))
            {
                this.value = (int)(100.0 * hsv.V);
                this.OnPropertyChanged("Value");
            }
        }

        private void UpdateRgbFromHsv()
        {
            Hsv hsv = new Hsv() { H = this.hue, S = this.saturation / 100.0, V = this.value / 100.0 };
            Rgb rgb = hsv.To<Rgb>();

            if (this.red != (int)rgb.R)
            {
                this.red = (int)rgb.R;
                this.OnPropertyChanged("Red");
            }

            if (this.green != (int)rgb.G)
            {
                this.green = (int)rgb.G;
                this.OnPropertyChanged("Green");
            }

            if (this.blue != (int)rgb.B)
            {
                this.blue = (int)rgb.B;
                this.OnPropertyChanged("Blue");
            }
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
