using System.Globalization;

namespace Game 
{
    public class Program 
    {        
        public const int SCREEN_HEIGHT = 800;
        public const int SCREEN_WIDTH = 800;

        private static void Main(string[] args) 
        {
            Initialization();

            while (true)
            {
                Time.CalculateDeltaTime();
                Update();
                Render();
            }
        }

        private static void Initialization()
        {
            Time.Initialize();
            Engine.Initialize("Paradigmas de programación", SCREEN_WIDTH, SCREEN_HEIGHT);
        }

        private static void Update()
        {
    
        }

        private static void Render()
        {
            Engine.Clear(); // Borra la pantalla
            Engine.Draw(Engine.GetTexture("Textures/ship.png"));
            Engine.Show(); // Muestra las imagenes dibujadas
        }
    }
}