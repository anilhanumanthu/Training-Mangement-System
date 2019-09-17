using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BusinessObject;
using System.Security.Cryptography;
using System.IO;

namespace DataLinkLayer
{
    public class clsDAL
    {
        DataSet dt = new DataSet();

        DataTable dataTab = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString());

        public string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        public string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        public DataSet LoginAuthentication(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[VerifyData]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", ob.userid);

            ob.password = Encrypt(ob.password);

            cmd.Parameters.AddWithValue("@pass", ob.password);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dt); con.Close();
            return dt;
        }

        public DataSet AdminCounterDAL()
        {
            SqlCommand cmd = new SqlCommand("[AdminCounter]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dt); con.Close();
            return dt;
        }

        public int VerifyUserID(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[VerifyUserID]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", ob.userid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int InsertQuestion(UserBO ob)
        {
                int n = 0;
                SqlCommand cmd = new SqlCommand("[InsertQuestion]", con);
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@qno", ob.qno);
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            cmd.Parameters.AddWithValue("@question", ob.question);
            cmd.Parameters.AddWithValue("@option1", ob.option1);
            cmd.Parameters.AddWithValue("@option2", ob.option2);
            cmd.Parameters.AddWithValue("@option3", ob.option3);
            cmd.Parameters.AddWithValue("@option4", ob.option4);
            cmd.Parameters.AddWithValue("@questAns", ob.questAns);
            cmd.Parameters.AddWithValue("@AnsGiven","S");
            con.Open();
                n = cmd.ExecuteNonQuery();
            return n;
            
        }
        public int FindUserType(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[FindUserType]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", ob.userid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "A")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        public int InsertRegistration(UserBO ob)
        {
            int done = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[InsertData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", ob.fname);
                cmd.Parameters.AddWithValue("@lname", ob.lname);
                cmd.Parameters.AddWithValue("@age", ob.age);
                cmd.Parameters.AddWithValue("@gender", ob.gender);
                cmd.Parameters.AddWithValue("@contact", ob.contactno);
                cmd.Parameters.AddWithValue("@uid", ob.userid);

                ob.password = Encrypt(ob.password);

                cmd.Parameters.AddWithValue("@pass", ob.password);
                cmd.Parameters.AddWithValue("@email", ob.mailID);
                cmd.Parameters.AddWithValue("@utype", ob.userType);
                con.Open();
                done = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                done = 0;
            }
            return done;
        }

        public int AdminBuilder(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[AdminBuilder]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", ob.userid);
            con.Open();
            int build = cmd.ExecuteNonQuery();
            con.Close();
            if (build == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string firstnamer(string st)
        {
            SqlCommand cmd = new SqlCommand("[firstnamer]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", st);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            string column = "Un-Known";
            if (rdr.Read())
            {
                column = rdr[0].ToString() + " " + rdr[1].ToString();
            }
            con.Close();
            return column;
        }

        public int InsertSkill(UserBO ob)
        {
            int done = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("InsertSkill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skill", ob.skillName);
                con.Open();
                done = cmd.ExecuteNonQuery(); con.Close();
            }
            catch
            {
                done = 0;
            }
            return done;

        }

        public int SkillVerify(UserBO ob)
        {
            int done = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SkillVerify", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SkillName", ob.skillName);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr[0] == null)
                    {
                        done = 1;
                    }
                    else
                    {
                        done = 0;
                    }
                }
            }
            catch
            {
                done = 0;
            }
            con.Close();
            return done;
        }


        public string SkillSearch(UserBO ob)
        {
            string s = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SkillSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SkillName", ob.skillName);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    s = rdr[0].ToString();
                }
            }
            catch
            {
                s = "";
            }
            con.Close();
            return s;
        }
        public DataTable SkillSearchTable(UserBO ob)
        {
                SqlCommand cmd = new SqlCommand("SkillSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SkillName", ob.skillName);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(dataTab); con.Close();
                return dataTab;
        }
        

        public DataTable QuestionTableCreator(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("QuestionTableCreator", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseID", ob.coursecode);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dataTab); con.Close();
            return dataTab;
        }

        public DataTable getCoursesofSkill(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("getCoursesofSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SkillName", ob.skillName);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dataTab); con.Close();
            return dataTab;
        }

        public List<string> First()
        {
            List<string> SkillsList = new List<string>(10);
            try
            {
                SqlCommand cmd = new SqlCommand("First3Names", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    SkillsList.Add(rdr[0].ToString());
                }
            }
            catch
            {
                SkillsList.Add("none");
            }
            con.Close();
            return SkillsList;
        }

        public List<string> First2()
        {
            List<string> SkillsList2 = new List<string>(10);
            try
            {
                SqlCommand cmd = new SqlCommand("First2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    SkillsList2.Add(rdr[0].ToString());
                }
            }
            catch
            {
                SkillsList2.Add("none");
            }
            con.Close();
            return SkillsList2;
        }

        public List<string> First3()
        {
            List<string> SkillsList3 = new List<string>(10);
            try
            {
                SqlCommand cmd = new SqlCommand("First3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    SkillsList3.Add(rdr[0].ToString());
                }
            }
            catch
            {
                SkillsList3.Add("none");
            }
            con.Close();
            return SkillsList3;
        }


        public int CourseInsertion(UserBO ob)
        {
            int done = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[CourseInsertion]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
                cmd.Parameters.AddWithValue("@coursedescription", ob.coursedescription);
                cmd.Parameters.AddWithValue("@skillname",ob.skillName);
                cmd.Parameters.AddWithValue("@coursedate", ob.coursedate);
                cmd.Parameters.AddWithValue("@coursetime", ob.coursetime);
                cmd.Parameters.AddWithValue("@courseaddedby", ob.courseaddedby);
                cmd.Parameters.AddWithValue("@otherreference", ob.otherreference);
                con.Open();
                done = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                done = 0;
            }
            return done;
        }


        public int CourseUpdate(UserBO ob)
        {
            int done = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[CourseUpdate]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coursecode1", ob.coursecodetobechanged);
                cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
                cmd.Parameters.AddWithValue("@coursedescription", ob.coursedescription);
                cmd.Parameters.AddWithValue("@skillname",ob.skillName);
                cmd.Parameters.AddWithValue("@coursedate", ob.coursedate);
                cmd.Parameters.AddWithValue("@coursetime", ob.coursetime);
                cmd.Parameters.AddWithValue("@courseaddedby", ob.courseaddedby);
                cmd.Parameters.AddWithValue("@otherreference", ob.otherreference);
                con.Open();
                done = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                done = 0;
            }
            return done;
        }
        

        public List<string> CourseDetails(UserBO ob)
        {
            List<string> lister = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand("CourseDetailsPage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseCode",ob.coursecode);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                if (rdr.Read())
                {
                    lister.Add(rdr[0].ToString());
                    lister.Add(rdr[1].ToString());
                    lister.Add(rdr[2].ToString());
                    lister.Add(rdr[3].ToString());
                    lister.Add(rdr[4].ToString());
                    lister.Add(rdr[5].ToString());
                    lister.Add(rdr[6].ToString());
                }
            }
            catch
            {
                lister.Add("none");
            }
            con.Close();
            return lister;

        }
        

            public List<string> getScoreDetails(UserBO ob)
        {
            List<string> lister = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand("getScoreDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseCode", ob.coursecode);
                cmd.Parameters.AddWithValue("@id",ob.userid);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    lister.Add(rdr[0].ToString());
                    lister.Add(rdr[1].ToString());
                    lister.Add(rdr[2].ToString());
                    lister.Add(rdr[3].ToString());
                    lister.Add(rdr[4].ToString());
                }
            }
            catch
            {
                lister.Add("none"); lister.Add("none"); lister.Add("none"); lister.Add("none"); lister.Add("none");
            }
            con.Close();
            return lister;

        }

        public DataTable CourseContent(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[CourseContent]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Skill", ob.skillName);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dataTab); con.Close();
            return dataTab;
        }

        public int DeleteCourse(UserBO ob)
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand("[DeleteCourse]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseName", ob.coursecode);
            con.Open();
            n = cmd.ExecuteNonQuery();

            if (n == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public int DeleteSkill(UserBO ob)
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand("[deleteskill]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@skillname", ob.skillName);
            con.Open();
            n = cmd.ExecuteNonQuery();

            if (n == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }



        public int verifycoursecode(UserBO ob)
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand("[verifycoursecode]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            con.Open();
            n = cmd.ExecuteNonQuery();

            if (n == -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        

        public int deletecoursematerial(UserBO s1)
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand("[deletecoursematerial]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coursematerial", s1.coursematerial);
            con.Open();
            n = cmd.ExecuteNonQuery();

            if (n == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        

        public int Questionnumberfinder(string s)
        {
            int questioner = 0;
            SqlCommand cmd = new SqlCommand("[Questionnumberfinder]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coursecode", s);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                questioner = Convert.ToInt32(rdr[0]);
            }
            return questioner;
        }



        public int deletetheQuestion(UserBO ob)
        {
            int questioner =0;
            SqlCommand cmd = new SqlCommand("[deletetheQuestion]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            cmd.Parameters.AddWithValue("@qno", ob.qno);

            con.Open();
            questioner = cmd.ExecuteNonQuery();
            
            return questioner;
        }



        public int updatetheQuestion(UserBO ob)
        {
            int questioner = 0;
            SqlCommand cmd = new SqlCommand("[updatetheQuestion]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            cmd.Parameters.AddWithValue("@qno", ob.qno);

            con.Open();
            questioner = cmd.ExecuteNonQuery();
            
            return questioner;
        }


        public void updateAnswered(int r,string st,string ccode)
        {
            SqlCommand cmd = new SqlCommand("[updateAnswered]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@qno", r);
            cmd.Parameters.AddWithValue("@coursecode",ccode);
            cmd.Parameters.AddWithValue("@answered", st);

            con.Open();
            cmd.ExecuteNonQuery();
            
        }


        public int scorecard(UserBO ob)
        {
            int res = 0;
            SqlCommand cmd = new SqlCommand("[scorecard]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseid", ob.coursecode);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                res = Convert.ToInt32(rdr[0]);
            }
            return res;
        }

        public void onregistrationcourse(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[onregistrationcourse]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ob.userid);
            cmd.Parameters.AddWithValue("@course", ob.coursecode);
            cmd.Parameters.AddWithValue("@register",ob.registered);
            cmd.Parameters.AddWithValue("@courseopen",ob.courseopened);
            con.Open();
            int n = cmd.ExecuteNonQuery();
        }
        

        public void onupdateQuantifier(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[onupdateQuantifier]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ob.userid);
            cmd.Parameters.AddWithValue("@course", ob.coursecode);
            con.Open();
            int k = cmd.ExecuteNonQuery();
        }


        public string iscourseopened(UserBO ob)
        {
            string res;
            SqlCommand cmd = new SqlCommand("[iscourseopened]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseid", ob.coursecode);
            cmd.Parameters.AddWithValue("@id", ob.userid);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                res = rdr[0].ToString();
            }
            else { res = "N"; }
            return res;
        }

        public int isregistered(UserBO ob)
        {
            int res;
            SqlCommand cmd = new SqlCommand("[isregistered]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseid", ob.coursecode);
            cmd.Parameters.AddWithValue("@id", ob.userid);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                res = Convert.ToInt32(rdr[0]);
            }
            else { res = 0; }
            return res;
        }


        public void activateStatus(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[activateStatus]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ob.userid);
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            cmd.Parameters.AddWithValue("@completiondate", ob.completiondate);
            cmd.Parameters.AddWithValue("@score", Convert.ToInt32(ob.score));
            cmd.Parameters.AddWithValue("@status", ob.status);
            con.Open();
            cmd.ExecuteNonQuery();

        }
        
            public void updateStatus(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[updateStatus]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ob.userid);
            cmd.Parameters.AddWithValue("@coursecode", ob.coursecode);
            cmd.Parameters.AddWithValue("@completiondate", ob.completiondate);
            cmd.Parameters.AddWithValue("@score", Convert.ToInt32(ob.score));
            cmd.Parameters.AddWithValue("@status", ob.status);
            con.Open();
            cmd.ExecuteNonQuery();

        }

        public DataTable UserIDSearcher(UserBO ob)
        {
            SqlCommand cmd = new SqlCommand("[UserIDSearcher]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ob.userid);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dataTab); con.Close();
            return dataTab;
        }

    }

}
