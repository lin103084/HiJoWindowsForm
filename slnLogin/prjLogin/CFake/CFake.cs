using prjLogin.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLogin.Class
{
    internal class CFake
    {
        public void Main()
        {
            // 資料夾路徑
            string imageFolderPath = @"C:\Picture2\";

            // 取得所有圖片檔案（假設所有圖片檔案是 .jpg 格式）
            string[] imageFiles = Directory.GetFiles(imageFolderPath, "*.png");

            // 隨機選擇一張圖片
            Random random = new Random();
            string randomImagePath = imageFiles[random.Next(imageFiles.Length)];

            // 讀取隨機圖片並轉換為 byte[]
            byte[] imageBytes = File.ReadAllBytes(randomImagePath);

            // 更新所有會員的頭貼
            UpdateMemberAvatars(imageBytes);
        }
    

        public void UpdateMemberAvatars(byte[] imageBytes)
        {
            // 連接資料庫的 SQL 語句
            string query = "UPDATE members SET avatar = @avatar";

            using (SqlConnection conn = new SqlConnection(Settings.Default.HomePCR7FriendshipConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@avatar", imageBytes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("All member avatars updated with a random image.");
        }
    }
}
