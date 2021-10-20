namespace CompAndDel.Filters
{
    public class FilterBlurIdentity : FilterBlurConvolution
    {
        public FilterBlurIdentity()
        {
            this.kernel = new int[3,3];
            this.complement = 1;
            this.divider = 16;
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++ )
                {
                    kernel[x, y] = 2;
                }
            }
        }
    }
}