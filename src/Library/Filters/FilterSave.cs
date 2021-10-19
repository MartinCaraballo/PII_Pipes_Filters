
namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la gaurda.
    /// </summary>
    public class FilterSave : IFilter
    {
        public IPicture Filter(IPicture imagen)
        {
            PictureProvider provider2 = new PictureProvider(); 
            provider2.SavePicture(imagen, @"Proceso.jpg");
            return imagen;
        }
    }
}