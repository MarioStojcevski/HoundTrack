using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary.DataAcess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// All the text files
        /// </summary>
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";

        /// <summary>
        /// Creates a personModel and adds it toString into PersonModels.csv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().loadFile().ConvertToPersonModels();

            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.id).First().id + 1;
            }

            model.id = currentId;
            currentId += 1;

            people.Add(model);
            people.SaveToPeopleFile(PeopleFile);

            return model;
        }
        /// <summary>
        /// Creates a prizeModel and adds it toString into PrizeModels.csv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizesFile.FullFilePath().loadFile().ConvertToPrizeModels();

            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            currentId += 1;

            prizes.Add(model);
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
        /// <summary>
        /// Creates a teamModel and adds it toString into TeamModels.csv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().loadFile().ConvertToTeamModels(PeopleFile);

            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            currentId += 1;

            teams.Add(model);
            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile.FullFilePath().loadFile().ConvertToTournamentModels();
            
            //TODO not implemented!

            return model;
        }

        /// <summary>
        /// Function to get a list of all people in the PeopleFile
        /// </summary>
        /// <returns>List of PersonModel</returns>
        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().loadFile().ConvertToPersonModels();
        }
        /// <summary>
        /// Function to get a list of all teams in the TeamFile
        /// </summary>
        /// <returns></returns>
        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().loadFile().ConvertToTeamModels(PeopleFile);
        }
    }
}
