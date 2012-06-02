using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SHF_BT;

namespace CHSTRAS_091_BT.Common
{
    class btCHSTRAS_091_Unit
    {
        private Hashtable userUnitIDs;
        private btCHSTRAS_091_Database database;
        private btCHSTRAS_091_Base bt;
        private btCHSTRAS_091_Time time;
        private DateTime startTime;
        private Hashtable keyValues;
        private btSHFUserLogin shfUserLogin;
        private btSHFUnitPractice shfUnitPratice;
        private int totalNum, completeNum, totalScore, rightNum;

        public btCHSTRAS_091_Unit(DateTime startTime, int totalNum, btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            this.shfUnitPratice = shfUnitPratice;
            this.shfUserLogin = shfUserLogin;
            bt = new btCHSTRAS_091_Base();
            time = new btCHSTRAS_091_Time();
            userUnitIDs = bt.getUserUnitIDs(shfUserLogin, shfUnitPratice);
            this.startTime = startTime;
            this.totalNum = totalNum;
            keyValues = new Hashtable();
        }

        public void record()
        {
            statistics();
            foreach (DictionaryEntry userUnitID in userUnitIDs)
            {
                keyValues.Add(userUnitID.Key, userUnitID.Value);
            }
            long practiceTime = time.getAnswerTime(startTime);
            keyValues.Add("StartDateTime", startTime);
            keyValues.Add("PracticeTime", practiceTime);
            keyValues.Add("TotalNumber", totalNum);
            keyValues.Add("CompleteNumber", completeNum);
            keyValues.Add("RightNumber", rightNum);
            keyValues.Add("ErrorNumber", completeNum - rightNum);
            keyValues.Add("CorrectRate", rightNum * 100 / completeNum);
            keyValues.Add("TotalScore", totalScore);
            keyValues.Add("Speed", completeNum * 60000 / practiceTime);
            database.insert("R_SHFUnitScores", keyValues);
        }

        private void statistics()
        {
            String where = "StartDateTime>=#" + startTime + "#";
            String[] selections = new String[] { "TestScore" };
            database = new btCHSTRAS_091_Database();
            IDataReader reader = database.query("R_SHFItemScores", selections, where, null);
            completeNum = database.getSize();
            totalScore = 0;
            while (reader.Read())
            {
                totalScore += reader.GetInt32(0);
            }
            where = "StartDateTime>=#" + startTime + "# AND TestRight=true";
            database.query("R_SHFItemScores", selections, where, null);
            rightNum = database.getSize();
        }

        public String getStatistics()
        {
            String statics = "本单元成绩：\n\n";
            statics += "单元名：    " + shfUnitPratice.UnitPracticeName + "\n";
            statics += "用户名：    " + shfUserLogin.UserName + "\n";
            statics += "开始时间： " + keyValues["StartDateTime"] + "\n";
            statics += "训练用时： " + (long)keyValues["PracticeTime"]/1000 + " 秒\n";
            statics += "总题数：    " + keyValues["TotalNumber"] + "\n";
            statics += "完成数：    " + keyValues["CompleteNumber"] + "\n";
            statics += "正确数：    " + keyValues["RightNumber"] + "\n";
            statics += "错题数：    " + keyValues["ErrorNumber"] + "\n";
            statics += "正确率：    " + keyValues["CorrectRate"] + "%\n";
            statics += "累计得分： " + keyValues["TotalScore"] + "\n";
            statics += "速度：       " + keyValues["Speed"] + "题/分钟\n";
            return statics;
        }
    }
}
