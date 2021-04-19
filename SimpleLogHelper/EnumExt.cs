using System;
using System.ComponentModel;
using System.Linq;

namespace SimpleLogHelper
{
    internal static class EnumExt
    {
        /// <summary>
        /// 从枚举中获取Description
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <param name="enumName">需要获取枚举描述的枚举</param>
        /// <returns>描述内容</returns>
        public static string GetDescription(this Enum enumName)
        {
            var fieldInfo = enumName.GetType().GetField(enumName.ToString());
            var attributes = (DescriptionAttribute[]) fieldInfo?.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            var attribute = attributes?.FirstOrDefault();
            return attribute?.Description ?? enumName.ToString();
        }
    }
}
