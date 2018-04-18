using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Model
{
   public class newsName
    {
       public int id { get; set; }
        /// <summary>
        ///	新闻标题 
        /// </summary>
        public string headline { get; set; }
        /// <summary>
        ///	新闻类型 
        /// </summary>
        public string contenttext { get; set; }
        /// <summary>
        ///	用户ID 
        /// </summary>
        public int? userid { get; set; }
        /// <summary>
        ///	创建时间 
        /// </summary>
        public DateTime? creationtime { get; set; }
        /// <summary>
        ///	新闻类型 
        /// </summary>
        public int? newstype { get; set; }
        /// <summary>
        ///	类型名称
        /// </summary>
        public string newstypename { get; set; }
        /// <summary>
        ///	1可用，0不可用 
        /// </summary>
        public int? del { get; set; }
    }
}
