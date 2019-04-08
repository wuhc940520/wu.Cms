/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：wuhc                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-04-08 14:08:50                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Cms.Models                                  
*│　类    名：NLog                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Models
{
	/// <summary>
	/// wuhc
	/// 2019-04-08 14:08:50
	/// 
	/// </summary>
	[Table("NLog")]
	public class NLog
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Application {get;set;}

		/// <summary>
		///  
		/// </summary>
		public DateTime? Logged {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Level {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Message {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Logger {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Callsite {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Exception {get;set;}


	}
}
