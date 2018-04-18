using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Model
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
    }
}
