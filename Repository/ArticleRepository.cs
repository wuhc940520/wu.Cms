/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章接口实现                                                    
*│　作    者：wuhc                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-08 14:08:50                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间：                                   
*│　类    名： ArticleRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Core.DbHelper;
using Czar.Cms.Core.Options;
using Czar.Cms.Core.Repository;
using Czar.Cms.IRepository;
using Czar.Cms.Models;
using Microsoft.Extensions.Options;
using System;

namespace 
{
    public class ArticleRepository:BaseRepository<Article,Int32>, IArticleRepository
    {
        public ArticleRepository(IOptionsSnapshot<DbOpion> options)
        {
            _dbOpion =options.Get("CzarCms");
            if (_dbOpion == null)
            {
                throw new ArgumentNullException(nameof(DbOpion));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOpion.DbType, _dbOpion.ConnectionString);
        }

    }
}