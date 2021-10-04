using System.Collections.Generic;
using DataLayer.Entities.Category;
using DataLayer.Entities.Logo;
using DataLayer.Entities.SocialNetwork;
namespace hampadco.Models
{
    public static class menu
    {
        public static List<Tbl_Category> cat = new List<Tbl_Category>();
        public static int  resiver,sender,total_user,new_order,new_comment,idrezerv=0;
        public static string logo,Title,img,favicon,enemad;
        public static string Tel,Insta,Face,Whts,Twit,site;
        public static string Richat,zarincode,phone;
        public static string FullTextBlo;
        
        public static int order_count;
        public static List<int> shop = new List<int>();
        public static List<string> find { get; set; }
        // public static string social ,Instagram ;
    }
}