﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            test_select_content_with_comment();
            Console.Read();
        }

        /// <summary>
        /// 查询单条指定的数据
        /// </summary>
        static void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"select * from [dbo].[content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_insert, new { id = 5 });
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }

        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        static void test_select_list()
        {
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<Content>(sql_insert, new { ids = new int[] { 6, 7 } });
                Console.WriteLine($"test_select_one：查到的数据为：");
            }
        }
        /// <summary>
        /// 测试删除单条数据
        /// </summary>
        static void test_del()
        {
            var content = new Content
            {
                id = 2,

            };
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        static void test_mult_del()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=3,

            },
               new Content
            {
                id=4,

            },
        };

            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_del：删除了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        static void test_update()
        {
            var content = new Content
            {
                id = 5,
                title = "标题5",
                content = "内容5",

            };
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量修改多条数据
        /// </summary>
        static void test_mult_update()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,
                title = "批量修改标题6",
                content = "批量修改内容6",

            },
               new Content
            {
                id =7,
                title = "批量修改标题7",
                content = "批量修改内容7",

            },
        };

            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_update：修改了{result}条数据！");
            }
        }


        static void Test_Add_Common()
        {
            List<Comment> contents = new List<Comment>() {
           new Comment()
        {
           content_id=2,
            content="哈哈哈"

            },    new Comment()
        {
           content_id=2,
            content="嘿嘿嘿"


        }

    };
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"INSERT INTO [Comment]
                ([content_id],content,add_time)
VALUES   (@content_id,@content,@add_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
            Console.Read();
        }

        static void Test_Add_Content(string[] args)
        {
            List<Content> contents = new List<Content>() {
           new Content()
            {
                title = "标题1",
                content = "内容1"

            },    new Content()
            {
                title = "标题2",
                content = "内容2"

            }

        };
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
            Console.Read();
        }
        static void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
            {
                string sql_insert = @"select * from content where id=@id;
select * from comment where content_id=@id;";
                using (var result = conn.QueryMultiple(sql_insert, new { id = 2 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    IEnumerable<Comment> comm= result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{comm}");
                }

            }
        }
    }
}
