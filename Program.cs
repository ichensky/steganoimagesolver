using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
      
       
        static int GetBit(byte b, int bitNumber)
        {
            return( (b & (1 << bitNumber)) != 0) ?1:0;
        }

        static void Main(string[] args)
        {
            var path = @"C:\Users\john\Desktop\test1";

            using (var image = new MagickImage($@"{path}/E90q8lGw2T1Ym7lI.png"))
            {
                var pixels = image.GetPixels();
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        var p = pixels.GetPixel(i, j);
                        var c=p.ToColor();

                        var r= (byte)Convert.ToInt32($"{GetBit(c.R, 1)}{GetBit(c.R, 0)}000000", 2);
                        var g= (byte)Convert.ToInt32($"{GetBit(c.G, 1)}{GetBit(c.G, 0)}000000", 2);
                        var b= (byte)Convert.ToInt32($"{GetBit(c.B, 1)}{GetBit(c.B, 0)}000000", 2);
                        p.SetChannel(0, r);
                        p.SetChannel(1, g);
                        p.SetChannel(2, b);
                        
                    }
                }
                image.Write($@"{path}/result.png");
                return;

            }
        }
    }
}
