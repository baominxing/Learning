using System;
using System.Collections.Generic;

namespace Common
{
    public class ArrayGenerator
    {
        private static DateTime currentDateTime = DateTime.Now;

        /// <summary>
        /// 产生一个int类型的数组，数量是传入的numberCount定，最大值，最小值默认为100和0，也可以按照输入的值作为最大和最小值
        /// </summary>
        /// <param name="numberCount"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<int> GetRandomNumberList(int numberCount, int min = 0, int max = 100)
        {
            var result = new List<int>();

            var random = new Random(currentDateTime.Second);

            for (int i = 0; i < numberCount; i++)
            {
                result.Add(random.Next(min, max));
            }

            return result;
        }
    }
}
