using TwitterUCU;
namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture imagen)
        {
            var picture = new TwitterImage();
            picture.PublishToTwitter("Final", @"BeerFinal.jpg");
            return imagen;
        }
    }
}