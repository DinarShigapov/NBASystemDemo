using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NBASystem.Model
{
    public partial class Matchup
    {
        public string StatusName
        {
            get
            {
                if (Status == 1)
                {
                    return "Finished";
                }
                else if (Status == -1)
                {
                    return "Not Start";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string StatusColor
        {
            get
            {
                if (Status == 1)
                {
                    return "Gray";
                }
                else if (Status == -1)
                {
                    return "#FF2BB4E2";
                }
                else
                {
                    return "Red";
                }
            }
        }

        public Visibility StatusVisibility
        {
            get 
            {
                if (Status == 1)
                {
                    return Visibility.Visible;
                }
                else if (Status == -1)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }


        public double FieldGoalTeamAway
        {
            get 
            {
                return FieldGoalProcent(Team);
            }
        }
        public double FieldGoalTeamHome
        {
            get
            {
                return FieldGoalProcent(Team1);
            }
        }

        public double ThreePointTeamAway
        {
            get
            {
                return ThreePointProcent(Team);
            }
        }
        public double ThreePointTeamHome
        {
            get
            {
                return ThreePointProcent(Team1);
            }
        }

        public double FieldGoalProcent(Team team) 
        {
            double allScore = PlayerStatistics.Sum(x => x.FieldGoalMade);
            double teamScore = PlayerStatistics.Where(x => x.TeamId == team.Id).Sum(x => x.FieldGoalMade);
            double result = teamScore / allScore * 100;
            return Math.Round(result, 1);
        }

        public double ThreePointProcent(Team team)
        {
            double allScore = PlayerStatistics.Sum(x => x.FreeThrowMade);
            double teamScore = PlayerStatistics.Where(x => x.TeamId == team.Id).Sum(x => x.FreeThrowMade);
            double result = teamScore / allScore * 100;
            return Math.Round(result, 1);
        }



    }
}
