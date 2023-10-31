using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Text.Json;

namespace Business.Concrete
{
    public class LotManager : ILotService
    {
        private readonly ILotDal _lotDal;
        private readonly IGroupDal _groupDal;
        private readonly ITeamDal _teamDal;

        public LotManager(ILotDal lotDal, IGroupDal groupDal, ITeamDal teamDal)
        {
            _lotDal = lotDal;
            _groupDal = groupDal;
            _teamDal = teamDal;
        }

        public IDataResult<Lot> DrawLottery(DrawLotteryDto drawLotteryDto)
        {
            try
            {
                int groupSize = 32 / drawLotteryDto.GroupCount;

                var teams = _teamDal.GetList().Data;
                var groups = _groupDal.GetList().Data;

                var lot = new Lot()
                {
                    Id = 0,
                    DrawerFullname = drawLotteryDto.FullName,
                    GroupCount = drawLotteryDto.GroupCount,
                    Groups = _groupDal.GetNumberedList(drawLotteryDto.GroupCount).Data
                };


                for (var i = 0; i < groupSize; i++)
                {
                    for (var j = 0; j < drawLotteryDto.GroupCount; j++)
                    {
                        Team teamToAdd = new Team();
                        bool acceptable = false;
                        do
                        {
                            teamToAdd = RandomTeam(teams);
                            if (!SameCountryExists(lot.Groups.ElementAt(j), teamToAdd) &&
                            !SameTeamExists(lot.Groups, teamToAdd))
                            {
                                acceptable = true;
                            }

                        } while (!acceptable);

                        lot.Groups.ElementAt(j).Teams.Add(teamToAdd);
                    }
                }
                lot.Details = JsonSerializer.Serialize(lot).ToString();
                _lotDal.Add(lot);
                return new DataResult<Lot>(lot, true);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Lot>(ex.Message);
            }
        }

        private bool SameTeamExists(List<Group> groups, Team team)
        {
            bool result = false;
            foreach (var group in groups)
            {
                result = group.Teams.Any(x => x.Id == team.Id);

                if (result)
                {
                    return result;
                }
            }

            return result;
        }

        private bool SameCountryExists(Group group, Team team)
        {
            return group.Teams.Any(x => x.CountryId == team.CountryId);
        }

        private Team RandomTeam(List<Team> teams)
        {
            var random = new Random();
            var number = random.Next(1, 33);
            var team = teams.Where(x => x.Id == number).FirstOrDefault();
            return team;
        }
    }
}
