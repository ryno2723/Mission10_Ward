export type Bowler = {
  bowlerId: number;
  bowlerLastName: string;
  bowlerFirstName: string;
  bowlerMiddleName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
  teamId: number;
  bowlerScores: any[];
  team: Team;
};

export type Team = {
  teamId: number;
  teamName: string;
  captainId: number;
  bowlers: Bowler[]; // Assuming bowlers is an array of Bowler objects
  tourneyMatchEvenLaneTeams: any[]; // Assuming these are arrays, adjust as needed
  tourneyMatchOddLaneTeams: any[];
};
