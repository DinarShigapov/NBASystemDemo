using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBASystem.Model
{
    public partial class Player
    {
        public int Experience
        {
            get 
            {
                return (int)(DateTime.Today.Year - JoinYear.Year);
            }
        }

        public int PlayerSeasonId 
        {
            get 
            {
                return App.DB.Season.OrderByDescending(f => f.Id).FirstOrDefault().Id;
            }
        }

        public double SalaryPlayer
        {
            get 
            {
                return (double)PlayerInTeam.FirstOrDefault(x => x.SeasonId == App.DB.Season.OrderByDescending(f =>  f.Id).FirstOrDefault().Id).Salary;
            }
        }

        public string PlayerTeam
        {
            get
            {
                return PlayerInTeam.FirstOrDefault(x => x.SeasonId == PlayerSeasonId).Team.TeamName;
            }
        }

        public int PlayerTeamId
        {
            get
            {
                return PlayerInTeamCurrentSeason.Team.Id;
            }
        }

        public PlayerInTeam PlayerInTeamCurrentSeason
        {
            get 
            {
                return PlayerInTeam.FirstOrDefault(x => x.SeasonId == PlayerSeasonId);
            }
        }

        public string NumberPlayer
        {
            get
            {
                return PlayerInTeam.FirstOrDefault(x => x.SeasonId == PlayerSeasonId).ShirtNumber;
            }
        }

        public double PPGCareer
        {
            get
            {
                var result = PlayerStatistics.Select(x => x.Point).ToList();
                if (result.Count > 0)
                {
                    return Math.Round((double)result.Average(), 1);
                }
                return 0;
            }
        }

        public double PPGSeason
        {
            get
            {
                var result = PlayerStatistics.Where(
                        x => x.PlayerId == PlayerInTeamCurrentSeason.PlayerId &&
                        x.TeamId == PlayerInTeamCurrentSeason.TeamId &&
                        x.Team.PlayerInTeam.Any(z => z.SeasonId == PlayerInTeamCurrentSeason.Id)).ToList();

                if (result.Count > 0)
                {
                    return Math.Round((double)result.Select(x => x.Point).Average(), 1);
                }
                return 0;
                
            }
        }

        public double APGCareer
        {
            get
            {
                var result = PlayerStatistics.Select(x => x.Assist).ToList();
                if (result.Count > 0)
                {
                    return Math.Round((double)result.Average(), 1);
                }
                return 0;
            }
        }

        public double APGSeason
        {
            get
            {
                var result = PlayerStatistics.Where(
                        x => x.PlayerId == PlayerInTeamCurrentSeason.PlayerId &&
                        x.TeamId == PlayerInTeamCurrentSeason.TeamId &&
                        x.Team.PlayerInTeam.Any(z => z.SeasonId == PlayerInTeamCurrentSeason.Id)).ToList();

                if (result.Count > 0)
                {
                    return Math.Round((double)result.Select(x => x.Assist).Average(), 1);
                }
                return 0;

            }
        }

        public double RPGCareer
        {
            get
            {
                var result = PlayerStatistics.Select(x => x.Rebound).ToList();
                if (result.Count > 0)
                {
                    return Math.Round((double)result.Average(), 1);
                }
                return 0;
            }
        }

        public double RPGSeason
        {
            get
            {
                var result = PlayerStatistics.Where(
                        x => x.PlayerId == PlayerInTeamCurrentSeason.PlayerId &&
                        x.TeamId == PlayerInTeamCurrentSeason.TeamId &&
                        x.Team.PlayerInTeam.Any(z => z.SeasonId == PlayerInTeamCurrentSeason.Id)).ToList();

                if (result.Count > 0)
                {
                    return Math.Round((double)result.Select(x => x.Rebound).Average(), 1);
                }
                return 0;

            }
        }
    }

}
