/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员接口实现                                                    
*│　作    者：wuhc                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-08 14:08:50                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间：                                   
*│　类    名： ManagerRepository                                      
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
    public class ManagerRepository:BaseRepository<Manager,Int32>, IManagerRepository
    {
        public ManagerRepository(IOptionsSnapshot<DbOpion> options)
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