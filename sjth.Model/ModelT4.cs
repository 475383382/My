 

using System;
namespace sjth.Model
{
    

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class lunbo:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public lunbo()
	{
       imgurl = string.Empty ;
         del = 0 ;
         datatimes = DateTime.Now ;
         name = string.Empty ;
         htmlurl = string.Empty ;
         type = 0 ;
     	}

        /// <summary>
		///	图片路径 
		/// </summary>
		public string imgurl { get; set; }
	        /// <summary>
		///	1可用 ，0 不可用 
		/// </summary>
		public int? del { get; set; }
	        /// <summary>
		///	时间 
		/// </summary>
		public DateTime? datatimes { get; set; }
	        /// <summary>
		///	名字 
		/// </summary>
		public string name { get; set; }
	        /// <summary>
		///	网页链接 
		/// </summary>
		public string htmlurl { get; set; }
	        /// <summary>
		///	1电脑 2 轮播 
		/// </summary>
		public int? type { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class manager:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public manager()
	{
       username = string.Empty ;
         userpwassord = string.Empty ;
         realname = string.Empty ;
         phone = string.Empty ;
         creationtime = DateTime.Now ;
     	}

        /// <summary>
		///	 
		/// </summary>
		public string username { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public string userpwassord { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public string realname { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public string phone { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public DateTime? creationtime { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class newst:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public newst()
	{
       headline = string.Empty ;
         contenttext = string.Empty ;
         userid = 0 ;
         creationtime = DateTime.Now ;
         newstype = 0 ;
         del = 0 ;
         type = 0 ;
     	}

        /// <summary>
		///	新闻标题 
		/// </summary>
		public string headline { get; set; }
	        /// <summary>
		///	新闻内容 
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
		///	1可用，0不可用 
		/// </summary>
		public int? del { get; set; }
	        /// <summary>
		///	1公司咨询，2学院 
		/// </summary>
		public int? type { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class newstype:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public newstype()
	{
       typename = string.Empty ;
         datatimes = DateTime.Now ;
         del = 0 ;
         PPID = 0 ;
     	}

        /// <summary>
		///	类型名称 
		/// </summary>
		public string typename { get; set; }
	        /// <summary>
		///	创建时间 
		/// </summary>
		public DateTime? datatimes { get; set; }
	        /// <summary>
		///	可用状态1可用，0不可用 
		/// </summary>
		public int? del { get; set; }
	        /// <summary>
		///	父ID 
		/// </summary>
		public int? PPID { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class product:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public product()
	{
            
       productName = string.Empty ;
         productIntro = string.Empty ;
         productConstituent = string.Empty ;
         productUsage = string.Empty ;
         productNotes = string.Empty ;
         productImage = string.Empty ;
         datatimes = DateTime.Now ;
         productUrl = string.Empty ;
         del = 0 ;
     	}
        
        /// <summary>
		///	产品名称 
		/// </summary>
		public string productName { get; set; }
	        /// <summary>
		///	产品介绍 
		/// </summary>
		public string productIntro { get; set; }
	        /// <summary>
		///	产品成分 
		/// </summary>
		public string productConstituent { get; set; }
	        /// <summary>
		///	使用方法 
		/// </summary>
		public string productUsage { get; set; }
	        /// <summary>
		///	注意事项 
		/// </summary>
		public string productNotes { get; set; }
	        /// <summary>
		///	产品图片 
		/// </summary>
		public string productImage { get; set; }
	        /// <summary>
		///	创建时间 
		/// </summary>
		public DateTime? datatimes { get; set; }
	        /// <summary>
		///	产品视频 
		/// </summary>
		public string productUrl { get; set; }
	        /// <summary>
		///	可用状态 1可以 0 不用  
		/// </summary>
		public int? del { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class Salest:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public Salest()
	{
       name = string.Empty ;
         img = string.Empty ;
         yue = 0 ;
         jidu = 0 ;
         nian = 0 ;
         del = 0 ;
         datatimes = DateTime.Now ;
     	}

        /// <summary>
		///	员工名称 
		/// </summary>
		public string name { get; set; }
	        /// <summary>
		///	头像 
		/// </summary>
		public string img { get; set; }
	        /// <summary>
		///	月销售 
		/// </summary>
		public int? yue { get; set; }
	        /// <summary>
		///	季度销售 
		/// </summary>
		public int? jidu { get; set; }
	        /// <summary>
		///	年销售  
		/// </summary>
		public int? nian { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public int? del { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public DateTime? datatimes { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class video:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public video()
	{
       name = string.Empty ;
         url = string.Empty ;
         del = 0 ;
         datatimes = DateTime.Now ;
     	}

        /// <summary>
		///	视频名称 
		/// </summary>
		public string name { get; set; }
	        /// <summary>
		///	视频连接 
		/// </summary>
		public string url { get; set; }
	        /// <summary>
		///	1可用0不可用 
		/// </summary>
		public int? del { get; set; }
	        /// <summary>
		///	时间 
		/// </summary>
		public DateTime? datatimes { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class apply:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public apply()
	{
       phone = string.Empty ;
         weixinName = string.Empty ;
         site = string.Empty ;
         creationtime = DateTime.Now ;
         del = 0 ;
         name = string.Empty ;
     	}

        /// <summary>
		///	手机号 
		/// </summary>
		public string phone { get; set; }
	        /// <summary>
		///	微信号 
		/// </summary>
		public string weixinName { get; set; }
	        /// <summary>
		///	地址 
		/// </summary>
		public string site { get; set; }
	        /// <summary>
		///	创建时间 
		/// </summary>
		public DateTime creationtime { get; set; }
	        /// <summary>
		///	0可用，1删除 
		/// </summary>
		public int del { get; set; }
	        /// <summary>
		///	 
		/// </summary>
		public string name { get; set; }
	    }

	/// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class Authority:BaseEntity
    {
	/// <summary>
	///	构造函数
	/// </summary>
	public Authority()
	{
       authorityName = string.Empty ;
         authoritytTop = string.Empty ;
         authorityUrl = string.Empty ;
         datatimes = DateTime.Now ;
         del = 0 ;
     	}

        /// <summary>
		///	认证名称 
		/// </summary>
		public string authorityName { get; set; }
	        /// <summary>
		///	展示图 
		/// </summary>
		public string authoritytTop { get; set; }
	        /// <summary>
		///	图片详情 
		/// </summary>
		public string authorityUrl { get; set; }
	        /// <summary>
		///	创建时间 
		/// </summary>
		public DateTime? datatimes { get; set; }
	        /// <summary>
		///	1可用，0不可用 
		/// </summary>
		public int? del { get; set; }
	    }
}
