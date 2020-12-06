using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
    static class DataClass
    {
        static SqlConnection conn = new SqlConnection("server=.;database=Snake;Integrated Security=true");
        static SqlCommand comm = new SqlCommand();
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="name">昵称</param>
        /// <returns>插入成功返回1</returns>
        public static int InsertUser(string name)
        {
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "insert into UserScore values(@name,0,0,0)";
            comm.Parameters.AddWithValue("@name", name);
            conn.Open();
            int i = comm.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="name">昵称</param>
        /// <returns>返回该昵称个数</returns>
        public static int SelectUser(string name)
        {
            try
            {
                comm.Parameters.Clear();
                comm.Connection = conn;
                comm.CommandText = "select count(1) from UserScore where UserName=@name";
                comm.Parameters.AddWithValue("@name", name);
                conn.Open();
                int i = (int)comm.ExecuteScalar();
                conn.Close();
                return i;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 修改简单难度成绩
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="score">成绩</param>
        private static int UpUserSimpleScore(string name, int score)
        {
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "update UserScore set SimpleScore=@score where UserName=@name";
            comm.Parameters.AddWithValue("@score", score);
            comm.Parameters.AddWithValue("@name", name);
            conn.Open();
            int i = comm.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// 修改普通难度成绩
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="score">成绩</param>
        private static int UpUserCommonScore(string name, int score)
        {
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "update UserScore set CommonScore=@score where UserName=@name";
            comm.Parameters.AddWithValue("@score", score);
            comm.Parameters.AddWithValue("@name", name);
            conn.Open();
            int i = comm.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// 修改困难难度成绩
        /// </summary>
        /// <param name="name">昵称</param>
        /// <param name="score">成绩</param>
        private static int UpUserBumpScore(string name, int score)
        {
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "update UserScore set BumpScore=@score where UserName=@name";
            comm.Parameters.AddWithValue("@score", score);
            comm.Parameters.AddWithValue("@name", name);
            conn.Open();
            int i = comm.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// 查询简单的成绩排名
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectSimpleScore()
        {
            DataTable dt = new DataTable();
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "select top 10 UserName,SimpleScore from UserScore order by SimpleScore desc";
            SqlDataAdapter sqldata = new SqlDataAdapter(comm);
            conn.Open();
            sqldata.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 查询普通的成绩排名
        /// </summary>
        /// <returns></returns>
        private static DataTable SelectCommonScore()
        {
            DataTable dt = new DataTable();
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "select top 10 UserName,CommonScore from UserScore order by CommonScore desc";
            SqlDataAdapter sqldata = new SqlDataAdapter(comm);
            conn.Open();
            sqldata.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 查询困难的成绩排名
        /// </summary>
        /// <param name="diff"></param>
        /// <returns></returns>
        private static DataTable SelectBumpScoreScore()
        {
            DataTable dt = new DataTable();
            comm.Parameters.Clear();
            comm.Connection = conn;
            comm.CommandText = "select top 10 UserName,BumpScore from UserScore order by BumpScore desc";
            SqlDataAdapter sqldata = new SqlDataAdapter(comm);
            conn.Open();
            sqldata.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 修改成绩
        /// </summary>
        /// <param name="result">成绩</param>
        /// <returns></returns>
        public static void UpUserScore(int result)
        {
            if (FormClass.user.cmbdiff.SelectedIndex == 0)
                UpUserSimpleScore(FormClass.user.txtname.Text, result);
            else if (FormClass.user.cmbdiff.SelectedIndex == 1)
                UpUserCommonScore(FormClass.user.txtname.Text, result);
            else
                UpUserBumpScore(FormClass.user.txtname.Text, result);
        }
        /// <summary>
        /// 查询成绩排名
        /// </summary>
        /// <param name="diff"></param>
        /// <returns></returns>
        public static DataTable SelectScore(int diff)
        {
            DataTable dt = new DataTable();
            if (diff == 0)
                dt = SelectSimpleScore();
            else if (diff == 1)
                dt = SelectCommonScore();
            else
                dt = SelectBumpScoreScore();
            return dt;
        }
    }
}
