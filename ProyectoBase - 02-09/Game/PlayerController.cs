using Game;
using System;

public class PlayerController
{
    private Character player;
    private float movementSpeed;
    private string textureDirection;
    private bool cambioTextura;
    private float mapWidth;
    private float mapHeight;
    private float playerWidth = 20;
    private float playerHeight = 20;
    private float vertical = 0;
    private float horizontal = 0;

    public PlayerController(Character player)
    {
        this.player = player;
        this.movementSpeed = 100;
        this.textureDirection = player.GetTexture();
        this.cambioTextura = false;
        this.mapWidth = 768;
        this.mapHeight = 574;
    }
    public void CheckMap()
    {

        switch(GameManager.Instance.currentLevel.LevelType){
            case LevelType.Level1:
                
                break;
            case LevelType.Level2:
               
                break;
            case LevelType.Level3:
                
            case LevelType.FightScene:
                
                break;
            case LevelType.WinScene:
                
                break;
            case LevelType.LoseScene:
                
                break;
            case LevelType.BossFight:
               
                break;
        }
    }
    public void Update(float deltaTime)
    {

        CheckMap();

        bool isMoving = false;
        if (Engine.GetKey(Keys.S))
        {
            //player.SetYPos(player.GetYPos() + movementSpeed * deltaTime);
            //player.SetYPos(player.GetYPos() + movementSpeed * deltaTime);
            vertical = movementSpeed * deltaTime;
    
            textureDirection = "GameAssets/movimiento1.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.W))
        {
            //player.SetYPos(player.GetYPos() - movementSpeed * deltaTime);
            vertical = -movementSpeed * deltaTime;

            textureDirection = "GameAssets/movimiento2.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.A))
        {
            //player.SetXPos(player.GetXPos() - movementSpeed * deltaTime);

            horizontal = -movementSpeed * deltaTime;
            textureDirection = "GameAssets/movimiento4.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.D))
        {
            //player.SetXPos(player.GetXPos() + movementSpeed * deltaTime);
            horizontal = movementSpeed * deltaTime;
            textureDirection = "GameAssets/movimiento3.png";
            isMoving = true;
        }

       
        ClampPlayerPosition();
        if (isMoving)
        {
            cambioTextura = true;
            Movement();

            //Console.WriteLine(player.getTransform().PositionY);



        }

        if (cambioTextura)
        {
            player.SetTexture(textureDirection);
            cambioTextura = false;
        }
        vertical = 0;
        horizontal = 0;
    }

    private void ClampPlayerPosition()
    {
        float xPos = player.GetXPos();
        float yPos = player.GetYPos();
        xPos = PositionUtilities.Clamp(xPos, 0, mapWidth - playerWidth);
        yPos = PositionUtilities.Clamp(yPos, 0, mapHeight - playerHeight);
        player.SetXPos(xPos);
        player.SetYPos(yPos);
    }
    private void Movement()
    {
        if (GameManager.Instance.currentPlayer!=null)
        {
            float xpos = GameManager.Instance.currentPlayer.GetXPos();
            float ypos = GameManager.Instance.currentPlayer.GetYPos();
            GameManager.Instance.currentPlayer.Movement(xpos + horizontal, ypos + vertical);
        }
       
    }

    public Character GetPlayer()
    {
        return player;
    }
}
