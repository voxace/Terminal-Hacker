using System;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game Data
    string[] level1passwords = { "book", "shelf", "borrow", "quiet", "read" };
    string[] level2passwords = { "arrest", "station", "detain", "criminal", "cuffs" };
    string[] level3passwords = { "rocket", "shuttle", "planet", "moon", "telescope" };

    // Game State
    public string username = "Dave";
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Try again...");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You win a book!");
                break;
            case 2:
                Terminal.WriteLine("You win a police car!");
                break;
            case 3:
                Terminal.WriteLine("You win a space shuttle!");
                break;
        }
        ShowMenuHint();
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            ShowMainMenu();
        }
        
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();        
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        ShowMenuHint();
    }

    private void SetRandomPassword()
    {
        int randomIndex;
        switch (level)
        {
            case 1:
                randomIndex = UnityEngine.Random.Range(0, level1passwords.Length);
                password = level1passwords[randomIndex];
                break;

            case 2:
                randomIndex = UnityEngine.Random.Range(0, level2passwords.Length);
                password = level2passwords[randomIndex];
                break;

            case 3:
                randomIndex = UnityEngine.Random.Range(0, level3passwords.Length);
                password = level3passwords[randomIndex];
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void ShowMenuHint()
    {
        Terminal.WriteLine("You may type 'menu' at any time.");
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + username);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1. Library");
        Terminal.WriteLine("2. Police Station");
        Terminal.WriteLine("3. NASA");
    }
}
