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
        private Asset creditsBoard;
        private Asset AlexsCredits;
        private Asset MartinCredits;


        public MenuLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            playButton = new Button("Jugar", Engine.GetTexture("Textures/Buttons/Play/PlayButton1.png"), 192, 100);
            exitButton = new Button("Salir", Engine.GetTexture("Textures/Buttons/Quit/QuitButton1.png"), 192, 200);
            scoreButton = new Button("Score", Engine.GetTexture("Textures/Buttons/Score/ScoreButton.png"),192,300);
            creditsButton = new Button("Credits", Engine.GetTexture("Textures/Buttons/Credits/CreditsButton.png"), 192, 400);
            buttons = new List<Button> { playButton, exitButton,scoreButton,creditsButton};
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
                CheckScore();  
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
                }
                if (Engine.GetKey(Keys.Num3))
                {
                    selectedButtonIndex = 2;
                }
                if (Engine.GetKey(Keys.Num4))
                {
                    selectedButtonIndex = 3;
           
                }
                if (Engine.GetKey(Keys.RIGHT))
                {
                    //selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Count;
                    selectedButtonIndex++;
                    if (selectedButtonIndex > 3)
                    {
                        selectedButtonIndex = 3;
                    }
                }
                else if (Engine.GetKey(Keys.LEFT))
                {
                    //selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Count) % buttons.Count;
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
                            GameManager.Instance.ChangeLevel(LevelType.Level1);
                            break;
                        case 1:
                            Engine.Clear();
                            break;
                        case 2:
                            scoreMenu = true;
                            break;
                        case 3:
                            creditsMenu = true;
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

        }
    }
}
