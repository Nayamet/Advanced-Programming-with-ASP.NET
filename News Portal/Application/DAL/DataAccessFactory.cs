using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DataAccessFactory
    {
        static NPSEntities db;
        static DataAccessFactory()
        {
            db = new NPSEntities();
        }
        public static IRepository<News, int> NewsDataAccess()
        {
            return new NewsRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(db);
        }

        public static IRepository<React, int> ReactDataAccess()
        {
            return new ReactRepo(db);
        }
    }
}