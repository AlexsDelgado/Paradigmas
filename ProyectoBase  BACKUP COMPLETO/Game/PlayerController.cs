using Game;

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

    public PlayerController(Character player)
    {
        this.player = player;
        this.movementSpeed = 100;
        this.textureDirection = player.GetTexture();
        this.cambioTextura = false;
        this.mapWidth = 800;
        this.mapHeight = 600;
    }

    public void Update(float deltaTime)
    {
        bool isMoving = false;
        if (Engine.GetKey(Keys.S))
        {
            player.SetYPos(player.GetYPos() + movementSpeed * deltaTime);
            textureDirection = "GameAssets/movimiento1.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.W))
        {
            player.SetYPos(player.GetYPos() - movementSpeed * deltaTime);
            textureDirection = "GameAssets/movimiento2.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.A))
        {
            player.SetXPos(player.GetXPos() - movementSpeed * deltaTime);
            textureDirection = "GameAssets/movimiento4.png";
            isMoving = true;
        }
        if (Engine.GetKey(Keys.D))
        {
            player.SetXPos(player.GetXPos() + movementSpeed * deltaTime);
            textureDirection = "GameAssets/movimiento3.png";
            isMoving = true;
        }
        ClampPlayerPosition();
        if (isMoving)
        {
            cambioTextura = true;
        }

        if (cambioTextura)
        {
            player.SetTexture(textureDirection);
            cambioTextura = false;
        }
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

    public Character GetPlayer()
    {
        return player;
    }
}
