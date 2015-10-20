using System.Data;
using System.IO;
using SecondHand.DAL;

namespace ThemeChange.Extension
{
    public static class ThemeStatic
    {

        public static string Theme;

        public static void Getthemename(int userid)
        {
            string sql = @"select UUU  from Users where  userid=" + userid;

            DataSet ds = DBHelper.GetDS(sql);

            Theme = ds.Tables[0].Rows[0]["UUU"].ToString();
            //Directory.GetFiles(path2, type, SearchOption.TopDirectoryOnly);
        }



        public static string GetHerf(string path, string type)
        {
            string[] files = Directory.GetFiles(path, type, SearchOption.TopDirectoryOnly);

            return files[0];
        }
    }
}