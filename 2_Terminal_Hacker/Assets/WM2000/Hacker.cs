using UnityEngine;

public class Hacker : MonoBehaviour {

	// Configuration
	const string menuHint = "You may type 'menu' at any time.";
	string[] level1Passwords = {"bed", "television", "bookshelf", "couch", "table", "lamp"};
	string[] level2Passwords = {"computer", "refrigerator", "heater", "paintings", "conditioner", "foodstuffs"};
	string[] level3Passwords = {"hypocrite", "anagram", "spaceship", "monitor", "vestibule", "corsage"};

	// Game State
	int level;
	enum Screen {MainMenu, Password, Win}
	Screen currentScreen;
	string password;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu(){
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("What would you like to hack into?");
		Terminal.WriteLine("Press 1 for the kitchen");
		Terminal.WriteLine("Press 2 for the bedroom");
		Terminal.WriteLine("Press 3 for the random words");
		Terminal.WriteLine("Enter your selection:");
	}
	
	void OnUserInput(string input){
		if (input == "menu"){
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
		else if (currentScreen == Screen.Password){
			CheckPassword(input);
		}
    }

    void RunMainMenu(string input)
    {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber){
			level = int.Parse(input);
			AskForPassword();
		}
        else{
            Terminal.WriteLine("Please make a valid selection");
        }
    }

    void AskForPassword(){
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
		Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword(){
        switch (level){
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input){
		if (input == password){
            DisplayWinScreen();
        }
        else{
			AskForPassword();
		}
	}

    void DisplayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
		Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward(){
		switch(level){
			case 1:
        		Terminal.WriteLine("Great job on level 1!!");
				Terminal.WriteLine(@"
╱╱┏╮
╱╱┃┃
▉━╯┗━╮
▉┈┈┈┈┃
▉╮┈┈┈┃
╱╰━━━╯
"
				);
				break;
			case 2:
        		Terminal.WriteLine("Great job on level 2!!");
				Terminal.WriteLine(@"
╱╱┏╮
╱╱┃┃
▉━╯┗━╮
▉┈┈┈┈┃
▉╮┈┈┈┃
╱╰━━━╯
"
				);
				break;
			case 3:
        		Terminal.WriteLine("Great job on level 3!!");
				Terminal.WriteLine(@"
╱╱┏╮
╱╱┃┃
▉━╯┗━╮
▉┈┈┈┈┃
▉╮┈┈┈┃
╱╰━━━╯
"
				);
				break;
		}
    }
}
