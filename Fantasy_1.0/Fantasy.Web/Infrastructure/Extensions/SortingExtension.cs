using Fantasy.Common;

namespace Fantasy.Web.Infrastructure.Extensions
{
    using static GlobalConstants;
    public static class SortingExtension
    {
        public static int SortByPosition(string position)
        {
            switch (position)
            {
                case Goalkeeper: return 1;
                case Defender: return 2;
                case Midfielder: return 3;
                case Forward: return 4;
            }

            return 0;
        }
    }
}
