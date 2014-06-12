using System;

namespace vbsp
{
    public static class Extensions
    {
        /// <summary>Indexes the of NTH.</summary>
        /// <param name="str">The string.</param>
        /// <param name="value">The value.</param>
        /// <param name="nth">The NTH.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Can not find the zeroth index of substring in string. Must start with 1</exception>
        public static int IndexOfNth(this string str, string value, int nth = 1)
        {
            if (nth < 0)
                throw new ArgumentException("Can not find the zeroth index of substring in string. Must start with 1");
            int offset = str.IndexOf(value);
            for (int i = 1; i < nth; i++)
                if (offset == -1) return -1;
                else offset = str.IndexOf(value, offset + 1);
            return offset;
        }
    }
}
