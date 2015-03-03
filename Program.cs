using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLProject
{
    class Program
    {
        enum warStats : int { str =2 , def = 3, accW = 1, warHealth = 15 };
        enum archStats : int { dex = 2, agi = 4, accA = 2, archHealth = 10 };
        enum mageStats : int { intel = 4, accM = 3, mageHealth = 10};
        static void Main(string[] args)
        {
            bool playerAlive = true;
            int playerLevel = 1;
            int exp = 0;
            string intro = "Hello and Welcome to my Text Based Adventure Game! \n";          
            Console.Write(intro);
            string intro2 = "Before we embark on our adventure, you must first choose a class! \n";
            Console.Write(intro2);
            chooseClass(playerAlive, playerLevel, exp);
            int num = 0;
            num = Convert.ToInt32(Console.ReadLine());
           
        }

        static void chooseClass(bool playerAlive, int playerLevel, int exp)
        {
            
            string classChoose = "Here are the options: (to choose, simply input 1, 2, or 3, and hit Enter) \n 1) Warrior \n 2) Archer \n 3) Mage \n";
            Console.Write(classChoose);
            string details = "For details, hit 1d, 2d, or 3d \n";
            Console.Write(details);
            string playerClass;
            playerClass = Console.ReadLine();
            switch (playerClass)
            {
                case "1":
                    string chosenClass1 = "Warrior";
                    phaseOne(chosenClass1, playerAlive, playerLevel, exp);
                    break;
                case "2":
                    string chosenClass2 = "Archer";
                    phaseOne(chosenClass2, playerAlive, playerLevel, exp);
                    break;
                case "3":
                    string chosenClass3 = "Mage";
                    phaseOne(chosenClass3, playerAlive, playerLevel, exp);
                    break;
                case "1d":
                    Console.Write("A powerful melee class with high sustain and damage output \n");
                    chooseClass(playerAlive, playerLevel, exp);
                    break;
                case "2d":
                    Console.Write("A ranged assassin with high agility and dextirity \n");
                    chooseClass(playerAlive, playerLevel, exp);
                    break;
                case "3d":
                    Console.Write("A master of the power of arcane with high intellect and cunning \n");
                    chooseClass(playerAlive, playerLevel, exp);
                    break;
                default:
                    Console.Write(classChoose + " " + details);
                    break;

            }

        }

        static void phaseOne(string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            Console.Write("You chose the " + PlayerClass + " class! \n");
            string phase1 = "Now that you have chosen the "+ PlayerClass + " class, you are ready to begin your adventure! \n";
            Console.Write(phase1);
            string phase1Enemy = "You are walking through the forest when you see a wild boar appear! What do you do? \n";
            Console.Write(phase1Enemy);
            int boarHealth = 10;
            string phase1ChooseAction = "Do you: (like before, enter 1 or 2 to choose) \n 1) Fight \n 2) Attempt to escape \n";
            Console.Write(phase1ChooseAction);
            string actionChosen;
            actionChosen = Console.ReadLine();

            switch (actionChosen)
            {

                case "1":
                    chooseAttack(boarHealth, PlayerClass, playerAlive, playerLevel, exp);
                    break;
                case "2":
                    bool escapeSuccess = escapeEnemy(boarHealth, PlayerClass, playerAlive, playerLevel, exp);

                    if (escapeSuccess == false)
                    {
                        chooseAttack(boarHealth, PlayerClass, playerAlive, playerLevel, exp);
                    }
                    break;
                default:
                    Console.Write("Cannot choose that option! \n" + phase1Enemy + phase1ChooseAction);
                    break;

            }

        }


        static bool attack(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            bool attackSuccess = false;
            string choseAttack = "You chose to attack! \n";
            Console.Write(choseAttack);
            switch (PlayerClass)
            {
                case "Warrior":    
                    //int str = playerLevel * 2 +1;
                    int str = (int)warStats.str + (playerLevel *2);
                    //int def = playerLevel *3;
                    int def = (int)warStats.def * playerLevel;
                    //int accW = playerLevel * 2;
                    int accW = (int)warStats.accW * 2;
                    //int warHealth = playerLevel + 15 + def;
                    int warHealth = (int)warStats.warHealth + 15 + def;

                    Random random = new Random();
                    int damage = random.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDone = damage + str + accW;
                    Console.Write("Damage done is = " + damageDone + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamage = random.Next(2);
                    int enemyDamageDone = enemyDamage + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDone + " \n");
                    bool enemyDead = false;

                    while (!enemyDead)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + warHealth + " \n");
                        Console.Write("Attacking! \n");
                        enemyHealth -= damageDone;
                        Console.Write("Enemy Health: " + enemyHealth + " \n");

                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDead = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            warHealth -= enemyDamageDone;
                            Console.Write("Your Health: " + warHealth + " \n");
                            if (warHealth <= 0)
                        {
                            Console.Write("Oh no!, You are dead! \n");
                            playerAlive = false;
                            attackSuccess = false;
                        }

                        }
                       
                    }
                                        
                    break;
                case "Archer":
                    //int archHealth = playerLevel + 10;
                    int archHealth = (int)archStats.archHealth + playerLevel;
                    //int accA = playerLevel * 2 + 2;
                    int accA = (int)archStats.accA + (playerLevel * 2);
                    //int dex = playerLevel * 2;
                    int dex = (int)archStats.dex * playerLevel;
                    //int agi = playerLevel * 3;
                    int agi = (int)archStats.agi * playerLevel;

                    Random randomA = new Random();
                    int damageA = randomA.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDoneA = damageA + accA + (dex + agi);
                    Console.Write("Damage done is = " + damageDoneA + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamageA = randomA.Next(2);
                    int enemyDamageDoneA = enemyDamageA + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDoneA + " \n");
                    bool enemyDeadA = false;

                    while (!enemyDeadA)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + archHealth + " \n");
                        Console.Write("Attacking! \n");
                        enemyHealth -= damageDoneA;
                        Console.Write("Enemy Health: " + enemyHealth + " \n");

                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDeadA = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            archHealth -= enemyDamageDoneA;
                            Console.Write("Your Health: " + archHealth + " \n");
                             if (archHealth <= 0)
                        {
                            Console.Write("Oh no!, You are dead! \n");
                            playerAlive = false;
                            attackSuccess = false;
                        }
                        }
                        
                    }

                    break;
                case "Mage":
                    //int mageHealth = playerLevel + 10;
                    int mageHealth = (int)mageStats.mageHealth + playerLevel;
                    //int intel = playerLevel * 3 + 1;
                    int intel = (int)mageStats.intel * (playerLevel + 1);
                    //int accM = playerLevel * 2;
                    int accM = (int)mageStats.accM * playerLevel;

                    Random randomM = new Random();
                    int damageM = randomM.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDoneM = damageM + intel + accM;
                    Console.Write("Damage done is = " + damageDoneM + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamageM = randomM.Next(2);
                    int enemyDamageDoneM = enemyDamageM + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDoneM + " \n");
                    bool enemyDeadM = false;

                    while (!enemyDeadM)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + mageHealth + " \n");
                        Console.Write("Attacking! \n");
                        enemyHealth -= damageDoneM;
                        Console.Write("Enemy Health: " + enemyHealth + " \n");

                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDeadM = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            mageHealth -= enemyDamageDoneM;
                            Console.Write("Your Health: " + mageHealth + " \n");
                            if (mageHealth <= 0)
                            {
                                Console.Write("Oh no!, You are dead! \n");
                                playerAlive = false;
                                attackSuccess = false;
                            }
                        }
                        
                    }
                    
                    break;
                default:
                    break;

            }
            
            return attackSuccess;
        }

        static bool escapeEnemy(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            bool escapeSuccess = false;
            string attempEscape = "You are attempting to escape! \n";
            Console.Write(attempEscape);

            switch (PlayerClass)
            {

                case "Warrior":
                    //int def = playerLevel *3;
                    int def = (int)warStats.def * playerLevel;
                    //int warHealth = playerLevel + 15 + def;
                    int warHealth = (int)warStats.warHealth + playerLevel + def;

                    Random randomW = new Random();
                    int escapeChanceW = randomW.Next(10);
                    Console.Write("Rolling on escape chance!");
                    int result = (enemyHealth + escapeChanceW) - warHealth;
                    Console.Write("The result was " + result);
                    if (result <= 0)
                    {
                        Console.Write("You got away! Returning to previous phase now! \n");
                        escapeSuccess = true;
                        chooseClass(playerAlive, playerLevel, exp);
                    }

                    else
                    {
                        Console.Write("Escape Failed! Going to attack phase! \n");
                        escapeSuccess = false;
                    }
                    break;

                case "Archer":
                    //int archHealth = playerLevel + 10;
                    int archHealth = (int)archStats.archHealth + playerLevel;
                    //int dex = playerLevel * 2;
                    int dex = (int)archStats.dex * playerLevel;
                    //int agi = playerLevel * 3;
                    int agi = (int)archStats.agi * playerLevel;

                    Random randomA = new Random();
                    int escapeChanceA = randomA.Next(10);
                    Console.Write("Rolling on escape chance!");
                    int resultA = (enemyHealth + escapeChanceA) - (archHealth + dex + agi);
                    Console.Write("The result was " + resultA);

                    if (resultA <= 0)
                    {
                        Console.Write("You got away! Returning to previous phase now! \n");
                        escapeSuccess = true;
                        chooseClass(playerAlive, playerLevel, exp);
                    }

                    else
                    {
                        Console.Write("Escape Failed! Going to attack phase! \n");
                        escapeSuccess = false;
                    }
                    break;

                case "Mage":
                    //int mageHealth = playerLevel + 10;
                    int mageHealth = (int)mageStats.mageHealth + playerLevel;
                    //int intel = playerLevel * 3 + 1;
                    int intel = (int)mageStats.intel * (playerLevel + 1);

                    Random randomM = new Random();
                    int escapeChanceM = randomM.Next(10);
                    Console.Write("Rolling on escape chance!");
                    int resultM = (enemyHealth + escapeChanceM) - (mageHealth + intel);
                    Console.Write("The result was " + resultM);

                    if (resultM <= 0)
                    {
                        Console.Write("You got away! Returning to previous phase now! \n");
                        escapeSuccess = true;
                        chooseClass(playerAlive, playerLevel, exp);
                    }

                    else
                    {
                        Console.Write("Escape Failed! Going to attack phase! \n");
                        escapeSuccess = false;
                    }

                    break;

                default:
                    break;

            }

            return escapeSuccess;
        }

        static void checkExp(int exp, int playerLevel, string PlayerClass)
        {

            if (exp >= 30 && exp < 75)
            {
                Console.Write("Congratullations! You are now level 2! \n");
                Console.Write("Your exp is: " + exp + " \n");
                playerLevel += 1;
            }
            else if (exp >= 75 && exp < 125)
            {
                Console.Write("Congratullations! You are now level 3! \n");
                Console.Write("Your exp is: " + exp + " \n");
                playerLevel += 1;
            }
            else if (exp >= 125 && exp < 200)
            {
                Console.Write("Congratullations! You are now level 4! \n");
                Console.Write("Your exp is: " + exp + " \n");
                playerLevel += 1;
            }
            else if (exp >= 200 && exp < 350)
            {
                Console.Write("Congratullations! You are now level 5! \n");
                Console.Write("Your exp is: " + exp + " \n");
                playerLevel += 1;
            }
            else if (exp >= 350 && exp < 500)
            {
                Console.Write("Congratullations! You are now level 6! \n");
                Console.Write("Your exp is: " + exp + " \n");
                playerLevel += 1;
            }
            else
                Console.Write("Keep on adventuring, young one! \n");
        }

        static void phaseTwo(string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            Console.Write("Good job, young adventurer! You have completed your first trial and have advanced to higher power! \n");
            string phaseTwo = "Now it is time for you to begin your real adventure! \n";
            Console.Write(phaseTwo);
            string phaseTwo1 = "You are a very brave and valiant " + PlayerClass + " who is tasked to go and kill the evil dragon haunting the city \n";
            Console.Write(phaseTwo1);

            int dragonWhelpCount = 3;
            int dragonWhelpHealth = 25;

            string phaseTwoEnemy = "You approach the path to the lair of the beast when you come accross three dragon whelps! You must act quickly! \n";
            Console.Write(phaseTwoEnemy);
            while (dragonWhelpCount > 0)
            {
                string enemyCountLoop = "There are " + dragonWhelpCount + " whelps left!";
                Console.Write(enemyCountLoop);
                string phaseTwoChooseAction = "Will you take on the beasts (option 1) or will you run away (option 2), like a coward? Remember, you are a hero! Choose wisely! \n";
                Console.Write(phaseTwoChooseAction);

                string actionChosen;
                actionChosen = Console.ReadLine();

                switch (actionChosen)
                {

                    case "1":
                        bool attackSuccess = attack(dragonWhelpHealth, PlayerClass, playerAlive, playerLevel, exp);

                        if (attackSuccess == false)
                        {
                        Console.Write("You are dead, Exiting game \n");
                        }

                        else
                        {
                        int expGain = dragonWhelpHealth + 30;
                        Console.Write("You killed it! You gain " + expGain + " exp! \n");
                        dragonWhelpCount -= 1;
                        exp += expGain;
                        checkExp(exp, playerLevel, PlayerClass);
                        }
                        break;
                    case "2":
                        bool escapeSuccess = escapeEnemy(dragonWhelpHealth, PlayerClass, playerAlive, playerLevel, exp);

                        if (escapeSuccess == false)
                        {
                            chooseAttackPhaseTwo(dragonWhelpHealth, PlayerClass, playerAlive, playerLevel, exp, dragonWhelpCount);
                        }
                        break;
                    default:
                        Console.Write("Cannot choose that option! \n" + phaseTwoEnemy + phaseTwoChooseAction + " \n");
                        break;

                }
            }

            bossPhase(PlayerClass, playerAlive, playerLevel, exp);
            
        }

        static void bossPhase(string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            Console.Write("Wow! What a feat! You have passed all the challenges that you have come accross so far, young hero! \n");
            Console.Write("You feel an eerie breeze as you walk closer to the den of the beast...the sky grows dark, you feel it's evil presense... \n");

            int bossHealth = 100;
            string bossReveal = "RRRRRRRRRAAAAAAAWWWWWRRRRRRRR!!!! The Beast roars with great might! Will you be the hero of the day? Will you defeat this monster? \n";
            Console.Write(bossReveal);
            string bossChoose = "Enter 1 to attack and 2 to flee back to the village in shame! \n";
            Console.Write(bossChoose);

            string actionChosen;
            actionChosen = Console.ReadLine();

            switch (actionChosen)
            {

                case "1":
                    chooseAttackBoss(bossHealth, PlayerClass, playerAlive, playerLevel, exp);
                    break;
                case "2":
                    bool escapeSuccess = escapeEnemy(bossHealth, PlayerClass, playerAlive, playerLevel, exp);

                    if (escapeSuccess == false)
                    {
                        chooseAttackBoss(bossHealth, PlayerClass, playerAlive, playerLevel, exp);
                    }
                    break;
                default:
                    Console.Write("Cannot choose that option! \n" + bossReveal + bossChoose + " \n");
                    break;

            }

        }

        static void chooseAttackBoss(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            bool attackSuccess = attackBoss(enemyHealth, PlayerClass, playerAlive, playerLevel, exp);

            if (attackSuccess == false)
            {
                Console.Write("You are dead, Exiting game \n");
            }

            else
            {
                int expGain = enemyHealth + 30;
                Console.Write("You killed The Beast! You saved the world! You gain " + expGain + " exp! \n");
                exp += expGain;
                checkExp(exp, playerLevel, PlayerClass);
                Console.Write("Congratullations! You have defeated the beast and saved the world! enter any number to exit the game now. \n");
            }
        }

        static void chooseAttackPhaseTwo(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp, int whelpCount)
        {

            bool attackSuccess = attack(enemyHealth, PlayerClass, playerAlive, playerLevel, exp);

            if (attackSuccess == false)
            {
                Console.Write("You are dead, Exiting game \n");
            }

            else
            {
                int expGain = enemyHealth + 30;
                Console.Write("You killed it! You gain " + expGain + " exp! \n");
                whelpCount -= 1;
                exp += expGain;
                checkExp(exp, playerLevel, PlayerClass);
            }

        }

        static void chooseAttack(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            bool attackSuccess = attack(enemyHealth, PlayerClass, playerAlive, playerLevel, exp);

            if (attackSuccess == false)
            {
                Console.Write("You are dead, Exiting game \n");
            }

            else
            {
                int expGain = enemyHealth + 30;
                Console.Write("You killed it! You gain " + expGain + " exp! \n");
                exp += expGain;
                checkExp(exp, playerLevel, PlayerClass);
                phaseTwo(PlayerClass, playerAlive, playerLevel, exp);
            }
        }

        static bool attackBoss(int enemyHealth, string PlayerClass, bool playerAlive, int playerLevel, int exp)
        {
            bool attackSuccess = false;
            string choseAttack = "You chose to attack! \n";
            Console.Write("For the Boss fight, you can use potions to replenish health! \n");
            Console.Write(choseAttack);
            switch (PlayerClass)
            {
                case "Warrior":
                    //int str = playerLevel * 2 +1;
                    int str = (int)warStats.str + (playerLevel * 2);
                    //int def = playerLevel *3;
                    int def = (int)warStats.def * playerLevel;
                    //int accW = playerLevel * 2;
                    int accW = (int)warStats.accW * 2;
                    //int warHealth = playerLevel + 15 + def;
                    int warHealth = (int)warStats.warHealth + 15 + def;

                    Random random = new Random();
                    int damage = random.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDone = damage + str + accW;
                    Console.Write("Damage done is = " + damageDone + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamage = random.Next(2);
                    int enemyDamageDone = enemyDamage + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDone + " \n");
                    bool enemyDead = false;

                    while (!enemyDead && playerAlive)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + warHealth + " \n");
                        Console.Write("Choose what to do! \n");
                        Console.Write("1) Sword Slice \n 2) Shield up! \n 3) Use Health Potion \n");
                    
                        string courseOfAction;
                        courseOfAction = Console.ReadLine();
                        switch (courseOfAction)
                        {
                            case "1":
                                Console.Write("Attacking with Sword Slice! \n");
                                enemyHealth -= damageDone;
                                Console.Write("Enemy Health: " + enemyHealth + " \n");
                                break;
                            
                            case "2":
                                Console.Write("Using Shield up! Defense rose! \n");
                                def += 3;
                                warHealth += def;
                                break;
                            
                            case "3":
                                Console.Write("Using health potion! Regained Health! \n");
                                warHealth += 10;
                                break;
                            
                            default:
                                break;
                        }


                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDead = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            warHealth -= enemyDamageDone;
                            Console.Write("Your Health: " + warHealth + " \n");
                            if (warHealth <= 0)
                            {
                                Console.Write("Oh no!, You are dead! \n");
                                playerAlive = false;
                                attackSuccess = false;
                            }
                        }
                       
                    }

                    break;
                case "Archer":
                    //int archHealth = playerLevel + 10;
                    int archHealth = (int)archStats.archHealth + playerLevel;
                    //int accA = playerLevel * 2 + 2;
                    int accA = (int)archStats.accA + (playerLevel * 2);
                    //int dex = playerLevel * 2;
                    int dex = (int)archStats.dex * playerLevel;
                    //int agi = playerLevel * 3;
                    int agi = (int)archStats.agi * playerLevel;

                    Random randomA = new Random();
                    int damageA = randomA.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDoneA = damageA + accA + (dex + agi);
                    Console.Write("Damage done is = " + damageDoneA + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamageA = randomA.Next(2);
                    int enemyDamageDoneA = enemyDamageA + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDoneA + " \n");
                    bool enemyDeadA = false;

                    while (!enemyDeadA && playerAlive)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + archHealth + " \n");
                        Console.Write("Choose what to do! \n");
                        Console.Write("1) Arrow Barrage \n 2) Sharp Senses! \n 3) Use Health Potion \n");

                        string courseOfAction;
                        courseOfAction = Console.ReadLine();
                        switch (courseOfAction)
                        {
                            case "1":
                                Console.Write("Attacking with Arrow Barrage! \n");
                                enemyHealth -= damageDoneA + 1 + 1;
                                Console.Write("Enemy Health: " + enemyHealth + " \n");
                                break;

                            case "2":
                                Console.Write("Using Sharp Senses! Dexterity rose! \n");
                                dex += 3;
                                damageDoneA += dex;
                                break;

                            case "3":
                                Console.Write("Using health potion! Regained Health! \n");
                                archHealth += 10;
                                break;

                            default:
                                break;
                        }

                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDeadA = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            archHealth -= enemyDamageDoneA;
                            Console.Write("Your Health: " + archHealth + " \n");

                            if (archHealth <= 0)
                        {
                            Console.Write("Oh no!, You are dead! \n");
                            playerAlive = false;
                            attackSuccess = false;
                        }
                        }
                        
                    }

                    break;
                case "Mage":
                    //int mageHealth = playerLevel + 10;
                    int mageHealth = (int)mageStats.mageHealth + playerLevel;
                    //int intel = playerLevel * 3 + 1;
                    int intel = (int)mageStats.intel * (playerLevel + 1);
                    //int accM = playerLevel * 2;
                    int accM = (int)mageStats.accM * playerLevel;

                    Random randomM = new Random();
                    int damageM = randomM.Next(3);
                    Console.Write("Rolling on the damage done! \n");
                    int damageDoneM = damageM + intel + accM;
                    Console.Write("Damage done is = " + damageDoneM + " \n");
                    Console.Write("Rolling on enemy damage done! \n");
                    int enemyDamageM = randomM.Next(2);
                    int enemyDamageDoneM = enemyDamageM + 2;
                    Console.Write("Enemy damage done = " + enemyDamageDoneM + " \n");
                    bool enemyDeadM = false;

                    while (!enemyDeadM && playerAlive)
                    {
                        Console.Write("Enemy health: " + enemyHealth + " Your Health: " + mageHealth + " \n");
                        Console.Write("Choose what to do! \n");
                        Console.Write("1) Fire Ball \n 2) Brilliance! \n 3) Use Health Potion \n");

                        string courseOfAction;
                        courseOfAction = Console.ReadLine();
                        switch (courseOfAction)
                        {
                            case "1":
                                Console.Write("Attacking with Fire Ball! \n");
                                enemyHealth -= damageDoneM + 3;
                                Console.Write("Enemy Health: " + enemyHealth + " \n");
                                break;

                            case "2":
                                Console.Write("Using Brilliance! Intellect rose! \n");
                                intel += 3;
                                damageDoneM += intel;
                                break;

                            case "3":
                                Console.Write("Using health potion! Regained Health! \n");
                                mageHealth += 10;
                                break;

                            default:
                                break;
                        }

                        if (enemyHealth <= 0)
                        {
                            Console.Write("Enemy Dead! \n");
                            attackSuccess = true;
                            enemyDeadM = true;
                        }

                        else if (enemyHealth > 0)
                        {
                            Console.Write("Enemy Alive, retaliating! \n");
                            mageHealth -= enemyDamageDoneM;
                            Console.Write("Your Health: " + mageHealth + " \n");
                            if (mageHealth <= 0)
                        {
                            Console.Write("Oh no!, You are dead! \n");
                            playerAlive = false;
                            attackSuccess = false;
                        }
                        }
                    }

                    break;
                default:
                    break;

            }

            return attackSuccess;
        }

    }
}
