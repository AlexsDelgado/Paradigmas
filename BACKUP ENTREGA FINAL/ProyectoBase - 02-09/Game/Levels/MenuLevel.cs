using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MenuLevel : Level
    {
        private Button playButton;
        private Button exitButton;
        private Button scoreButton;
        private Button creditsButton;
        private int selectedButtonIndex;
        private List<Button> buttons;
        private bool scoreMenu;
        private bool creditsMenu;
        private Asset scoreBoard;
        private Asset score1;
        private Asset score1_1;
        private Asset score1_2;
        private Asset score1_3;
        private Asset score2;
        private Asset score2_1;
        private Asset score2_2;
        private Asset score2_3;
        private Asset score3;
        private Asset score3_1;
        private Asset score3_2;
        private Asset score3_3;
        private Asset creditsBoard;
        private Asset AlexsCredits;
        private Asset MartinCredits;

        private string[] scores;


        public MenuLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            playButton = new Button("Jugar", Engine.GetTexture("Textures/Buttons/Play/PlayButton1.png"), 192, 100);
            scoreButton = new Button("Score", Engine.GetTexture("Textures/Buttons/Score/ScoreButton.png"),192,200);
            creditsButton = new Button("Credits", Engine.GetTexture("Textures/Buttons/Credits/CreditsButton.png"), 192, 300);
            exitButton = new Button("Salir", Engine.GetTexture("Textures/Buttons/Quit/QuitButton1.png"), 192, 400);
            buttons = new List<Button> { playButton, scoreButton,creditsButton, exitButton,};
            selectedButtonIndex = 0;

            scoreMenu = false;
            scoreBoard = new Asset();
            scoreBoard.CreateAsset(new TransformData(180,100),"Textures/ScoreBoard.png") ;
            creditsBoard = new Asset();
            creditsBoard.CreateAsset(new TransformData(180, 100), "Textures/CreditsMenu.png");

            AlexsCredits = new Asset();
            AlexsCredits.CreateAsset(new TransformData(200, 150), "Textures/Alexs.png");
            MartinCredits = new Asset();
            MartinCredits.CreateAsset(new TransformData(200, 250), "Textures/Martin.png");


            scores = new string[3];
            score1 = new Asset();
            score1.CreateAsset(new TransformData(200,150), "Textures/System/1.png");
            
            score1_1 = new Asset();
            score1_1.CreateAsset(new TransformData(250, 150), "Textures/System/empty.png");
            
            score1_2= new Asset();
            score1_2.CreateAsset(new TransformData(280, 150), "Textures/System/empty.png");
            
            score1_3 = new Asset();
            score1_3.CreateAsset(new TransformData(310, 150), "Textures/System/empty.png");



            score2 = new Asset();
            score2.CreateAsset(new TransformData(200, 200), "Textures/System/2.png");


            score2_1 = new Asset();
            score2_1.CreateAsset(new TransformData(250, 200), "Textures/System/empty.png");

            score2_2 = new Asset();
            score2_2.CreateAsset(new TransformData(280, 200), "Textures/System/empty.png");

            score2_3 = new Asset();
            score2_3.CreateAsset(new TransformData(310, 200), "Textures/System/empty.png");




            score3 = new Asset();
            score3.CreateAsset(new TransformData(200, 250), "Textures/System/3.png");


            score3_1 = new Asset();
            score3_1.CreateAsset(new TransformData(250, 250), "Textures/System/empty.png");

            score3_2 = new Asset();
            score3_2.CreateAsset(new TransformData(280, 250), "Textures/System/empty.png");

            score3_3 = new Asset();
            score3_3.CreateAsset(new TransformData(310, 250), "Textures/System/empty.png");



        }

    public override void Render()
        {
            Engine.Draw(background);

      
            if (!creditsMenu && !scoreMenu)
            {
                foreach (var button in buttons)
                {
                    button.Render();
                }
                Engine.Draw(Engine.GetTexture("Textures/Buttons/Play/SelectedButton.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos());

            }
            else
            {
                if (scoreMenu)
                {
                    scoreBoard.Draw();
                    score1.Draw();
                    score1_1.Draw();
                    score1_2.Draw();
                    score1_3.Draw();
                    score2.Draw();
                    score2_1.Draw();
                    score2_2.Draw();
                    score2_3.Draw();
                    score3.Draw();
                    score3_1.Draw();
                    score3_2.Draw();
                    score3_3.Draw();
                }
                if (creditsMenu)
                {
                    creditsBoard.Draw();
                    AlexsCredits.Draw();
                    MartinCredits.Draw();
                }
            }

        }

        public override void Update()
        {
            if (scoreMenu)
            {
              
            }
            else
            {
                if (Engine.GetKey(Keys.Num1))
                {
                    selectedButtonIndex = 0;
                }
                if (Engine.GetKey(Keys.Num2))
                {
                    selectedButtonIndex = 1;
                    Console.WriteLine("scores:");
                    GameManager.Instance.printScores();
                }
                if (Engine.GetKey(Keys.Num3))
                {
                    selectedButtonIndex = 2;
                    //Console.WriteLine("scores:");
                    //GameManager.Instance.printScores();
                }
                if (Engine.GetKey(Keys.Num4))
                {
                    selectedButtonIndex = 3;
           
                }
                if (Engine.GetKey(Keys.DOWN))
                {
                    
                    selectedButtonIndex++;
                    if (selectedButtonIndex > 3)
                    {
                        selectedButtonIndex = 3;
                    }
                }
                else if (Engine.GetKey(Keys.UP))
                {
                    
                    selectedButtonIndex--;
                    if (selectedButtonIndex < 0)
                    {
                        selectedButtonIndex = 0;
                    }
                }

                if (Engine.GetKey(Keys.SPACE))
                {

                    switch (selectedButtonIndex)
                    {
                        case 0:
                            GameManager.Instance.ResetGame();
                            GameManager.Instance.ChangeLevel(LevelType.Level1);
                            break;
                        case 1:
                            CheckScore();

                            scoreMenu = true;
                            
                            break;
                        case 2:
                            creditsMenu = true;
                        
                            break;
                        case 3:
                            Engine.Clear();
                            break;
                        case 4:
                         
                            break;
                        default:
                            break;

                    }
                }
            }
            if (Engine.GetKey(Keys.ESCAPE))
            {
                selectedButtonIndex = 0;
                scoreMenu = false;
                creditsMenu = false;
            }
        }
        public void CheckScore()
        {
            GameManager.Instance.ScoreSort();
    
            if (GameManager.Instance.scoreboardList.Count > 0)
            {
                string[] score1 = ScoreTexture(GameManager.Instance.scoreboardList[0]);
                Console.WriteLine(GameManager.Instance.scoreboardList[0]);
                for (int i = 0; i < score1.Length; i++)
                {
                    if (!string.IsNullOrEmpty(score1[i]))
                    {

                        switch (i)
                        {
                            case 0:
                                score1_1.CreateAsset(new TransformData(250, 150), score1[i]);
                                Console.WriteLine($"Posicion 0 { score1[i]}");
                                break;
                            case 1:
                                score1_2.CreateAsset(new TransformData(280, 150), score1[i]);
                                Console.WriteLine($"Posicion 1 { score1[i]}");
                                break;
                            case 2:
                                score1_3.CreateAsset(new TransformData(310, 150), score1[i]);
                                Console.WriteLine($"Posicion 2 { score1[i]}");
                                break;
                        }
                    }
                }
            }
            if (GameManager.Instance.scoreboardList.Count > 1)
            {
                string[] score2 = ScoreTexture(GameManager.Instance.scoreboardList[1]);
                Console.WriteLine(GameManager.Instance.scoreboardList[1]);
                for (int i = 0; i < score2.Length; i++)
                {
                    if (!string.IsNullOrEmpty(score2[i]))
                    {

                        switch (i)
                        {
                            case 0:
                                score2_1.CreateAsset(new TransformData(250, 200), score2[i]);
                                Console.WriteLine($"Posicion 0 { score2[i]}");
                                break;
                            case 1:
                                score2_2.CreateAsset(new TransformData(280, 200), score2[i]);
                                Console.WriteLine($"Posicion 1 { score2[i]}");
                                break;
                            case 2:
                                score2_3.CreateAsset(new TransformData(310, 200), score2[i]);
                                Console.WriteLine($"Posicion 2 { score2[i]}");
                                break;
                        }
                    }
                }
            }
            if (GameManager.Instance.scoreboardList.Count > 2)
            {
                string[] score3 = ScoreTexture(GameManager.Instance.scoreboardList[2]);
                Console.WriteLine(GameManager.Instance.scoreboardList[2]);
                for (int i = 0; i < score3.Length; i++)
                {
                    if (!string.IsNullOrEmpty(score3[i]))
                    {

                        switch (i)
                        {
                            case 0:
                                score3_1.CreateAsset(new TransformData(250, 250), score3[i]);
                                Console.WriteLine($"Posicion 0 { score3[i]}");
                                break;
                            case 1:
                                score3_2.CreateAsset(new TransformData(280, 250), score3[i]);
                                Console.WriteLine($"Posicion 1 { score3[i]}");
                                break;
                            case 2:
                                score3_3.CreateAsset(new TransformData(310, 250), score3[i]);
                                Console.WriteLine($"Posicion 2 { score3[i]}");
                                break;
                        }
                    }
                }
            }
        }
        public String[] ScoreTexture(int _score)
        {

            string scoreArray = _score.ToString();
            int[] digit = new int[scoreArray.Length];
            string[] ScoreTexture = new string[scoreArray.Length];
            for (int i = 0; i < scoreArray.Length; i++)
            {
                digit[i] = int.Parse(scoreArray[i].ToString());
                Console.Write(digit[i]);
                switch (digit[i])
                {
                    case 0:
                        ScoreTexture[i] = "Textures/System/0.png";
                        break;
                    case 1:
                        ScoreTexture[i] = "Textures/System/1.png";
                        break;
                    case 2:
                        ScoreTexture[i] = "Textures/System/2.png";
                        break;
                    case 3:
                        ScoreTexture[i] = "Textures/System/3.png";
                        break;
                    case 4:
                        ScoreTexture[i] = "Textures/System/4.png";
                        break;
                    case 5:
                        ScoreTexture[i] = "Textures/System/5.png";
                        break;
                    case 6:
                        ScoreTexture[i] = "Textures/System/6.png";
                        break;
                    case 7:
                        ScoreTexture[i] = "Textures/System/7.png";
                        break;
                    case 8:
                        ScoreTexture[i] = "Textures/System/8.png";
                        break;
                    case 9:
                        ScoreTexture[i] = "Textures/System/9.png";
                        break;
                }

            }
            return ScoreTexture;
        }
    }
}
