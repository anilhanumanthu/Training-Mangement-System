using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using System.Threading.Tasks;
using DataLinkLayer;
using System.Data;

namespace BusinessLogic
{
    public class clsBLL
    {
        public int VerifyLoginData(UserBO ob)
        {
            clsDAL ob1 = new clsDAL();
            return ob1.LoginAuthentication(ob).Tables[0].Rows.Count;
        }

        public int InsertRegisterData(UserBO ob)
        {
            clsDAL ob9 = new clsDAL();
            return ob9.InsertRegistration(ob);
        }

        public string firstnamerBLL(string s)
        {
            clsDAL obj = new clsDAL();
            return obj.firstnamer(s);
        }


        public int FindUserTypeBLL(UserBO ob)
        {
            clsDAL ob1 = new clsDAL();
            return ob1.FindUserType(ob);
        }

        public int VerifyUserIDBLL(UserBO ob2)
        {
            clsDAL ob1 = new clsDAL();
            return ob1.VerifyUserID(ob2);
        }

        public int AdminCounterBLL()
        {
            clsDAL ob1 = new clsDAL();
            return ob1.AdminCounterDAL().Tables[0].Rows.Count;
        }

        public int AdminBuilderBLL(UserBO ob)
        {
            clsDAL ob13 = new clsDAL();
            return ob13.AdminBuilder(ob);
        }

        public int InsertSkillBLL(UserBO ob)
        {
            clsDAL ob4 = new clsDAL();
            return ob4.InsertSkill(ob);
        }

        public int SkillVerifyBLL(UserBO ob)
        {
            clsDAL ob4 = new clsDAL();
            return ob4.SkillVerify(ob);
        }

        public string SkillSearchBLL(UserBO ob)
        {
            clsDAL ob4 = new clsDAL();
            return ob4.SkillSearch(ob);
        }

        public DataTable SkillSearchTableBLL(UserBO ob)
        {
            clsDAL ob4 = new clsDAL();
            return ob4.SkillSearchTable(ob);
        }
        
        public DataTable getCoursesofSkillBLL(UserBO ob)
        {
            clsDAL ob4 = new clsDAL();
            return ob4.getCoursesofSkill(ob);
        }
        public List<string> FirstBLL()
        {
            clsDAL obj = new clsDAL();
            List<string> skillList = obj.First();
            return skillList;

        }

        public List<string> getScoreDetailsBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            List<string> skillList = obj.getScoreDetails(ob);
            return skillList;

        }
        
        public List<string> First2BLL()
        {
            clsDAL obj = new clsDAL();
            List<string> skillList2 = obj.First2();
            return skillList2;

        }
        public List<string> First3BLL()
        {
            clsDAL obj = new clsDAL();
            List<string> skillList3 = obj.First3();
            return skillList3;

        }

        public List<string> CourseDetailsPageBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            List<string> cDetails = obj.CourseDetails(ob);
            return cDetails;
        }

        public DataTable CourseContentBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.CourseContent(ob);
        }

        public int CourseInsertionBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.CourseInsertion(ob);
        }

        public int DeleteCourseBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.DeleteCourse(ob);
        }

        public int DeleteSkillBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.DeleteSkill(ob);
        }

        public int CourseUpdateBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.CourseUpdate(ob);
        }

        public int verifycoursecodeBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.verifycoursecode(ob);
        }

        public int InsertQuestionBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.InsertQuestion(ob);
        }
        
        public int QuestionnumberfinderBLL(string s)
        {
            clsDAL ob = new clsDAL();int n = 0;
            n = ob.Questionnumberfinder(s);
            return n;
        }
        public int deletecoursematerialBLL(UserBO s)
        {
            clsDAL obj = new clsDAL();
            return obj.deletecoursematerial(s);
        }

        public int deletetheQuestionBLL(UserBO s)
        {
            clsDAL obj = new clsDAL();
            return obj.deletetheQuestion(s);
        }

        public int updatetheQuestionBLL(UserBO s)
        {
            clsDAL obj = new clsDAL();
            return obj.updatetheQuestion(s);
        }

        public DataTable QuestionTableCreatorBLL(UserBO o)
        {
            clsDAL obj = new clsDAL();
            return obj.QuestionTableCreator(o);
        }

        public void updateAnsweredBLL(int rno,string s,string cocode)
        {
            rno++;
            clsDAL ob = new clsDAL();
            ob.updateAnswered(rno,s,cocode);
        }

        public int scorecardBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.scorecard(ob);
        }

        public void onregistrationcourseBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            obj.onregistrationcourse(ob);
        }
        

        public void onupdateQuantifierBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            obj.onupdateQuantifier(ob);
        }

        public string iscourseopenedBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.iscourseopened(ob);
        }

        public int isregisteredBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.isregistered(ob);
        }

        public void activateStatusBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            obj.activateStatus(ob);
        }

        public void updateStatusBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            obj.updateStatus(ob);
        }


        public DataTable UserIDSearcherBLL(UserBO ob)
        {
            clsDAL obj = new clsDAL();
            return obj.UserIDSearcher(ob);
        }
    }
}
