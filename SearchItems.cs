using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace GithubSearch
{
    class SearchItems
    {
        [CategoryAttribute("高级选项"), DescriptionAttribute("所有者")]
        public string users { get; set; }

        [CategoryAttribute("高级选项"), DescriptionAttribute("仓库")]
        public string repositories { get; set; }

        [CategoryAttribute("高级选项"), DescriptionAttribute("创建日期")]
        public DateTime dates { get; set; }

        [CategoryAttribute("高级选项"), DescriptionAttribute("语言"),DefaultValue("c")]
        public string language { get; set; }

        [CategoryAttribute("仓库选项"), DescriptionAttribute("星级")]
        public string stars { get; set; }

        [CategoryAttribute("仓库选项"), DescriptionAttribute("分支")]
        public string forks { get; set; }

        [CategoryAttribute("仓库选项"), DescriptionAttribute("大小")]
        public UInt64 size { get; set; }

        [CategoryAttribute("仓库选项"), DescriptionAttribute("升级")]
        public DateTime pushed { get; set; }

        [CategoryAttribute("仓库选项"), DescriptionAttribute("包含分支")]
        public bool including_fork { get; set; }

        [CategoryAttribute("代码选项"), DescriptionAttribute("扩展名"), DefaultValue("c,cpp")]
        public string extensions { get; set; }

        [CategoryAttribute("代码选项"), DescriptionAttribute("文件大小")]
        public UInt64 file_size { get; set; }

        [CategoryAttribute("代码选项"), DescriptionAttribute("文件路径")]
        public string path { get; set; }

        [CategoryAttribute("代码选项"), DescriptionAttribute("包含关键词"), DefaultValue("uefi")]
        public string include_keywords { get; set; }

        [CategoryAttribute("代码选项"), DescriptionAttribute("排除关键词")]
        public string exclude_keywords { get; set; }
        
    }
}
