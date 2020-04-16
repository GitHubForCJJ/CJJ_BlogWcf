using Microsoft.International.Converters.PinYinConverter;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FastDev.Config
{
    /// <summary>
    /// 汉字转拼音
    /// </summary>
    public class PingYinHelper
    {
        /// <summary>
        /// 汉字转拼音
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static PingYinModel GetTotalPingYin(string str)
        {
            var chs = str.ToCharArray();
            //记录每个汉字的全拼
            Dictionary<int, List<string>> totalPingYins = new Dictionary<int, List<string>>();
            for (int i = 0; i < chs.Length; i++)
            {
                var pinyins = new List<string>();
                var ch = chs[i];
                //是否是有效的汉字
                if (ChineseChar.IsValidChar(ch))
                {
                    ChineseChar cc = new ChineseChar(ch);
                    pinyins = cc.Pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                }
                else
                {
                    pinyins.Add(ch.ToString());
                }

                //去除声调，转小写
                pinyins = pinyins.ConvertAll(p => Regex.Replace(p, @"\d", "").ToLower());
                //去重
                pinyins = pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList();
                if (pinyins.Any())
                {
                    totalPingYins[i] = pinyins;
                }
            }
            PingYinModel result = new PingYinModel();
            foreach (var pinyins in totalPingYins)
            {
                var items = pinyins.Value;
                if (result.TotalPingYin.Count <= 0)
                {
                    result.TotalPingYin = items;
                    result.FirstPingYin = items.ConvertAll(p => p.Substring(0, 1)).Distinct().ToList();
                }
                else
                {
                    //全拼循环匹配
                    var newTotalPingYins = new List<string>();
                    foreach (var totalPingYin in result.TotalPingYin)
                    {
                        newTotalPingYins.AddRange(items.Select(item => totalPingYin + item));
                    }
                    newTotalPingYins = newTotalPingYins.Distinct().ToList();
                    result.TotalPingYin = newTotalPingYins;

                    //首字母循环匹配
                    var newFirstPingYins = new List<string>();
                    foreach (var firstPingYin in result.FirstPingYin)
                    {
                        newFirstPingYins.AddRange(items.Select(item => firstPingYin + item.Substring(0, 1)));
                    }
                    newFirstPingYins = newFirstPingYins.Distinct().ToList();
                    result.FirstPingYin = newFirstPingYins;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据名字获取  姓和名的拼音 多音字随机取一个
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static PinyinView GetPyName(string str)
        {
            PinyinView pinyinView = new PinyinView();
            try
            {
                var chs = str.ToCharArray();
                //记录每个汉字的全拼
                Dictionary<int, List<string>> totalPingYins = new Dictionary<int, List<string>>();
                for (int i = 0; i < chs.Length; i++)
                {
                    var pinyins = new List<string>();
                    var ch = chs[i];
                    //是否是有效的汉字
                    if (ChineseChar.IsValidChar(ch))
                    {
                        ChineseChar cc = new ChineseChar(ch);
                        pinyins = cc.Pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                    }
                    else
                    {
                        pinyins.Add(ch.ToString());
                    }

                    //去除声调，转小写
                    pinyins = pinyins.ConvertAll(p => Regex.Replace(p, @"\d", "").ToLower());
                    //去重
                    pinyins = pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList();
                    if (pinyins.Any())
                    {
                        totalPingYins[i] = pinyins;
                    }
                }
                //默认首字母是姓，
                pinyinView.EnglishFirstName = totalPingYins[0]?.First()?.ToUpper();

                StringBuilder lastname = new StringBuilder();
                for (int i = 1; i < totalPingYins.Count; i++)
                {
                    lastname.Append($"{totalPingYins[i].First()?.ToUpper()}");
                }
                pinyinView.EnglishLastName = lastname.ToString();
            }
            catch
            {
                pinyinView = new PinyinView();
            }
            return pinyinView;
        }

    }
    /// <summary>
    /// PingYinModel
    /// </summary>
    public class PingYinModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PingYinModel"/> class.
        /// </summary>
        public PingYinModel()
        {
            TotalPingYin = new List<string>();
            FirstPingYin = new List<string>();
        }

        /// <summary>
        /// 全拼
        /// </summary>
        /// <value>
        /// The total ping yin.
        /// </value>
        public List<string> TotalPingYin { get; set; }


        /// <summary>
        ///首拼
        /// </summary>
        /// <value>
        /// The first ping yin.
        /// </value>
        public List<string> FirstPingYin { get; set; }
    }

    /// <summary>
    /// 姓名中文转拼音
    /// </summary>
    public class PinyinView
    {
        /// <summary>
        /// 姓 拼音
        /// </summary>
        public string EnglishFirstName { get; set; }
        /// <summary>
        /// 名 拼音
        /// </summary>
        public string EnglishLastName { get; set; }
    }
}
