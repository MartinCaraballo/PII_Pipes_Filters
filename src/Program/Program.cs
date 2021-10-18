using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"Luke.jpg");

            IPipe pipenull = new PipeNull();
            IFilter filternegative = new FilterNegative();
            IPipe pipeserial2 = new PipeSerial(filternegative, pipenull);
            IFilter filtergreyscale = new FilterGreyscale();
            IPipe pipeserial1 = new PipeSerial(filtergreyscale, pipeserial2);
            
            IPicture pictureFinal = pipeserial1.Send(picture);
            IPicture pictureGrey = filtergreyscale.Filter(picture);
            IPicture pictureNegative = filternegative.Filter(pictureGrey);
            provider.SavePicture(pictureFinal, @"LukeFinal.jpg");
            provider.SavePicture(pictureGrey, @"LukeGreyScale.jpg");
            provider.SavePicture(pictureNegative, @"LukeNegative.jpg");

            

        }
    }
}
