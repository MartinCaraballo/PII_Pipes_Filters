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
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipeNull = new PipeNull();
            IFilter filterTwitter = new FilterTwitter();
            IPipe pipeTwitter = new PipeSerial(filterTwitter, pipeNull);

            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerial2 = new PipeSerial(filterNegative, pipeTwitter);

            IFilter filterSave = new FilterSave();
            IPipe pipeProceso = new PipeSerial(filterSave, pipeSerial2);

            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerial1 = new PipeSerial(filterGreyscale, pipeProceso);
            
            IPicture pictureFinal = pipeSerial1.Send(picture);

            provider.SavePicture(pictureFinal, @"BeerFinal.jpg");

           /*  IPicture pictureGrey = filtergreyscale.Filter(picture);
            IPicture pictureNegative = filternegative.Filter(pictureGrey);
            provider.SavePicture(pictureFinal, @"LukeFinal.jpg");
            provider.SavePicture(pictureGrey, @"LukeGreyScale.jpg");
            provider.SavePicture(pictureNegative, @"LukeNegative.jpg"); */

            

        }
    }
}
