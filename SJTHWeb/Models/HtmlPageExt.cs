using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlPageExt
    {
        public static HtmlString ShowPageNavigate(int currentPage, int pageSize, int totalCount)
        {
            
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = totalCount;  //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                 
                output.AppendFormat("<a class='pageLink' href='#' onclick='{0}'>首页</a> ", "gotoPage(1);");
                
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink'  href='#'onclick='{0}' >上一页</a> ", "gotoPage(" + (currentPage - 1).ToString() + ");");
                }
                else
                {
                    
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            
                            output.AppendFormat("<a class='cpb' href='#' onclick='{0}'>{1}</a> ", "gotoPage(" + currentPage + ");", currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='#' onclick='{0}'>{1}</a> ", "gotoPage(" + (currentPage + i - currint).ToString() + ");", currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink'  href='#' onclick='{0}'>下一页</a> ", "gotoPage(" + (currentPage + 1).ToString() + ");");
                }
                else
                {
                    
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='#' onclick='{0}'>末页</a> ", "gotoPage(" + totalPages + ");");
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }
    }
}