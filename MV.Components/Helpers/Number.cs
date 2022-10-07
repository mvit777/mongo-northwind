using Microsoft.Fast.Components.FluentUI;

namespace MV.Components.Helpers
{
    public static class Number
    {
        /// <summary>
        /// 1-10 = Number.GetIntegerRange(1,10);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int[] GetIntegerArray(int start, int end)
        {
            int[] rg = Enumerable.Range(start, end).ToArray();
            return rg;
        }
        public static List<Option<int>> GetIntegerOptions(int start, int end)
        {
            var items = Enumerable.Range(start, end);
            var options = new List<Option<int>>();
            foreach (var item in items)
            {
                var option = new Option<int>() { Key = item, Value = item};
                options.Add(option);
            }
            return options;     
        }
      
    }
}
