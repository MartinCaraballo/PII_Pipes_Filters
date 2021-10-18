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

            provider.SavePicture(picture, @"LukeFinal.jpg");

        }
    }
}
