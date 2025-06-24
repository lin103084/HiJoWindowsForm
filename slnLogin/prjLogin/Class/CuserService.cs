using prjLogin.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace prjLogin.Class
{
    internal class CuserService
    {
        private string _connectionString = Settings.Default.PCR7FriendshipConnectionString;

        // 產生驗證碼
        public string createRandomVerificationCode()
        {
            Random rand = new Random();
            int code = rand.Next(1000, 9999); // 產生 4 位數驗證碼
            return code.ToString();
        }
        //產生隨機密碼
        public string createRandomPassWord()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // 產生BCrypt加密
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Check email  並使用email + 驗證加密密碼
        public bool checkUser(string accountEmail, string passWord)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                        SELECT 
                                      *  
                        FROM 
                                    members  
                        WHERE 
                                     email = @accountEmail;";
                        cmd.Parameters.AddWithValue("@accountEmail", accountEmail);
                        SqlDataReader reader = cmd.ExecuteReader();

                        //BCrypt 比對密碼
                        if (reader.Read())
                        {
                            string storedHash = reader["passWordHash"].ToString();
                            return BCrypt.Net.BCrypt.Verify(passWord, storedHash);
                        }
                    }
                    return false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
                return false;
            }
        }

        // Use email check
        public bool checkEmail(string accountEmail)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                        SELECT 
                                    * 
                        FROM 
                                    members 
                        WHERE 
                                    email = @accountEmail;";

                        cmd.Parameters.AddWithValue("@accountEmail", accountEmail);
                        SqlDataReader reader = cmd.ExecuteReader();

                        return reader.HasRows;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
                return false;
            }
        }

        //Update PassWord
        public bool updateUserPassWord(string accountEmail, string newPassWord)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                        UPDATE 
                                        members 
                        SET 
                                       passWordHash = @passWordHash 
                        WHERE 
                                       email = @accountEmail;";

                        string hashedPassword = HashPassword(newPassWord); // Bcrypt 加密密碼

                        cmd.Parameters.AddWithValue("@accountEmail", accountEmail);
                        cmd.Parameters.AddWithValue("@passWordHash", hashedPassword);

                        int resultCount = cmd.ExecuteNonQuery(); // 執行 SQL 語句，返回影響的行數

                        if (resultCount > 0)
                        {
                            MessageBox.Show("密碼更新成功！");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("無法更新密碼，請檢查帳號是否存在。");
                            return false;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
                return false;
            }
        }

        //CreateAccount
        public bool createUser(string accountEmail, string passWord, string passWordSalt, string userName, string sex, string birthday, int cityID, int districtID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string hashedPassword = HashPassword(passWord);
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                                INSERT INTO members (email, passWordHash, passWordSalt, userName, sex, birthday, cityID, districtID)
                                VALUES (@accountEmail, @passWordHash,@passWordSalt, @userName, @sex, @birthday,  @cityID, @districtID)";


                        cmd.Parameters.AddWithValue("@accountEmail", accountEmail);
                        cmd.Parameters.AddWithValue("@passWordHash", hashedPassword);
                        cmd.Parameters.AddWithValue("@passWordSalt", passWordSalt);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        cmd.Parameters.AddWithValue("@cityID", cityID);
                        cmd.Parameters.AddWithValue("@districtID", districtID);

                        int resultcount = cmd.ExecuteNonQuery();

                        if (resultcount > 0)
                        {
                            return true;
                        }
                    }
                    return false;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
                return false;
            }
        }

        //add memberRole
        public bool addMemberRole(string useremail, int roleID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandText = @"
                        INSERT INTO 
                                                 memberRoles (memberID, roleID)
                        SELECT 
                                    ID, 
                                    @roleID 
                        FROM 
                                    members 
                        WHERE 
                                    email = @useremail";


                        cmd.Parameters.AddWithValue("@useremail", useremail);
                        cmd.Parameters.AddWithValue("@roleID", roleID);


                        int resultcount = cmd.ExecuteNonQuery();

                        if (resultcount > 0)
                        {
                            return true;
                        }
                    }
                    return false;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
                return false;
            }
        }

        //Get User
        public string getUser(string accountEmail)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                    SELECT 
                                userName
                    FROM 
                                members 
                    WHERE 
                                email = @accountEmail;";

                        cmd.Parameters.AddWithValue("@accountEmail", accountEmail);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // 需要先 Read()
                            {
                                return reader["userName"].ToString(); // 正確的 column 名稱
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            return null; // 保證所有路徑都有回傳值


        }
    }
}
