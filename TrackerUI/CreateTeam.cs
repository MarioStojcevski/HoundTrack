using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeam : Form
    {

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        private ITeamRequester callingForm;

        public CreateTeam(ITeamRequester caller)
        {
            InitializeComponent();
            CreateSampleData();
            WireUpLists();
            callingForm = caller;
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Trajce", LastName = "Trajkovski" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Kristina", LastName = "Kristovska" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "David", LastName = "Davidovski" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Elena", LastName = "Jovanovska" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Please fill in all the blanks");
            }
            else
            {
                PersonModel personModel = new PersonModel();
                personModel.FirstName = firstNameValue.Text;
                personModel.LastName = lastNameValue.Text;
                personModel.EmailAddress = eMailValue.Text;
                personModel.CellPhoneNumber = phoneValue.Text;

                personModel = GlobalConfig.Connection.CreatePerson(personModel);
                selectedTeamMembers.Add(personModel);
                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                eMailValue.Text = "";
                phoneValue.Text = "";
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (eMailValue.Text.Length == 0)
            {
                return false;
            }
            if (phoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel) selectTeamMemberDropDown.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                WireUpLists();
            }

        }

        private void RemoveTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if(p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = new TeamModel();
            team.TeamName = teamNameValue.Text;
            team.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(team);

            callingForm.TeamComplete(team);
            this.Close();
        }
    }
}
