using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        public bool hasFace { get; set; }
        public IPicture Filter(IPicture imagen)
        {
            CognitiveFace cognitive = new CognitiveFace();
            cognitive.Recognize(@"luke.jpg");
            if(cognitive.FaceFound == true)
            {
                hasFace = true; 
                IFilter twitterFilter = new FilterTwitter();
                twitterFilter.Filter(imagen);
            }
            else 
            {
                hasFace = false;
                IFilter filterNegative = new FilterNegative();
                filterNegative.Filter(imagen);
            }
            return imagen;
        }
    }
}