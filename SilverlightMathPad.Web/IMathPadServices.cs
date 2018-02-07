using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SilverlightMathPad.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMathPadServices" in both code and config file together.
    [ServiceContract]
    public interface IMathPadServices
    {
        [OperationContract]
        void AddEntryToHallOfFame(HallOfFameEntry objFameEntry);

        [OperationContract]
        HallOfFameEntry[] GetEntriesOfHallOfFame();

        [OperationContract]
        HallOfFameEntry[] GetEntriesOfScoreBoard();

        [OperationContract]
        int GetTopScore();

        [OperationContract]
        void AddScoreBoard(string strName, int intPoints, int intTime, string strAddition);

        [OperationContract]
        void AddHallofFame(string strName, int intPoints, int intTime, string strAddition);

    }
    [DataContract]
    public class HallOfFameEntry
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Score { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string QuizType { get; set; }
        [DataMember]
        public string Date { get; set; }
    }

}
