using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// author yanhf
    /// K-Means
    /// </summary>
    public class K_Means
    {
        /// <summary>
        /// Update index cluster identification based on cluster point key
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="index">index</param>
        /// <param name="key">key values</param>
        public static void _K_Means(double[] data, ref int[] index, int[] key)
        {
            bool change = true;
            int _index = 0;
            double Length = 0;
            while (change)
            {
                change = false;
                for (int i = 0; i < data.Length; i++)//根据当前的聚簇点更新index聚簇标识数组
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        double currentLength = Math.Abs(data[key[j]] - data[i]);
                        if (j == 0 || Length > currentLength)
                        {
                            Length = Math.Abs(data[key[j]] - data[i]);
                            _index = j + 1;
                        }
                    }
                    index[i] = _index;
                    Length = 0;
                }
                change = _ChangeKey(data, index, ref key);
            }
        }
        /// <summary>
        /// Judging the current Key needs not to be changed
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="index">index</param>
        /// <param name="key">key values</param>
        /// <returns></returns>
        public static bool _ChangeKey(double[] data, int[] index, ref int[] key)
        {
            bool IsChange = false;
            int i = 0;
            List<double> _listData = new List<double>();
            while (i++ < key.Length)
            {
                _listData.Clear();
                for (int j = 0; j < index.Length; j++)
                {
                    if (index[j] == i)
                    {
                        _listData.Add(data[j]);
                    }
                }
                _listData.Sort();
                if (_listData.Count > 1)
                {
                    if (key[i - 1] != _index(data, _listData[_listData.Count / 2]))
                    {
                        IsChange = true;
                        key[i - 1] = _index(data, _listData[_listData.Count / 2]);
                    }
                }
            }
            return IsChange;
        }
        /// <summary>
        /// Get the index in the key's data
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="num">key values</param>
        /// <returns></returns>
        public static int _index(double[] data, double num)
        {
            List<double> _listData = new List<double>(data);
            return _listData.IndexOf(num) >= 0 ? _listData.IndexOf(num) : -1;
        }
    }
}
