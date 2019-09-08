using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowdyHack2019
{
    class ParticipantData : IComparable<ParticipantData>
    {
        public string username { get; set; }
        public int grade { get; set; }
        public int programmingExperience { get; set; }
        public bool wantsToTeach { get; set; }
        public bool wantsToLearn { get; set; }
        public string preferredLang { get; set; }

        public int score { get; set; }

        public int match(ParticipantData p)
        {
            int incompabScore = 0;
            if (!preferredLang.Equals(p.preferredLang)) incompabScore+=5;
            incompabScore += Math.Abs(grade - p.grade);
            incompabScore += Math.Abs(programmingExperience - p.programmingExperience);
            if (!(wantsToLearn && p.wantsToTeach) || !(wantsToTeach && p.wantsToLearn)) incompabScore++;

            return incompabScore;
        }

        public int CompareTo(ParticipantData p)
        {
            return score - p.score;
        }
    }

    
}
