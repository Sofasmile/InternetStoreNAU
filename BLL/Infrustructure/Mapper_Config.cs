using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;


namespace BLL
{
    public class Mapper_Config
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DB_Category, Category>();
                cfg.CreateMap<DB_Product,Product>();
                cfg.CreateMap<DB_User, User>();
            });
        }
    }
}
