using System.Globalization;

namespace Game 
{
<<<<<<< Updated upstream
    public class Program 
    {        
        public const int SCREEN_HEIGHT = 800;
        public const int SCREEN_WIDTH = 800;

        private static void Main(string[] args) 
        {
            Initialization();
=======
    public class Program
    {
        public static void Main(string[] args)
        {
            Engine.Initialize();
            TransformData transformPlayer = new TransformData();
            TransformData tranformNPC = new TransformData();
            TransformData transformEnemy = new TransformData();
            transformPlayer.SetPosition(50, 50);
            tranformNPC.SetPosition(500,50);
            transformEnemy.SetPosition(400, 300);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 10, 1, 1, 50, 50);
            Character player = new Character("hero", 10, 10, 10, transformPlayer, "GameAssets/movimiento1.png");
            //npc john = new npc("John", "GameAssets/movimiento1.png", 10, 1, 1, 400, 200);
            npc john = new npc("Jhony", 50, 10, 5, tranformNPC, "GameAssets/movimiento1.png");
            //Enemy badGuy1 = new Enemy("Mavado", "GameAssets/enemigo1.png", 5, 2, 2, 500, 50);
            
            Enemy badGuy1 = new Enemy("Enemy1", "GameAssets/enemigo1.png", 50, 20, 2, transformEnemy);

            PlayerController playerController = new PlayerController(player);
            NPCController npcController = new NPCController(john);
            EnemyController enemyController = new EnemyController(badGuy1);
            TimeManager timeManager = new TimeManager();
            LevelManager levelManager = new LevelManager(playerController, npcController, enemyController);
            UIManager uiManager = new UIManager(Engine.GetTexture("GameAssets/Assets/barra1.png"), Engine.GetTexture("GameAssets/Assets/barra2.png"));
>>>>>>> Stashed changes

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