using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLNY.ReadModels
{
    internal class ArticleList
    {
        public ArticleList()
        {
            Articles = new List<ArticleInfo>();
        }
        public List<ArticleInfo>? Articles { get; set; }
    }
}
