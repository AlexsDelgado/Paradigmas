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
        private int selectedButtonIndex;
        private List<Button> buttons;

        public MenuLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            playButton = new Button("Jugar", Engine.GetTexture("Textures/Buttons/Play/PlayButton1.png"), 0, 500);
            exitButton = new Button("Salir", Engine.GetTexture("Textures/Buttons/Quit/QuitButton1.png"), 400, 500);
            buttons = new List<Button> { playButton, exitButton };
            selectedButtonIndex = 0;
        }

        public override void Render()
        {
            Engine.Draw(background);

            foreach (var button in buttons)
            {
                button.Render();
            }


            Engine.Draw(Engine.GetTexture("Textures/Buttons/Play/SelectedButton.png"), buttons[selectedButtonIndex].GetXPos(), buttons[selectedButtonIndex].GetYPos());
        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.RIGHT))
            {
                //selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Count;
                selectedButtonIndex++;
                if (selectedButtonIndex > 1)
                {
                    selectedButtonIndex = 1;
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
                if (selectedButtonIndex == 0)
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level1);
                }
                else if (selectedButtonIndex == 1)
                {
               
                    Engine.Clear();
                }
            }
        }
    }
}
