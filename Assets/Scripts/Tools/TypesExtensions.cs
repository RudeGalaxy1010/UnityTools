using System;

namespace RGLX_Extensions
{
    public static class TypesExtensions
    {
        [Serializable]
        public class IntVector2
        {
            public IntVector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public IntVector2()
            {
                x = 0;
                y = 0;
            }

            public int x;
            public int y;
        }
    }
}
