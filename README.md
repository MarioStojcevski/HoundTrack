##################################--- HoundTrack v1.0 ---##################################


This application is a C# Windows forms based app created for university project purposes.
It's main function is to Create, Save and keep track of Tournaments. It can be used for 
any kind of sports activities or gaming events. The idea is that players will play 1v1
games or in teams and the application will do the scheduling.
In the Program.cs file the user can change the way data is stored. DataConnection.Sql or
DataConnection.TextFile. If the app is run in Sql mode it will connect to localhost and
store data in the tables for Teams, People, Prizes, Rounds...If it's TextFile then the
data will be stored in C:\data\TournamentTracker\[filename]. There are a few types of
files it can save. People.csv, Prizes.csv, Tournaments.csv...

WINDOWS FORMS:

#TOURNAMENT DASHBOARD FORM
This is the main form. If you close this, the application closes.
The first form that should open is the Tournament Dashboard. It displays a list of tournaments,
and buttons to Create a new tournament and Load an existing tournament.

#CREATE TOURNAMENT
In the create tournament form you can add a name to the tournament, the entry fee, teams and prizes.
For the teams you can either choose from the existing teams, or click a link that will take you to the
Create Team form. You can also create a Prize which takes you to the Create Prize form. On the right side
of the form there are two ListBoxes, one for the teams and the other for the prizes. Each has it's own
delete button so you can remove a selected item from the ListBox. Once you filled all the info
you can hit Create Tournament and it will take you back to the Tournament Dashboard with the new tournament
added in the List of Tournaments.

#CREATE TEAM
The create team form is simple. You enter the team name, select team members from an already existing
DropDownListBox and hit Add Member which adds that participant to the right side of the form (the 
teamMembersListBox, which also has it's own remove selected button), or you create a new Person that
adds it to the List of People (Participants) with a small built in form that takes info about the
FirstName, LastName, Email and CellPhone. Once done hit Create Team.

#CREATE PRIZE
This form is ment to create the prizes for a tournament. Fill in the place number, place name and
prize amount or percentage and once hitting the Create Prize button it will add a Prize object to
the table of Prizes.

#TOURNAMENT VIEWER FORM
Once idle, you can view the current tournament status from this form after selecting one and hitting
Load from the tournament dashboard.


_________________________________________________________________________________________________________
This application is created with the help of online tutorials and the all mighty internet. It is my
first Windows Forms based application. Thank you for reading this.

Stojcevski Mario.
HoundTrack v 1.0
